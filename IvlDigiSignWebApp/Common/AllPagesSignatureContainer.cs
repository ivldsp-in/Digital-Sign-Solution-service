using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IvlDigiSignWebApp.Common
{
    public class AllPagesSignatureContainer: IExternalSignatureContainer
    {
        public AllPagesSignatureContainer(PdfSignatureAppearance appearance, IExternalSignature externalSignature, ICollection<X509Certificate> chain, iTextSharp.text.Rectangle rect)
        {
            this.appearance = appearance;
            this.chain = chain;
            this.externalSignature = externalSignature;
            this.rect = rect;
        }

        public void ModifySigningDictionary(PdfDictionary signDic)
        {
            int pageCount = appearance.Page;

            signDic.Put(PdfName.FILTER, PdfName.ADOBE_PPKMS);
            signDic.Put(PdfName.SUBFILTER, PdfName.ADBE_PKCS7_DETACHED);

            PdfStamper stamper = appearance.Stamper;
            PdfReader reader = stamper.Reader;
            PdfDictionary xobject1 = new PdfDictionary();
            PdfDictionary xobject2 = new PdfDictionary();
            xobject1.Put(PdfName.N, appearance.GetAppearance().IndirectReference);
            xobject2.Put(PdfName.AP, xobject1);

            PdfIndirectReference PRef = stamper.Writer.PdfIndirectReference;
            PdfLiteral PRefLiteral = new PdfLiteral((PRef.Number + 1 + 2 * (pageCount - 1)) + " 0 R"); //reader.NumberOfPages



            for (int i = 1; i <= pageCount; i++) //
            {
                var signatureField = PdfFormField.CreateSignature(stamper.Writer);

                signatureField.Put(PdfName.T, new PdfString("ClientSignature_" + i.ToString()));
                signatureField.Put(PdfName.V, PRefLiteral);
                signatureField.Put(PdfName.F, new PdfNumber("132"));
                signatureField.SetWidget(rect, null);
                signatureField.Put(PdfName.SUBTYPE, PdfName.WIDGET);

                signatureField.Put(PdfName.AP, xobject1);
                signatureField.SetPage();
                Console.WriteLine(signatureField);

                stamper.AddAnnotation(signatureField, i);
            }
        }

        public byte[] Sign(Stream data)
        {

            String hashAlgorithm = externalSignature.GetHashAlgorithm();
            PdfPKCS7 sgn = new PdfPKCS7(null, chain, hashAlgorithm, true);
            Org.BouncyCastle.Crypto.IDigest messageDigest = DigestUtilities.GetDigest(hashAlgorithm);
            byte[] hash = DigestAlgorithms.Digest(data, hashAlgorithm);
            byte[] sh = sgn.getAuthenticatedAttributeBytes(hash, null, null, CryptoStandard.CMS);
            byte[] extSignature = externalSignature.Sign(sh);
            sgn.SetExternalDigest(extSignature, null, externalSignature.GetEncryptionAlgorithm());
            return sgn.GetEncodedPKCS7(hash, null, null, null, CryptoStandard.CMS);
        }

        PdfSignatureAppearance appearance;
        ICollection<X509Certificate> chain;
        IExternalSignature externalSignature;
        iTextSharp.text.Rectangle rect;

    }
}