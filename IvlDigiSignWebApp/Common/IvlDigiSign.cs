 
using iTextSharp.text.pdf; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO; 
using System.Web;
using B = Org.BouncyCastle.X509;  
using CrXc = System.Security.Cryptography.X509Certificates;

namespace IvlDigiSignWebApp.Common
{
    public class IvlDigiSign
    {
        ErrorMessage ErrMsg = new ErrorMessage();
         
        public void SignWithThisCert(CrXc.X509Certificate2 cert, string SourcePdfFileName,ref string DestPdfFileName, string Rfskey)
        {
            try
            {
                // Individual pdf page sign  with tick image
                string isPhysicalSign = ConfigurationManager.AppSettings["isPhysicalSign"];
                //Individual pdf page sign with out image
                string isIndividualSign = ConfigurationManager.AppSettings["isIndividualSign"];
                string GuidStringSplit = Guid.NewGuid().ToString("N");
                string pdfInPathSplit = (ConfigurationManager.AppSettings["pdfInFolder"]) + "InPdfSplit_"+ GuidStringSplit + DateTime.Now.ToString().Replace("-", "").Replace("/", "").Replace(" ", "").Replace(":", "") + ".pdf";
                string showhideSignDetails = (ConfigurationManager.AppSettings["showhideSignDetails"]);
                PdfReader pdfSrcReader = new PdfReader(SourcePdfFileName);
                // Get existing PDF metadata
                Dictionary<string, string> info = pdfSrcReader.Info;
                byte[] originalXmp = pdfSrcReader.Metadata;
                 
                B.X509CertificateParser cp = new B.X509CertificateParser();
                B.X509Certificate[] chain = new B.X509Certificate[] { cp.ReadCertificate(cert.RawData) };

                iTextSharp.text.pdf.security.IExternalSignature externalSignature = new iTextSharp.text.pdf.security.X509Certificate2Signature(cert, "SHA-1");
                
                PdfReader pdfReader = new PdfReader(pdfInPathSplit);
               
                FileStream signedPdf = new FileStream(DestPdfFileName, FileMode.OpenOrCreate);  //the output pdf file
                PdfStamper pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdf, '\0', null, true);
                PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
                //here set signatureAppearance at your will

                if (showhideSignDetails == "true")
                {
                    signatureAppearance.ReasonCaption = IVLDigiSignBusinessObjects.DesignationCaption + " : ";
                    signatureAppearance.LocationCaption = IVLDigiSignBusinessObjects.LocationCaption + " : ";
                    if (IVLDigiSignBusinessObjects.isPfxFile == "false")
                    {
                        signatureAppearance.Reason = IVLDigiSignBusinessObjects.Designation;
                    }
                    else
                    {
                        signatureAppearance.Reason = IVLDigiSignBusinessObjects.SAPUserName;
                    }
                    signatureAppearance.Location = IVLDigiSignBusinessObjects.Location;
                }

                signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;  
                signatureAppearance.Acro6Layers = false;
                signatureAppearance.Layer4Text = PdfSignatureAppearance.questionMark;
                signatureAppearance.Certificate = chain[0];
                iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(IVLDigiSignBusinessObjects.LocllX, IVLDigiSignBusinessObjects.LocllY, IVLDigiSignBusinessObjects.LocX, IVLDigiSignBusinessObjects.LocY);
                 
                {

                    signatureAppearance.SetVisibleSignature(rect, 1, "Signature" + IVLDigiSignBusinessObjects.UserName + DateTime.Now);
                    AllPagesSignatureContainer allPagesContainer = new AllPagesSignatureContainer(signatureAppearance, externalSignature, chain, rect);
                    iTextSharp.text.pdf.security.MakeSignature.SignExternalContainer(signatureAppearance, allPagesContainer, 8192);

                    pdfStamper.Close();
                }
                

                signedPdf.Close();
                pdfReader.Close();

                
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }
          
 
    }
}