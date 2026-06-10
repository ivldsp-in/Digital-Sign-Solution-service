using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvlDigiSignWebApp.Common
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DigitalSignatureMaster
    {

        private DigitalSignatureMasterDigitalSignatureDetails[] digitalSignatureDetailsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DigitalSignatureDetails")]
        public DigitalSignatureMasterDigitalSignatureDetails[] DigitalSignatureDetails
        {
            get
            {
                return this.digitalSignatureDetailsField;
            }
            set
            {
                this.digitalSignatureDetailsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DigitalSignatureMasterDigitalSignatureDetails
    {

        private DigitalSignatureMasterDigitalSignatureDetailsDigitalSignature digitalSignatureField;

        private DigitalSignatureMasterDigitalSignatureDetailsIssuer issuerField;

        private string dSIdField;

        private string userIdField;

        /// <remarks/>
        public DigitalSignatureMasterDigitalSignatureDetailsDigitalSignature DigitalSignature
        {
            get
            {
                return this.digitalSignatureField;
            }
            set
            {
                this.digitalSignatureField = value;
            }
        }

        /// <remarks/>
        public DigitalSignatureMasterDigitalSignatureDetailsIssuer Issuer
        {
            get
            {
                return this.issuerField;
            }
            set
            {
                this.issuerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DSId
        {
            get
            {
                return this.dSIdField;
            }
            set
            {
                this.dSIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UserId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DigitalSignatureMasterDigitalSignatureDetailsDigitalSignature
    {

        private uint digntalSignatureOriginalIdField;

        private string oNameField;

        private string sPINField;

        private string oPlaceField;

        private string oAddressField;

        private uint oPinCodeField;

        private string oStateField;

        private string oCountryField;

        private string oOrgNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint DigntalSignatureOriginalId
        {
            get
            {
                return this.digntalSignatureOriginalIdField;
            }
            set
            {
                this.digntalSignatureOriginalIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OName
        {
            get
            {
                return this.oNameField;
            }
            set
            {
                this.oNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SPIN
        {
            get
            {
                return this.sPINField;
            }
            set
            {
                this.sPINField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OPlace
        {
            get
            {
                return this.oPlaceField;
            }
            set
            {
                this.oPlaceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OAddress
        {
            get
            {
                return this.oAddressField;
            }
            set
            {
                this.oAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint OPinCode
        {
            get
            {
                return this.oPinCodeField;
            }
            set
            {
                this.oPinCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OState
        {
            get
            {
                return this.oStateField;
            }
            set
            {
                this.oStateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OCountry
        {
            get
            {
                return this.oCountryField;
            }
            set
            {
                this.oCountryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OOrgName
        {
            get
            {
                return this.oOrgNameField;
            }
            set
            {
                this.oOrgNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DigitalSignatureMasterDigitalSignatureDetailsIssuer
    {

        private string iNameField;

        private string iPlaceField;

        private string iAddressField;

        private uint iPinCodeField;

        private string iStateField;

        private string iCountryField;

        private string iOrgNameField;

        private string iOrgUnitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IName
        {
            get
            {
                return this.iNameField;
            }
            set
            {
                this.iNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IPlace
        {
            get
            {
                return this.iPlaceField;
            }
            set
            {
                this.iPlaceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IAddress
        {
            get
            {
                return this.iAddressField;
            }
            set
            {
                this.iAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint IPinCode
        {
            get
            {
                return this.iPinCodeField;
            }
            set
            {
                this.iPinCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IState
        {
            get
            {
                return this.iStateField;
            }
            set
            {
                this.iStateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ICountry
        {
            get
            {
                return this.iCountryField;
            }
            set
            {
                this.iCountryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IOrgName
        {
            get
            {
                return this.iOrgNameField;
            }
            set
            {
                this.iOrgNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IOrgUnit
        {
            get
            {
                return this.iOrgUnitField;
            }
            set
            {
                this.iOrgUnitField = value;
            }
        }
    }




}