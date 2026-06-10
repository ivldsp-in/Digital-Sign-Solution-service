using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvlDigiSignWebApp.Common
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sap.com/abapxml")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sap.com/abapxml", IsNullable = false)]
    public partial class abap
    {

        private abapValues valuesField;

        private decimal versionField;

        /// <remarks/>
        public abapValues values
        {
            get
            {
                return this.valuesField;
            }
            set
            {
                this.valuesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sap.com/abapxml")]
    public partial class abapValues
    {

        private ROOT rOOTField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public ROOT ROOT
        {
            get
            {
                return this.rOOTField;
            }
            set
            {
                this.rOOTField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ROOT
    {

        private ROOT_BRI_OPS_USRSIGN _BRI_OPS_USRSIGNField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("_-BRI_-OPS_USRSIGN")]
        public ROOT_BRI_OPS_USRSIGN _BRI_OPS_USRSIGN
        {
            get
            {
                return this._BRI_OPS_USRSIGNField;
            }
            set
            {
                this._BRI_OPS_USRSIGNField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ROOT_BRI_OPS_USRSIGN
    {

        private string uSERIDField;

        private string uTYPField;

        private string uNAMEField;

        private string pRMIDField;

        private string dNGIDField;

        private string dNGSTField;

        private string sEMAILField;

        private string sIGNTYPField;

        /// <remarks/>
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
        public string PRMID
        {
            get
            {
                return this.pRMIDField;
            }
            set
            {
                this.pRMIDField = value;
            }
        }

        /// <remarks/>
        public string DNGID
        {
            get
            {
                return this.dNGIDField;
            }
            set
            {
                this.dNGIDField = value;
            }
        }

        /// <remarks/>
        public string DNGST
        {
            get
            {
                return this.dNGSTField;
            }
            set
            {
                this.dNGSTField = value;
            }
        }

        /// <remarks/>
        public string SEMAIL
        {
            get
            {
                return this.sEMAILField;
            }
            set
            {
                this.sEMAILField = value;
            }
        }

        /// <remarks/>
        public string SIGNTYP
        {
            get
            {
                return this.sIGNTYPField;
            }
            set
            {
                this.sIGNTYPField = value;
            }
        }
    }


}