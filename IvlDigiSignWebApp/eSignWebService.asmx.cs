using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CrXc = System.Security.Cryptography.X509Certificates; 
using System.Configuration;
using System.IO;
using IvlDigiSignWebApp.Common; 
using System.Data;
using Newtonsoft.Json; 

namespace IvlDigiSignWebApp
{
    /// <summary>
    /// Summary description for eSignWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class eSignWebService : System.Web.Services.WebService
    {
        ErrorMessage ErrMsg = new ErrorMessage();
        DigitalSignatureMaster ObjDigitalSignatureMaster = new DigitalSignatureMaster();
        DocParamUserDigiSignMapping ObjDocParamUserDigiSignMapping = new DocParamUserDigiSignMapping();
        HttpResponse response = HttpContext.Current.Response;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void GetSignedDoc(string Docid, string Docdesc, string Signtyp, string Signmul, string SAPSysid,
                    string SAPuname, string SAPClient, string Key, string Rfskey, string Doc, string USERXML, string USERJSON)
        {
           
            IvlDigiSign objIvlDigiSign = new IvlDigiSign();


            bool flagDoc = false;
            IVLDigiSignBusinessObjects.SignTypeDefault = Signtyp;
           


            string ParameterId = string.Empty;
            string UserId = string.Empty;
            string DSId = string.Empty, UName = string.Empty;


            string DSName = string.Empty, DSNameOut = string.Empty;
            string DSPwd = string.Empty, DSPwdOut = string.Empty;
            string DSLocX = string.Empty, DSLocllX = string.Empty, DSLocXOut = string.Empty, DSLocllXOut = string.Empty;
            string DSLocY = string.Empty, DSLocllY = string.Empty, DSLocYOut = string.Empty, DSLocllYOut = string.Empty;
            string designation = string.Empty, designationOut = string.Empty;
            string location = string.Empty, locationOut = string.Empty;
            string SignTyp = string.Empty;
            string JsonString = string.Empty;
            string DongleType = Key; // New change for sign dongle
            int DSFlag = 1;
            bool flagUser = false;
            List<string> lstUName = new List<string>();
            DataTable dtJsonUserData = new DataTable();
            if (USERJSON.Length > 0)
            {
                JsonString = USERJSON.Substring(8, USERJSON.Length - 9);
                dtJsonUserData = JsonConvert.DeserializeObject<DataTable>(JsonString);
                ErrMsg.CreateLogFile("Json Array:", "PRMID", JsonString, "");
                IVLFileExtraction objIVLFileExtraction = new IVLFileExtraction();
                if (dtJsonUserData.Rows.Count > 0)
                {
                    for (int i = 0; i < dtJsonUserData.Rows.Count; i++)
                   {
                        ParameterId = dtJsonUserData.Rows[i]["PRMID"].ToString();
                        UserId = dtJsonUserData.Rows[i]["USERID"].ToString();
                        DSId = dtJsonUserData.Rows[i]["DNGID"].ToString();
                        UName = dtJsonUserData.Rows[i]["UNAME"].ToString();
                        SignTyp += dtJsonUserData.Rows[i]["SIGNTYP"].ToString() + ",";
                        lstUName.Add(UName);  // check user exist

                        ErrMsg.CreateLogFile("Json Array:" + i, "PRMID", ParameterId, "");
                        ErrMsg.CreateLogFile("Json Array:" + i, "USERID", UserId, "");
                        ErrMsg.CreateLogFile("Json Array:" + i, "DNGID", DSId, "");

                       

                        objIVLFileExtraction.ReadIvlFileToIvlClass(Docid, ParameterId, UserId, DSId, ref DSNameOut, ref DSPwdOut, ref DSLocXOut, ref DSLocYOut, ref DSFlag, ref designationOut, ref locationOut, ref DSLocllXOut, ref DSLocllYOut);
                        DSName += DSNameOut + ",";
                        DSPwd += DSPwdOut + ",";
                        DSLocllX += DSLocllXOut + ",";
                        DSLocllY += DSLocllYOut + ",";
                        DSLocX += DSLocXOut + ",";
                        DSLocY += DSLocYOut + ",";
                        designation += designationOut + ",";
                        location += locationOut + ",";
                    }
                }
                else
                {
                    flagUser = true;
                    response.Write("ErrorOPS-" + Messages.DataNotFound);
                }
            }
            else if (USERXML.Length > 0)
            { 

            }
            if (!(lstUName.Contains(SAPuname.Trim())))
            {
                response.Write("ErrorOPS-" + Messages.SAPUserNotExist);
                return;

            }

            if (DSFlag == 1)
            {
                response.Write("ErrorOPS-" + Messages.UserNotExist);
                return;
            }
            string GuidString = Guid.NewGuid().ToString("N");
            string pdfInPath =  (ConfigurationManager.AppSettings["pdfInFolder"]) + "InPdf" + GuidString + "_" + DateTime.Now.ToString().Replace("-", "").Replace("/", "").Replace(" ", "").Replace(":", "") + ".pdf";
            string pdfOutPath =  (ConfigurationManager.AppSettings["pdfOutFolder"]) + "OutPdf" + GuidString + "_" + DateTime.Now.ToString().Replace("-", "").Replace("/", "").Replace(" ", "").Replace(":", "") + ".pdf";
            string inPdfFileHexStr = string.Empty;

            IVLDigiSignBusinessObjects.isPfxFile = (ConfigurationManager.AppSettings["isPfxFile"]);
            IVLDigiSignBusinessObjects.DesignationCaption = (ConfigurationManager.AppSettings["DesignationCaption"]);
            IVLDigiSignBusinessObjects.LocationCaption = (ConfigurationManager.AppSettings["LocationCaption"]);
            string pfxFilePath = Server.MapPath(ConfigurationManager.AppSettings["pfxFilePath"]);

            DriveInfo[] driveInfos = DriveInfo.GetDrives();

            string hexstr = "";
            
            string convertedHex = "";
            try
            {
               

                if (Doc.Length > 0)
                {
                    hexstr = Doc;
                }
                byte[] resultantArray = new byte[hexstr.Length / 2];
                for (int i = 0; i < resultantArray.Length; i++)
                {
                    resultantArray[i] = Convert.ToByte(hexstr.Substring(i * 2, 2), 16);
                }
                Doc = Convert.ToBase64String(resultantArray);
                byte[] bytes = Convert.FromBase64String(Doc);//hexstr
                File.WriteAllBytes(pdfInPath, bytes);
                
               
                Byte[] inPdfFileBytesArr = File.ReadAllBytes(pdfInPath);
                // pdfFileStr = Convert.ToBase64String(pdfFileBytesArr);
                string inPdfHex = BitConverter.ToString(inPdfFileBytesArr);
                inPdfFileHexStr = inPdfHex.Replace("-", "");

                 

                string[] signNames = DSName.Split(',');
                string[] passwords = DSPwd.Split(',');
                string[] DSLocllXArr = DSLocllX.Split(',');
                string[] DSLocllYArr = DSLocllY.Split(',');
                string[] DSLocXArr = DSLocX.Split(',');
                string[] DSLocYArr = DSLocY.Split(',');
                string[] SignTypArr = SignTyp.Split(',');
                string[] DesigArr = designation.Split(',');
                string[] LocArr = location.Split(',');
                int signFlag = 0;
                if (signNames.Length > 0)
                {
                    string TokenOrSlotLabel = "";
                    string CertificateName = "";
                    string TokenPin = "";
                    string cCode = "TEST";
                    IVLFileExtraction objIVLFileExtraction = new IVLFileExtraction();
                    objIVLFileExtraction.ExtractSignaturyDetails(cCode, ref TokenOrSlotLabel, ref CertificateName, ref TokenPin);
                    for (int i = 0; i < signNames.Length - 1; i++)
                    {
                        if (CertificateName != "")
                        {
                            IVLDigiSignBusinessObjects.UserName = CertificateName;//signNames[i]; //
                            IVLDigiSignBusinessObjects.Password = TokenPin;// passwords[i]; //
                        }
                        else
                        {
                            IVLDigiSignBusinessObjects.UserName = signNames[i];
                            IVLDigiSignBusinessObjects.Password = passwords[i];
                        }
                        IVLDigiSignBusinessObjects.LocllX = float.Parse(DSLocllXArr[i]);
                        IVLDigiSignBusinessObjects.LocllY = float.Parse(DSLocllYArr[i]);
                        IVLDigiSignBusinessObjects.LocX = float.Parse(DSLocXArr[i]);
                        IVLDigiSignBusinessObjects.LocY = float.Parse(DSLocYArr[i]);
                        IVLDigiSignBusinessObjects.SignType = SignTypArr[i];
                        IVLDigiSignBusinessObjects.Designation = DesigArr[i];
                        IVLDigiSignBusinessObjects.Location = LocArr[i];
 
 

                      
                        {
                          
                                IVLDigiSignBusinessObjects.SAPUserName = ConfigurationManager.AppSettings["signName"];
                                IVLDigiSignBusinessObjects.Location = ConfigurationManager.AppSettings["locationName"];

                          

                            string[] filePaths = Directory.GetFiles(Server.MapPath(ConfigurationManager.AppSettings["pfxFilePath"]));
                            CrXc.X509Certificate2 cert = null;
                            foreach (string fileName in filePaths)
                            {
                                cert = new CrXc.X509Certificate2(fileName, IVLDigiSignBusinessObjects.Password);
                                if (cert.GetName().Contains(IVLDigiSignBusinessObjects.UserName))
                                {
                                    objIvlDigiSign.SignWithThisCert(cert, pdfInPath, ref pdfOutPath, Rfskey);
                                    signFlag = 0;
                                }
                                else
                                {
                                    signFlag = 4;
                                }

                            }
                        }
                    }
                }
                else
                {
                    ErrMsg.CreateLogFile("ErrorOPS-", Messages.SignatureNotFound, "", "");
                    response.Write(inPdfFileHexStr);
                    return;
                }
                if (signFlag == 1)
                {
                    ErrMsg.CreateLogFile("ErrorOPS-", Messages.UserNotExist, "", "");
                    response.Write(inPdfFileHexStr);
                    return;
                }
                else if (signFlag == 2)
                {
                    ErrMsg.CreateLogFile("ErrorOPS-", Messages.DeviceNotFound, "", "");
                    response.Write(inPdfFileHexStr);
                    return;
                }
                else if (signFlag == 3)
                {
                    ErrMsg.CreateLogFile("ErrorOPS-", Messages.WrongPassword, "", "");
                    response.Write("ErrorOPS-" + Messages.WrongPassword);
                   
                    return;
                }
                else if (signFlag == 4)
                {
                    ErrMsg.CreateLogFile("ErrorOPS-", Messages.CertificateNotFound, "", "");

                    response.Write(inPdfFileHexStr);
                    return;
                }
                else if (signFlag == 5)
                {
                    ErrMsg.CreateLogFile("ErrorOPS-", Messages.WrongFile, "", "");
                    response.Write(inPdfFileHexStr);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrMsg.CreateLogFile("eSignWebService", "GetSignedDoc1", ex.Message, "");
            }

            try
            {
                byte[] pdfDataArray2 = System.IO.File.ReadAllBytes(pdfOutPath);
                string certString2 = Convert.ToBase64String(pdfDataArray2);

                byte[] bytes12 = Convert.FromBase64String(certString2);
                string hex = BitConverter.ToString(bytes12);
                convertedHex = hex.Replace("-", "");

               
            }
            catch (Exception ex)
            {
                ErrMsg.CreateLogFile("eSignWebService", "GetSignedDoc2 : Convert signed pdf to Hex", ex.Message, "");
                ErrMsg.CreateLogFile("ErrorOPS-", Messages.WrongFile,"", "");
               // response.Write(inPdfFileHexStr);
            }
            response.Write(convertedHex);
        }
          

    }
}