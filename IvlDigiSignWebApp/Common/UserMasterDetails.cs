using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvlDigiSignWebApp.Common
{



    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class UserMaster
    {

        private UserMasterUser[] userField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("User")]
        public UserMasterUser[] User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class UserMasterUser
    {

        private string docIdField;

        private string uSERIDField;

        private string uNAMEField;

        private string designationField;

        private string locationField;

        private string uTYPField;

        private string countryField;

        private string stateField;

        private uint pinCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DocId
        {
            get
            {
                return this.docIdField;
            }
            set
            {
                this.docIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string USERID
        {
            get
            {
                return this.uSERIDField;
            }
            set
            {
                this.uSERIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UNAME
        {
            get
            {
                return this.uNAMEField;
            }
            set
            {
                this.uNAMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Designation
        {
            get
            {
                return this.designationField;
            }
            set
            {
                this.designationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UTYP
        {
            get
            {
                return this.uTYPField;
            }
            set
            {
                this.uTYPField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint PinCode
        {
            get
            {
                return this.pinCodeField;
            }
            set
            {
                this.pinCodeField = value;
            }
        }
    }




}