using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvlDigiSignWebApp.Common
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class SignaturyDetails
    {

        private SignaturyDetailsSignCategory[] signCategoryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SignCategory")]
        public SignaturyDetailsSignCategory[] SignCategory
        {
            get
            {
                return this.signCategoryField;
            }
            set
            {
                this.signCategoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SignaturyDetailsSignCategory
    {

        private string companyCodeField;

        private string tokenOrSlotLabelField;

        private string tokenOrSlotPinField;

        private string certificateOrKeyLabelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CompanyCode
        {
            get
            {
                return this.companyCodeField;
            }
            set
            {
                this.companyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TokenOrSlotLabel
        {
            get
            {
                return this.tokenOrSlotLabelField;
            }
            set
            {
                this.tokenOrSlotLabelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TokenOrSlotPin
        {
            get
            {
                return this.tokenOrSlotPinField;
            }
            set
            {
                this.tokenOrSlotPinField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CertificateOrKeyLabel
        {
            get
            {
                return this.certificateOrKeyLabelField;
            }
            set
            {
                this.certificateOrKeyLabelField = value;
            }
        }
    }



}