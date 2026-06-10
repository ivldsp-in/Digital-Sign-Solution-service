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
    public partial class DocParamUserDigiSignMapping
    {

        private DocParamUserDigiSignMappingParameterMappingDetails[] parameterMappingDetailsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ParameterMappingDetails")]
        public DocParamUserDigiSignMappingParameterMappingDetails[] ParameterMappingDetails
        {
            get
            {
                return this.parameterMappingDetailsField;
            }
            set
            {
                this.parameterMappingDetailsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DocParamUserDigiSignMappingParameterMappingDetails
    {

        private DocParamUserDigiSignMappingParameterMappingDetailsDigiSignMappingDetails digiSignMappingDetailsField;

        private DocParamUserDigiSignMappingParameterMappingDetailsSignLocation signLocationField;

        /// <remarks/>
        public DocParamUserDigiSignMappingParameterMappingDetailsDigiSignMappingDetails DigiSignMappingDetails
        {
            get
            {
                return this.digiSignMappingDetailsField;
            }
            set
            {
                this.digiSignMappingDetailsField = value;
            }
        }

        /// <remarks/>
        public DocParamUserDigiSignMappingParameterMappingDetailsSignLocation SignLocation
        {
            get
            {
                return this.signLocationField;
            }
            set
            {
                this.signLocationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DocParamUserDigiSignMappingParameterMappingDetailsDigiSignMappingDetails
    {

        private string docIdField;

        private ushort parameterIdField;

        private string userIdField;

        private string dSIdField;

        private string docSignedTypeField;

        private string serverIdField;

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
        public ushort ParameterId
        {
            get
            {
                return this.parameterIdField;
            }
            set
            {
                this.parameterIdField = value;
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
        public string DocSignedType
        {
            get
            {
                return this.docSignedTypeField;
            }
            set
            {
                this.docSignedTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ServerId
        {
            get
            {
                return this.serverIdField;
            }
            set
            {
                this.serverIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DocParamUserDigiSignMappingParameterMappingDetailsSignLocation
    {

        private ushort llxAxisField;

        private byte llyAxisField;

        private ushort xAxisField;

        private byte yAxisField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort llxAxis
        {
            get
            {
                return this.llxAxisField;
            }
            set
            {
                this.llxAxisField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte llyAxis
        {
            get
            {
                return this.llyAxisField;
            }
            set
            {
                this.llyAxisField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort xAxis
        {
            get
            {
                return this.xAxisField;
            }
            set
            {
                this.xAxisField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte yAxis
        {
            get
            {
                return this.yAxisField;
            }
            set
            {
                this.yAxisField = value;
            }
        }
    }





}