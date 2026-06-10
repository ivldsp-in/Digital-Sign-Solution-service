using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using System.Xml.Serialization;

namespace IvlDigiSignWebApp.Common
{

    public class IVLFileExtraction
    {
        DigitalSignatureMaster ObjDigitalSignatureMaster = new DigitalSignatureMaster();
        DocParamUserDigiSignMapping ObjDocParamUserDigiSignMapping = new DocParamUserDigiSignMapping();

        UserMaster ObjUserMaster = new UserMaster();


        public void ReadIvlFileToIvlClass(string DocId, string ParameterId, string UserId, string DSId, ref string DSName,
                                                ref string DSPwd, ref string DSLocX, ref string DSLocY, ref int DSFlag, ref string designation, ref string location, ref string DSLocllX, ref string DSLocllY)
        {

            using (StreamReader DSMasterReader = new StreamReader(HttpContext.Current.Server.MapPath("DataFiles//xmlDigitalSignatureMaster.xml")))
            {
                XmlSerializer xmlReader = new XmlSerializer(typeof(DigitalSignatureMaster));
                ObjDigitalSignatureMaster = (DigitalSignatureMaster)xmlReader.Deserialize(DSMasterReader);
            }
            using (StreamReader DSParameterUserMappingReader = new StreamReader(HttpContext.Current.Server.MapPath("DataFiles//xmlDocumentParameterUserDigitalSignatureMapping.xml")))
            {
                XmlSerializer xmlReader = new XmlSerializer(typeof(DocParamUserDigiSignMapping));
                ObjDocParamUserDigiSignMapping = (DocParamUserDigiSignMapping)xmlReader.Deserialize(DSParameterUserMappingReader);
            }

                using (StreamReader UserMasterReader = new StreamReader(HttpContext.Current.Server.MapPath("DataFiles//xmlUserMaster.xml")))
                {
                    XmlSerializer xmlReader = new XmlSerializer(typeof(UserMaster));
                    ObjUserMaster = (UserMaster)xmlReader.Deserialize(UserMasterReader);
                }

            if (ObjDocParamUserDigiSignMapping.ParameterMappingDetails.Count() > 0)
            {
                for (int i = 0; i < ObjDocParamUserDigiSignMapping.ParameterMappingDetails.Count(); i++)
                {
                    if (ObjDocParamUserDigiSignMapping.ParameterMappingDetails[i].DigiSignMappingDetails.DocId == DocId
                        && ObjDocParamUserDigiSignMapping.ParameterMappingDetails[i].DigiSignMappingDetails.UserId == UserId
                         && ObjDocParamUserDigiSignMapping.ParameterMappingDetails[i].DigiSignMappingDetails.DSId == DSId)
                    {
                        DSLocllX = Convert.ToString(ObjDocParamUserDigiSignMapping.ParameterMappingDetails[i].SignLocation.llxAxis);
                        DSLocllY = Convert.ToString(ObjDocParamUserDigiSignMapping.ParameterMappingDetails[i].SignLocation.llyAxis);

                        DSLocX = Convert.ToString(ObjDocParamUserDigiSignMapping.ParameterMappingDetails[i].SignLocation.xAxis);
                        DSLocY = Convert.ToString(ObjDocParamUserDigiSignMapping.ParameterMappingDetails[i].SignLocation.yAxis);

                        DSFlag = 0;
                    }
                }
            }

            if (ObjUserMaster.User.Count() > 0)
            {
                for (int i = 0; i < ObjUserMaster.User.Count(); i++)
                {
                    if (ObjUserMaster.User[i].USERID.ToString() == UserId
                        && ObjUserMaster.User[i].DocId.ToString() == DocId)
                    {
                        designation = ObjUserMaster.User[i].Designation;
                        location = ObjUserMaster.User[i].Location;
                        DSFlag = 0;
                    }

                }
            }

            if (ObjDigitalSignatureMaster.DigitalSignatureDetails.Count() > 0)
            {
                for (int i = 0; i < ObjDigitalSignatureMaster.DigitalSignatureDetails.Count(); i++)
                {
                    if (ObjDigitalSignatureMaster.DigitalSignatureDetails[i].UserId.ToString() == UserId
                        && ObjDigitalSignatureMaster.DigitalSignatureDetails[i].DSId.ToString() == DSId)
                    {
                        DSName = ObjDigitalSignatureMaster.DigitalSignatureDetails[i].DigitalSignature.OName;
                        DSPwd = ObjDigitalSignatureMaster.DigitalSignatureDetails[i].DigitalSignature.SPIN;
                        DSFlag = 0;
                    }

                }
            }
        }



        public void ExtractSignaturyDetails(string CompanyCode, ref string TokenOrSlotLabel, ref string CertificateOrKeyLabel, ref string TokenOrSlotPin)
        {
            try
            {

                SignaturyDetails ObjSignaturyDetails = new SignaturyDetails();
                using (StreamReader DSSignaturyMasterReader = new StreamReader(HttpContext.Current.Server.MapPath("DataFiles//xmlSingaturyMapping.xml")))
                {
                    XmlSerializer xmlReader = new XmlSerializer(typeof(SignaturyDetails));
                    ObjSignaturyDetails = (SignaturyDetails)xmlReader.Deserialize(DSSignaturyMasterReader);
                }
                if (ObjSignaturyDetails.SignCategory.Length > 0)
                {
                    for (int i = 0; i < ObjSignaturyDetails.SignCategory.Length; i++)
                    {
                        if (ObjSignaturyDetails.SignCategory[i].CompanyCode.ToString() == CompanyCode)
                        {
                            TokenOrSlotLabel = ObjSignaturyDetails.SignCategory[i].TokenOrSlotLabel;
                            CertificateOrKeyLabel = ObjSignaturyDetails.SignCategory[i].CertificateOrKeyLabel;
                            TokenOrSlotPin = ObjSignaturyDetails.SignCategory[i].TokenOrSlotPin;

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }



    }
}