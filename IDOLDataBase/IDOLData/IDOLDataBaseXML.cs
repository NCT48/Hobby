using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using IDOLDataBase;
using Utf8Json;

namespace IDOLData.Derera
{
    public static class IDOLDataBaseXML
    {
        public static RDF RDFData { get; }


        static IDOLDataBaseXML()
        {
            var xmlSerializer1 = new XmlSerializer(typeof(RDF));
            var xmlSettings = new System.Xml.XmlReaderSettings() {
                CheckCharacters = false, // （2）
            };
            using (var streamReader = new StreamReader(@"Resources\c.xml", Encoding.UTF8))
            using (var xmlReader = System.Xml.XmlReader.Create(streamReader, xmlSettings))
            {
                RDFData = (RDF)xmlSerializer1.Deserialize(xmlReader); // （3）
            }
        }
    }

    // メモ: 生成されたコードは、少なくとも .NET Framework 4.5または .NET Core/Standard 2.0 が必要な可能性があります。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    [XmlRoot(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", IsNullable = false)]
    public partial class RDF
    {

        private RDFDescription[] descriptionField;

        /// <remarks/>
        [XmlElement("Description")]
        public RDFDescription[] Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescription
    {

        private object[] itemsField;

        private string aboutField;

        /// <remarks/>
        [XmlElement("birthDate", typeof(birthDate), Namespace = "http://schema.org/")]
        [XmlElement("birthPlace", typeof(birthPlace), Namespace = "http://schema.org/")]
        [XmlElement("familyName", typeof(familyName), Namespace = "http://schema.org/")]
        [XmlElement("gender", typeof(gender), Namespace = "http://schema.org/")]
        [XmlElement("givenName", typeof(givenName), Namespace = "http://schema.org/")]
        [XmlElement("height", typeof(height), Namespace = "http://schema.org/")]
        [XmlElement("name", typeof(name), Namespace = "http://schema.org/")]
        [XmlElement("weight", typeof(weight), Namespace = "http://schema.org/")]
        [XmlElement("type", typeof(RDFDescriptionType))]
        [XmlElement("label", typeof(label), Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
        [XmlElement("age", typeof(age), Namespace = "http://xmlns.com/foaf/0.1/")]
        [XmlElement("BloodType", typeof(BloodType), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Bust", typeof(Bust), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Color", typeof(Color), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Constellation", typeof(Constellation), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Handedness", typeof(Handedness), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hip", typeof(Hip), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hobby", typeof(Hobby), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Title", typeof(Title), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Type", typeof(Type), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Waist", typeof(Waist), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("cv", typeof(cv), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("familyNameKana", typeof(familyNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("givenNameKana", typeof(givenNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("nameKana", typeof(nameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string about
        {
            get
            {
                return this.aboutField;
            }
            set
            {
                this.aboutField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthDate
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthPlace
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class familyName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class gender
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class givenName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class height
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class name
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class weight
    {

        private string datatypeField;

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescriptionType
    {

        private string resourceField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
    [XmlRoot(Namespace = "http://www.w3.org/2000/01/rdf-schema#", IsNullable = false)]
    public partial class label
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://xmlns.com/foaf/0.1/")]
    [XmlRoot(Namespace = "http://xmlns.com/foaf/0.1/", IsNullable = false)]
    public partial class age
    {

        private string datatypeField;

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class BloodType
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Bust
    {

        private string datatypeField;

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Color
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Constellation
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Handedness
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hip
    {

        private string datatypeField;

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hobby
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Title
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Type
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Waist
    {

        private string datatypeField;

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class cv
    {

        private string langField;

        private string resourceField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class familyNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class givenNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class nameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
namespace IDOLData.Mili
{
    public static class IDOLDataBaseXML
    {
        public static RDF RDFData { get; }


        static IDOLDataBaseXML()
        {
            var xmlSerializer1 = new XmlSerializer(typeof(RDF));
            var xmlSettings = new System.Xml.XmlReaderSettings() {
                CheckCharacters = false, // （2）
            };
            using (var streamReader = new StreamReader(@"Resources\m.xml", Encoding.UTF8))
            using (var xmlReader = System.Xml.XmlReader.Create(streamReader, xmlSettings))
            {
                RDFData = (RDF)xmlSerializer1.Deserialize(xmlReader); // （3）
            }
        }
    }

    // メモ: 生成されたコードは、少なくとも .NET Framework 4.5または .NET Core/Standard 2.0 が必要な可能性があります。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    [XmlRoot(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", IsNullable = false)]
    public partial class RDF
    {

        private RDFDescription[] descriptionField;

        /// <remarks/>
        [XmlElement("Description")]
        public RDFDescription[] Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescription
    {

        private object[] itemsField;

        private string aboutField;

        /// <remarks/>
        [XmlElement("alternateName", typeof(alternateName), Namespace = "http://schema.org/")]
        [XmlElement("birthDate", typeof(birthDate), Namespace = "http://schema.org/")]
        [XmlElement("birthPlace", typeof(birthPlace), Namespace = "http://schema.org/")]
        [XmlElement("familyName", typeof(familyName), Namespace = "http://schema.org/")]
        [XmlElement("gender", typeof(gender), Namespace = "http://schema.org/")]
        [XmlElement("givenName", typeof(givenName), Namespace = "http://schema.org/")]
        [XmlElement("height", typeof(height), Namespace = "http://schema.org/")]
        [XmlElement("name", typeof(name), Namespace = "http://schema.org/")]
        [XmlElement("weight", typeof(weight), Namespace = "http://schema.org/")]
        [XmlElement("type", typeof(RDFDescriptionType))]
        [XmlElement("label", typeof(label), Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
        [XmlElement("age", typeof(age), Namespace = "http://xmlns.com/foaf/0.1/")]
        [XmlElement("Attribute", typeof(Attribute), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("BloodType", typeof(BloodType), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Bust", typeof(Bust), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Color", typeof(Color), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Constellation", typeof(Constellation), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Division", typeof(Division), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Favorite", typeof(Favorite), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Handedness", typeof(Handedness), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hip", typeof(Hip), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hobby", typeof(Hobby), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Talent", typeof(Talent), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Title", typeof(Title), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Waist", typeof(Waist), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("alternateNameKana", typeof(alternateNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("cv", typeof(cv), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("familyNameKana", typeof(familyNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("givenNameKana", typeof(givenNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("nameKana", typeof(nameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string about
        {
            get
            {
                return this.aboutField;
            }
            set
            {
                this.aboutField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class alternateName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthDate
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthPlace
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class familyName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class gender
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class givenName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class height
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class name
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class weight
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescriptionType
    {

        private string resourceField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
    [XmlRoot(Namespace = "http://www.w3.org/2000/01/rdf-schema#", IsNullable = false)]
    public partial class label
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://xmlns.com/foaf/0.1/")]
    [XmlRoot(Namespace = "http://xmlns.com/foaf/0.1/", IsNullable = false)]
    public partial class age
    {

        private string datatypeField;

        private byte valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Attribute
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class BloodType
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Bust
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Color
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Constellation
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Division
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Favorite
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Handedness
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hip
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hobby
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Talent
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Title
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Waist
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class alternateNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class cv
    {

        private string langField;

        private string resourceField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class familyNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class givenNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class nameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
namespace IDOLData.AS
{
    public static class IDOLDataBaseXML
    {
        public static RDF RDFData { get; }


        static IDOLDataBaseXML()
        {
            var xmlSerializer1 = new XmlSerializer(typeof(RDF));
            var xmlSettings = new System.Xml.XmlReaderSettings() {
                CheckCharacters = false, // （2）
            };
            using (var streamReader = new StreamReader(@"Resources\a.xml", Encoding.UTF8))
            using (var xmlReader = System.Xml.XmlReader.Create(streamReader, xmlSettings))
            {
                RDFData = (RDF)xmlSerializer1.Deserialize(xmlReader); // （3）
            }
        }
    }

    // メモ: 生成されたコードは、少なくとも .NET Framework 4.5または .NET Core/Standard 2.0 が必要な可能性があります。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    [XmlRoot(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", IsNullable = false)]
    public partial class RDF
    {

        private RDFDescription[] descriptionField;

        /// <remarks/>
        [XmlElement("Description")]
        public RDFDescription[] Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescription
    {

        private object[] itemsField;

        private string aboutField;

        /// <remarks/>
        [XmlElement("birthDate", typeof(birthDate), Namespace = "http://schema.org/")]
        [XmlElement("birthPlace", typeof(birthPlace), Namespace = "http://schema.org/")]
        [XmlElement("familyName", typeof(familyName), Namespace = "http://schema.org/")]
        [XmlElement("gender", typeof(gender), Namespace = "http://schema.org/")]
        [XmlElement("givenName", typeof(givenName), Namespace = "http://schema.org/")]
        [XmlElement("height", typeof(height), Namespace = "http://schema.org/")]
        [XmlElement("name", typeof(name), Namespace = "http://schema.org/")]
        [XmlElement("weight", typeof(weight), Namespace = "http://schema.org/")]
        [XmlElement("type", typeof(RDFDescriptionType))]
        [XmlElement("label", typeof(label), Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
        [XmlElement("age", typeof(age), Namespace = "http://xmlns.com/foaf/0.1/")]
        [XmlElement("Attribute", typeof(Attribute), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("BloodType", typeof(BloodType), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Bust", typeof(Bust), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Color", typeof(Color), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Constellation", typeof(Constellation), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Division", typeof(Division), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Favorite", typeof(Favorite), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Handedness", typeof(Handedness), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hip", typeof(Hip), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hobby", typeof(Hobby), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Talent", typeof(Talent), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Title", typeof(Title), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Waist", typeof(Waist), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("cv", typeof(cv), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("familyNameKana", typeof(familyNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("givenNameKana", typeof(givenNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("nameKana", typeof(nameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string about
        {
            get
            {
                return this.aboutField;
            }
            set
            {
                this.aboutField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthDate
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthPlace
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class familyName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class gender
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class givenName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class height
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class name
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class weight
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescriptionType
    {

        private string resourceField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
    [XmlRoot(Namespace = "http://www.w3.org/2000/01/rdf-schema#", IsNullable = false)]
    public partial class label
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://xmlns.com/foaf/0.1/")]
    [XmlRoot(Namespace = "http://xmlns.com/foaf/0.1/", IsNullable = false)]
    public partial class age
    {

        private string datatypeField;

        private byte valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Attribute
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class BloodType
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Bust
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Color
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Constellation
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Division
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Favorite
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Handedness
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hip
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hobby
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Talent
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Title
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Waist
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class cv
    {

        private string langField;

        private string resourceField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class familyNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class givenNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class nameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
namespace IDOLData.Shani
{
    public static class IDOLDataBaseXML
    {
        public static RDF RDFData { get; }


        static IDOLDataBaseXML()
        {
            var xmlSerializer1 = new XmlSerializer(typeof(RDF));
            var xmlSettings = new System.Xml.XmlReaderSettings() {
                CheckCharacters = false, // （2）
            };
            using (var streamReader = new StreamReader(@"Resources\s.xml", Encoding.UTF8))
            using (var xmlReader = System.Xml.XmlReader.Create(streamReader, xmlSettings))
            {
                RDFData = (RDF)xmlSerializer1.Deserialize(xmlReader); // （3）
            }
        }
    }

    // メモ: 生成されたコードは、少なくとも .NET Framework 4.5または .NET Core/Standard 2.0 が必要な可能性があります。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    [XmlRoot(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", IsNullable = false)]
    public partial class RDF
    {

        private RDFDescription[] descriptionField;

        /// <remarks/>
        [XmlElement("Description")]
        public RDFDescription[] Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescription
    {

        private object[] itemsField;

        private string aboutField;

        /// <remarks/>
        [XmlElement("birthDate", typeof(birthDate), Namespace = "http://schema.org/")]
        [XmlElement("birthPlace", typeof(birthPlace), Namespace = "http://schema.org/")]
        [XmlElement("description", typeof(description), Namespace = "http://schema.org/")]
        [XmlElement("familyName", typeof(familyName), Namespace = "http://schema.org/")]
        [XmlElement("gender", typeof(gender), Namespace = "http://schema.org/")]
        [XmlElement("givenName", typeof(givenName), Namespace = "http://schema.org/")]
        [XmlElement("height", typeof(height), Namespace = "http://schema.org/")]
        [XmlElement("name", typeof(name), Namespace = "http://schema.org/")]
        [XmlElement("weight", typeof(weight), Namespace = "http://schema.org/")]
        [XmlElement("type", typeof(RDFDescriptionType))]
        [XmlElement("label", typeof(label), Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
        [XmlElement("age", typeof(age), Namespace = "http://xmlns.com/foaf/0.1/")]
        [XmlElement("BloodType", typeof(BloodType), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Bust", typeof(Bust), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Color", typeof(Color), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Constellation", typeof(Constellation), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Handedness", typeof(Handedness), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hip", typeof(Hip), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hobby", typeof(Hobby), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Talent", typeof(Talent), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Title", typeof(Title), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Waist", typeof(Waist), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("cv", typeof(cv), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("familyNameKana", typeof(familyNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("givenNameKana", typeof(givenNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("nameKana", typeof(nameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string about
        {
            get
            {
                return this.aboutField;
            }
            set
            {
                this.aboutField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthDate
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthPlace
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class description
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class familyName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class gender
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class givenName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class height
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class name
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class weight
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescriptionType
    {

        private string resourceField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
    [XmlRoot(Namespace = "http://www.w3.org/2000/01/rdf-schema#", IsNullable = false)]
    public partial class label
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://xmlns.com/foaf/0.1/")]
    [XmlRoot(Namespace = "http://xmlns.com/foaf/0.1/", IsNullable = false)]
    public partial class age
    {

        private string datatypeField;

        private byte valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class BloodType
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Bust
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Color
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Constellation
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Handedness
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hip
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hobby
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Talent
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Title
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Waist
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class cv
    {

        private string langField;

        private string resourceField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class familyNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class givenNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class nameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
namespace IDOLData.Bana
{
    public static class IDOLDataBaseXML
    {
        public static RDF RDFData { get; }


        static IDOLDataBaseXML()
        {
            var xmlSerializer1 = new XmlSerializer(typeof(RDF));
            var xmlSettings = new System.Xml.XmlReaderSettings() {
                CheckCharacters = false, // （2）
            };
            using (var streamReader = new StreamReader(@"Resources\b.xml", Encoding.UTF8))
            using (var xmlReader = System.Xml.XmlReader.Create(streamReader, xmlSettings))
            {
                RDFData = (RDF)xmlSerializer1.Deserialize(xmlReader); // （3）
            }
        }
    }

    // メモ: 生成されたコードは、少なくとも .NET Framework 4.5または .NET Core/Standard 2.0 が必要な可能性があります。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    [XmlRoot(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", IsNullable = false)]
    public partial class RDF
    {

        private RDFDescription[] descriptionField;

        /// <remarks/>
        [XmlElement("Description")]
        public RDFDescription[] Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescription
    {

        private object[] itemsField;

        private string aboutField;

        /// <remarks/>
        [XmlElement("birthDate", typeof(birthDate), Namespace = "http://schema.org/")]
        [XmlElement("birthPlace", typeof(birthPlace), Namespace = "http://schema.org/")]
        [XmlElement("familyName", typeof(familyName), Namespace = "http://schema.org/")]
        [XmlElement("gender", typeof(gender), Namespace = "http://schema.org/")]
        [XmlElement("givenName", typeof(givenName), Namespace = "http://schema.org/")]
        [XmlElement("height", typeof(height), Namespace = "http://schema.org/")]
        [XmlElement("name", typeof(name), Namespace = "http://schema.org/")]
        [XmlElement("weight", typeof(weight), Namespace = "http://schema.org/")]
        [XmlElement("type", typeof(RDFDescriptionType))]
        [XmlElement("label", typeof(label), Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
        [XmlElement("age", typeof(age), Namespace = "http://xmlns.com/foaf/0.1/")]
        [XmlElement("BloodType", typeof(BloodType), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Bust", typeof(Bust), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Color", typeof(Color), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Constellation", typeof(Constellation), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hip", typeof(Hip), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hobby", typeof(Hobby), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Talent", typeof(Talent), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Title", typeof(Title), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Waist", typeof(Waist), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("cv", typeof(cv), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("familyNameKana", typeof(familyNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("givenNameKana", typeof(givenNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("nameKana", typeof(nameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string about
        {
            get
            {
                return this.aboutField;
            }
            set
            {
                this.aboutField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthDate
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthPlace
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class familyName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class gender
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class givenName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class height
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class name
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class weight
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescriptionType
    {

        private string resourceField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
    [XmlRoot(Namespace = "http://www.w3.org/2000/01/rdf-schema#", IsNullable = false)]
    public partial class label
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://xmlns.com/foaf/0.1/")]
    [XmlRoot(Namespace = "http://xmlns.com/foaf/0.1/", IsNullable = false)]
    public partial class age
    {

        private string datatypeField;

        private byte valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class BloodType
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Bust
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Color
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Constellation
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hip
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hobby
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Talent
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Title
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Waist
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class cv
    {

        private string langField;

        private string resourceField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class familyNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class givenNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class nameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
namespace IDOLData.Homo
{
    public static class IDOLDataBaseXML
    {
        public static RDF RDFData { get; }

        static IDOLDataBaseXML()
        {
            var xmlSerializer1 = new XmlSerializer(typeof(RDF));
            var xmlSettings = new System.Xml.XmlReaderSettings() {
                CheckCharacters = false, // （2）
            };
            using (var streamReader = new StreamReader(@"Resources\h.xml", Encoding.UTF8))
            using (var xmlReader = System.Xml.XmlReader.Create(streamReader, xmlSettings))
            {
                RDFData = (RDF)xmlSerializer1.Deserialize(xmlReader); // （3）
            }
        }
    }

    // メモ: 生成されたコードは、少なくとも .NET Framework 4.5または .NET Core/Standard 2.0 が必要な可能性があります。
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    [XmlRoot(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", IsNullable = false)]
    public partial class RDF
    {

        private RDFDescription[] descriptionField;

        /// <remarks/>
        [XmlElement("Description")]
        public RDFDescription[] Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescription
    {

        private object[] itemsField;

        private string aboutField;

        /// <remarks/>
        [XmlElement("alternateName", typeof(alternateName), Namespace = "http://schema.org/")]
        [XmlElement("birthDate", typeof(birthDate), Namespace = "http://schema.org/")]
        [XmlElement("birthPlace", typeof(birthPlace), Namespace = "http://schema.org/")]
        [XmlElement("familyName", typeof(familyName), Namespace = "http://schema.org/")]
        [XmlElement("gender", typeof(gender), Namespace = "http://schema.org/")]
        [XmlElement("givenName", typeof(givenName), Namespace = "http://schema.org/")]
        [XmlElement("height", typeof(height), Namespace = "http://schema.org/")]
        [XmlElement("name", typeof(name), Namespace = "http://schema.org/")]
        [XmlElement("weight", typeof(weight), Namespace = "http://schema.org/")]
        [XmlElement("type", typeof(RDFDescriptionType))]
        [XmlElement("label", typeof(label), Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
        [XmlElement("age", typeof(age), Namespace = "http://xmlns.com/foaf/0.1/")]
        [XmlElement("BloodType", typeof(BloodType), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Category", typeof(Category), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Color", typeof(Color), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Constellation", typeof(Constellation), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Handedness", typeof(Handedness), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Hobby", typeof(Hobby), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("ShoeSize", typeof(ShoeSize), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Talent", typeof(Talent), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("Title", typeof(Title), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("alternateNameKana", typeof(alternateNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("cv", typeof(cv), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("familyNameKana", typeof(familyNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("givenNameKana", typeof(givenNameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        [XmlElement("nameKana", typeof(nameKana), Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string about
        {
            get
            {
                return this.aboutField;
            }
            set
            {
                this.aboutField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class alternateName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthDate
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class birthPlace
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class familyName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class gender
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class givenName
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class height
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class name
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schema.org/")]
    [XmlRoot(Namespace = "http://schema.org/", IsNullable = false)]
    public partial class weight
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public partial class RDFDescriptionType
    {

        private string resourceField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/01/rdf-schema#")]
    [XmlRoot(Namespace = "http://www.w3.org/2000/01/rdf-schema#", IsNullable = false)]
    public partial class label
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://xmlns.com/foaf/0.1/")]
    [XmlRoot(Namespace = "http://xmlns.com/foaf/0.1/", IsNullable = false)]
    public partial class age
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class BloodType
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Category
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Color
    {

        private string datatypeField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Constellation
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Handedness
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Hobby
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class ShoeSize
    {

        private string datatypeField;

        private decimal valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Talent
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class Title
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class alternateNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class cv
    {

        private string langField;

        private string resourceField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class familyNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class givenNameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#")]
    [XmlRoot(Namespace = "https://sparql.crssnky.xyz/imasrdf/URIs/imas-schema.ttl#", IsNullable = false)]
    public partial class nameKana
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}

namespace IDOLData.Load
{
    public class LoadIDOLXML
    {
        public class RooTObjecTC
        {
            public CinderellaGirl[] CinderellaGirl { get; set; }
        }
        public class RooTObjecTM
        {
            public MillionStar[] MillionStar { get; set; }
        }

        public class RooTObjecTA
        {
            public AllStar[] AllStar { get; set; }
        }

        public class RooTObjecTS
        {
            public ShinyColor[] ShinyColor { get; set; }
        }

        public class RooTObjecTD
        {
            public DearlyStar[] DearlyStar { get; set; }
        }

        public class RooTObjecTH
        {
            public SideM[] SideM { get; set; }
        }

        public static void SetM()
        {
            var rdf = IDOLData.Homo.IDOLDataBaseXML.RDFData;
            var items = rdf.Description.Select(x => x.Items);

            var namaeJa = items.Select(x => x.OfType<Homo.familyName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var myoujiJa = items.Select(x => x.OfType<Homo.givenName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var namaeEn = items.Select(x => x.OfType<Homo.familyName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var myoujiEn = items.Select(x => x.OfType<Homo.givenName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var namaeKana = items.Select(x => x.OfType<Homo.familyNameKana>().FirstOrDefault()).Select(x => x?.Value);
            var myoujikana = items.Select(x => x.OfType<Homo.givenNameKana>().FirstOrDefault()).Select(x => x?.Value);

            var namesJa = namaeJa.Zip(myoujiJa, (x, y) => x + " " + y);
            var namesEn = namaeEn.Zip(myoujiEn, (x, y) => y + " " + x);
            var namesKana = namaeKana.Zip(myoujikana, (x, y) => x + " " + y);

            var ages = items.Select(x => x.OfType<Homo.age>().FirstOrDefault()).Select(x => x.Value);
            var heights = items.Select(x => x.OfType<Homo.height>().FirstOrDefault()).Select(x => x.Value);
            var weights = items.Select(x => x.OfType<Homo.weight>().FirstOrDefault()).Select(x => x.Value);
            var foot = items.Select(x => x.OfType<Homo.ShoeSize>().FirstOrDefault()).Select(x => x.Value);
            var birthDay = items.Select(x => x.OfType<Homo.birthDate>().FirstOrDefault()).Select(x => x.Value);
            var birthPlace = items.Select(x => x.OfType<Homo.birthPlace>().FirstOrDefault()).Select(x => x?.Value);
            var bloods = items.Select(x => x.OfType<Homo.BloodType>().FirstOrDefault()).Select(x => x.Value);
            var Constellation = items.Select(x => x.OfType<Homo.Constellation>().FirstOrDefault()).Select(x => x.Value);
            var Hobby = items.Select(x => string.Join(",", x.OfType<Homo.Hobby>().Select(y => y.Value)));
            var talent = items.Select(x => string.Join(",", x.OfType<Homo.Talent>().Select(y => y.Value)));
            var color = items.Select(x => string.Join(",", x.OfType<Homo.Color>().Select(y => y.Value)));
            var hand = items.Select(x => string.Join(",", x.OfType<Homo.Handedness>().Select(y => y.Value)));

            var Homo = Enumerable.Repeat(new SideM(), items.Count());
            Homo = Homo.Zip(namesJa, (x, y) => new SideM(x) { Name = y });
            Homo = Homo.Zip(namesKana, (x, y) => new SideM(x) { Phonetic = y });
            Homo = Homo.Zip(namesEn, (x, y) => new SideM(x) { English = y });
            Homo = Homo.Zip(ages, (x, y) => new SideM(x) { Age = int.TryParse(y, out var i) ? i : 0 });
            Homo = Homo.Zip(heights, (x, y) => new SideM(x) { Height = (double)y });
            Homo = Homo.Zip(weights, (x, y) => new SideM(x) { Weight = (double)y });
            Homo = Homo.Zip(foot, (x, y) => new SideM(x) { Foot = (double)y });
            Homo = Homo.Zip(birthDay, (x, y) => new SideM(x) { BirthDay = DateTime.TryParse(y.Replace("--", "").Replace("-", "/"), out var dt) ? dt.ToString("MM/dd") : string.Empty });
            Homo = Homo.Zip(birthPlace, (x, y) => new SideM(x) { BirthPlace = y });
            Homo = Homo.Zip(bloods, (x, y) => new SideM(x) { Blood = y });
            Homo = Homo.Zip(Hobby, (x, y) => new SideM(x) { Hobby = y });
            Homo = Homo.Zip(hand, (x, y) => new SideM(x) { Handedness = y });
            Homo = Homo.Zip(color, (x, y) => new SideM(x) { Color = y });
            var ASList = Homo.Zip(Constellation, (x, y) => new SideM(x) { Constellation = y }).ToArray();

            try
            {
                var idolJson = new RooTObjecTH {
                    SideM = ASList,
                };
                using (var fs = new FileStream(@"Resources\side.json", FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, idolJson);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetBana()
        {
            var rdf = IDOLData.Bana.IDOLDataBaseXML.RDFData;
            var items = rdf.Description.Select(x => x.Items);

            var namaeJa = items.Select(x => x.OfType<Bana.familyName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var myoujiJa = items.Select(x => x.OfType<Bana.givenName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var namaeEn = items.Select(x => x.OfType<Bana.familyName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var myoujiEn = items.Select(x => x.OfType<Bana.givenName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var namaeKana = items.Select(x => x.OfType<Bana.familyNameKana>().FirstOrDefault()).Select(x => x?.Value);
            var myoujikana = items.Select(x => x.OfType<Bana.givenNameKana>().FirstOrDefault()).Select(x => x?.Value);

            var namesJa = namaeJa.Zip(myoujiJa, (x, y) => x + " " + y);
            var namesEn = namaeEn.Zip(myoujiEn, (x, y) => y + " " + x);
            var namesKana = namaeKana.Zip(myoujikana, (x, y) => x + " " + y);

            var ages = items.Select(x => x.OfType<Bana.age>().FirstOrDefault()).Select(x => x.Value);
            var heights = items.Select(x => x.OfType<Bana.height>().FirstOrDefault()).Select(x => x.Value);
            var weights = items.Select(x => x.OfType<Bana.weight>().FirstOrDefault()).Select(x => x.Value);
            var busts = items.Select(x => x.OfType<Bana.Bust>().FirstOrDefault()).Select(x => x.Value);
            var waist = items.Select(x => x.OfType<Bana.Waist>().FirstOrDefault()).Select(x => x.Value);
            var hips = items.Select(x => x.OfType<Bana.Hip>().FirstOrDefault()).Select(x => x.Value);
            var birthDay = items.Select(x => x.OfType<Bana.birthDate>().FirstOrDefault()).Select(x => x.Value);
            var birthPlace = items.Select(x => x.OfType<Bana.birthPlace>().FirstOrDefault()).Select(x => x?.Value);
            var bloods = items.Select(x => x.OfType<Bana.BloodType>().FirstOrDefault()).Select(x => x.Value);
            var Constellation = items.Select(x => x.OfType<Bana.Constellation>().FirstOrDefault()).Select(x => x.Value);
            var Hobby = items.Select(x => string.Join(",", x.OfType<Bana.Hobby>().Select(y => y.Value)));
            var talent = items.Select(x => string.Join(",", x.OfType<Bana.Talent>().Select(y => y.Value)));
            var color = items.Select(x => string.Join(",", x.OfType<Bana.Color>().Select(y => y.Value)));

            var Bana = Enumerable.Repeat(new DearlyStar(), items.Count());
            Bana = Bana.Zip(namesJa, (x, y) => new DearlyStar(x) { Name = y });
            Bana = Bana.Zip(namesKana, (x, y) => new DearlyStar(x) { Phonetic = y });
            Bana = Bana.Zip(namesEn, (x, y) => new DearlyStar(x) { English = y });
            Bana = Bana.Zip(ages, (x, y) => new DearlyStar(x) { Age = y });
            Bana = Bana.Zip(heights, (x, y) => new DearlyStar(x) { Height = (double)y });
            Bana = Bana.Zip(weights, (x, y) => new DearlyStar(x) { Weight = (double)y });
            Bana = Bana.Zip(busts, (x, y) => new DearlyStar(x) { Bust = (double)y });
            Bana = Bana.Zip(waist, (x, y) => new DearlyStar(x) { Waist = (double)y });
            Bana = Bana.Zip(hips, (x, y) => new DearlyStar(x) { Hip = (double)y });
            Bana = Bana.Zip(birthDay, (x, y) => new DearlyStar(x) { BirthDay = DateTime.TryParse(y.Replace("--", "").Replace("-", "/"), out var dt) ? dt.ToString("MM/dd") : string.Empty });
            Bana = Bana.Zip(birthPlace, (x, y) => new DearlyStar(x) { BirthPlace = y });
            Bana = Bana.Zip(bloods, (x, y) => new DearlyStar(x) { Blood = y });
            Bana = Bana.Zip(Hobby, (x, y) => new DearlyStar(x) { Hobby = y });
            Bana = Bana.Zip(color, (x, y) => new DearlyStar(x) { Color = y });
            var ASList = Bana.Zip(Constellation, (x, y) => new DearlyStar(x) { Constellation = y }).ToArray();

            try
            {
                var idolJson = new RooTObjecTD {
                    DearlyStar = ASList,
                };
                using (var fs = new FileStream(@"Resources\Bana.json", FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, idolJson);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetShani()
        {
            var rdf = Shani.IDOLDataBaseXML.RDFData;
            var items = rdf.Description.Select(x => x.Items);

            var namaeJa = items.Select(x => x.OfType<Shani.familyName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var myoujiJa = items.Select(x => x.OfType<Shani.givenName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var namaeEn = items.Select(x => x.OfType<Shani.familyName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var myoujiEn = items.Select(x => x.OfType<Shani.givenName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var namaeKana = items.Select(x => x.OfType<Shani.familyNameKana>().FirstOrDefault()).Select(x => x?.Value);
            var myoujikana = items.Select(x => x.OfType<Shani.givenNameKana>().FirstOrDefault()).Select(x => x?.Value);

            var namesJa = namaeJa.Zip(myoujiJa, (x, y) => x + " " + y);
            var namesEn = namaeEn.Zip(myoujiEn, (x, y) => y + " " + x);
            var namesKana = namaeKana.Zip(myoujikana, (x, y) => x + " " + y);

            var ages = items.Select(x => x.OfType<Shani.age>().FirstOrDefault()).Select(x => x.Value);
            var heights = items.Select(x => x.OfType<Shani.height>().FirstOrDefault()).Select(x => x.Value);
            var weights = items.Select(x => x.OfType<Shani.weight>().FirstOrDefault()).Select(x => x.Value);
            var busts = items.Select(x => x.OfType<Shani.Bust>().FirstOrDefault()).Select(x => x.Value);
            var waist = items.Select(x => x.OfType<Shani.Waist>().FirstOrDefault()).Select(x => x.Value);
            var hips = items.Select(x => x.OfType<Shani.Hip>().FirstOrDefault()).Select(x => x.Value);
            var birthDay = items.Select(x => x.OfType<Shani.birthDate>().FirstOrDefault()).Select(x => x.Value);
            var birthPlace = items.Select(x => x.OfType<Shani.birthPlace>().FirstOrDefault()).Select(x => x.Value);
            var bloods = items.Select(x => x.OfType<Shani.BloodType>().FirstOrDefault()).Select(x => x.Value);
            var Constellation = items.Select(x => x.OfType<Shani.Constellation>().FirstOrDefault()).Select(x => x.Value);
            var Hobby = items.Select(x => string.Join(",", x.OfType<Shani.Hobby>().Select(y => y.Value)));
            var talent = items.Select(x => string.Join(",", x.OfType<Shani.Talent>().Select(y => y.Value)));
            var color = items.Select(x => string.Join(",", x.OfType<Shani.Color>().Select(y => y.Value)));
            var hand = items.Select(x => string.Join(",", x.OfType<Shani.Handedness>().Select(y => y.Value)));

            var shani = Enumerable.Repeat(new ShinyColor(), items.Count());
            shani = shani.Zip(namesJa, (x, y) => new ShinyColor(x) { Name = y });
            shani = shani.Zip(namesKana, (x, y) => new ShinyColor(x) { Phonetic = y });
            shani = shani.Zip(namesEn, (x, y) => new ShinyColor(x) { English = y });
            shani = shani.Zip(ages, (x, y) => new ShinyColor(x) { Age = y });
            shani = shani.Zip(heights, (x, y) => new ShinyColor(x) { Height = (double)y });
            shani = shani.Zip(weights, (x, y) => new ShinyColor(x) { Weight = (double)y });
            shani = shani.Zip(busts, (x, y) => new ShinyColor(x) { Bust = (double)y });
            shani = shani.Zip(waist, (x, y) => new ShinyColor(x) { Waist = (double)y });
            shani = shani.Zip(hips, (x, y) => new ShinyColor(x) { Hip = (double)y });
            shani = shani.Zip(birthDay, (x, y) => new ShinyColor(x) { BirthDay = DateTime.TryParse(y.Replace("--", "").Replace("-", "/"), out var dt) ? dt.ToString("MM/dd") : string.Empty });
            shani = shani.Zip(birthPlace, (x, y) => new ShinyColor(x) { BirthPlace = y });
            shani = shani.Zip(bloods, (x, y) => new ShinyColor(x) { Blood = y });
            shani = shani.Zip(Hobby, (x, y) => new ShinyColor(x) { Hobby = y });
            shani = shani.Zip(talent, (x, y) => new ShinyColor(x) { Talent = y });
            shani = shani.Zip(color, (x, y) => new ShinyColor(x) { Color = y });
            shani = shani.Zip(hand, (x, y) => new ShinyColor(x) { Handedness = y });
            var ASList = shani.Zip(Constellation, (x, y) => new ShinyColor(x) { Constellation = y }).ToArray();

            try
            {
                var idolJson = new RooTObjecTS {
                    ShinyColor = ASList,
                };
                using (var fs = new FileStream(@"Resources\shani.json", FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, idolJson);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetAS()
        {
            var rdf = IDOLData.AS.IDOLDataBaseXML.RDFData;
            var items = rdf.Description.Select(x => x.Items);

            var namaeJa = items.Select(x => x.OfType<AS.familyName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var myoujiJa = items.Select(x => x.OfType<AS.givenName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var namaeEn = items.Select(x => x.OfType<AS.familyName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var myoujiEn = items.Select(x => x.OfType<AS.givenName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var namaeKana = items.Select(x => x.OfType<AS.familyNameKana>().FirstOrDefault()).Select(x => x?.Value);
            var myoujikana = items.Select(x => x.OfType<AS.givenNameKana>().FirstOrDefault()).Select(x => x?.Value);

            var namesJa = namaeJa.Zip(myoujiJa, (x, y) => x + " " + y);
            var namesEn = namaeEn.Zip(myoujiEn, (x, y) => y + " " + x);
            var namesKana = namaeKana.Zip(myoujikana, (x, y) => x + " " + y);

            var Attribute = items.Select(x => x.OfType<AS.Attribute>().FirstOrDefault()).Select(x => x.Value);
            var divisions = items.Select(x => x.OfType<AS.Division>().FirstOrDefault()).Select(x => x.Value);
            var ages = items.Select(x => x.OfType<AS.age>().FirstOrDefault()).Select(x => x.Value);
            var heights = items.Select(x => x.OfType<AS.height>().FirstOrDefault()).Select(x => x.Value);
            var weights = items.Select(x => x.OfType<AS.weight>().FirstOrDefault()).Select(x => x.Value);
            var busts = items.Select(x => x.OfType<AS.Bust>().FirstOrDefault()).Select(x => x.Value);
            var waist = items.Select(x => x.OfType<AS.Waist>().FirstOrDefault()).Select(x => x.Value);
            var hips = items.Select(x => x.OfType<AS.Hip>().FirstOrDefault()).Select(x => x.Value);
            var birthDay = items.Select(x => x.OfType<AS.birthDate>().FirstOrDefault()).Select(x => x.Value);
            var birthPlace = items.Select(x => x.OfType<AS.birthPlace>().FirstOrDefault()).Select(x => x.Value);
            var bloods = items.Select(x => x.OfType<AS.BloodType>().FirstOrDefault()).Select(x => x.Value);
            var Constellation = items.Select(x => x.OfType<AS.Constellation>().FirstOrDefault()).Select(x => x.Value);
            var Hobby = items.Select(x => string.Join(",", x.OfType<AS.Hobby>().Select(y => y.Value)));
            var talent = items.Select(x => string.Join(",", x.OfType<AS.Talent>().Select(y => y.Value)));
            var color = items.Select(x => string.Join(",", x.OfType<AS.Color>().Select(y => y.Value)));
            var hand = items.Select(x => string.Join(",", x.OfType<AS.Handedness>().Select(y => y.Value)));

            var AS = Enumerable.Repeat(new AllStar(), items.Count());
            AS = AS.Zip(namesJa, (x, y) => new AllStar(x) { Name = y });
            AS = AS.Zip(namesKana, (x, y) => new AllStar(x) { Phonetic = y });
            AS = AS.Zip(namesEn, (x, y) => new AllStar(x) { English = y });
            AS = AS.Zip(Attribute, (x, y) => new AllStar(x) { Attribute = y });
            AS = AS.Zip(divisions, (x, y) => new AllStar(x) { Division = y });
            AS = AS.Zip(ages, (x, y) => new AllStar(x) { Age = y });
            AS = AS.Zip(heights, (x, y) => new AllStar(x) { Height = (double)y });
            AS = AS.Zip(weights, (x, y) => new AllStar(x) { Weight = (double)y });
            AS = AS.Zip(busts, (x, y) => new AllStar(x) { Bust = (double)y });
            AS = AS.Zip(waist, (x, y) => new AllStar(x) { Waist = (double)y });
            AS = AS.Zip(hips, (x, y) => new AllStar(x) { Hip = (double)y });
            AS = AS.Zip(birthDay, (x, y) => new AllStar(x) { BirthDay = DateTime.TryParse(y.Replace("--", "").Replace("-", "/"), out var dt) ? dt.ToString("MM/dd") : string.Empty });
            AS = AS.Zip(birthPlace, (x, y) => new AllStar(x) { BirthPlace = y });
            AS = AS.Zip(bloods, (x, y) => new AllStar(x) { Blood = y });
            AS = AS.Zip(Hobby, (x, y) => new AllStar(x) { Hobby = y });
            AS = AS.Zip(talent, (x, y) => new AllStar(x) { Talent = y });
            AS = AS.Zip(color, (x, y) => new AllStar(x) { Color = y });
            AS = AS.Zip(hand, (x, y) => new AllStar(x) { Handedness = y });
            var ASList = AS.Zip(Constellation, (x, y) => new AllStar(x) { Constellation = y }).ToArray();

            try
            {
                var idolJson = new RooTObjecTA {
                    AllStar = ASList,
                };
                using (var fs = new FileStream(@"Resources\as.json", FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, idolJson);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetMiri()
        {
            var rdf = Mili.IDOLDataBaseXML.RDFData;
            var items = rdf.Description.Select(x => x.Items);

            var namaeJa = items.Select(x => x.OfType<Mili.familyName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var myoujiJa = items.Select(x => x.OfType<Mili.givenName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var namaeEn = items.Select(x => x.OfType<Mili.familyName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var myoujiEn = items.Select(x => x.OfType<Mili.givenName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var namaeKana = items.Select(x => x.OfType<Mili.familyNameKana>().FirstOrDefault()).Select(x => x?.Value);
            var myoujikana = items.Select(x => x.OfType<Mili.givenNameKana>().FirstOrDefault()).Select(x => x?.Value);

            var namesJa = namaeJa.Zip(myoujiJa, (x, y) => x + " " + y);
            var namesEn = namaeEn.Zip(myoujiEn, (x, y) => y + " " + x);
            var namesKana = namaeKana.Zip(myoujikana, (x, y) => x + " " + y);

            var Attribute = items.Select(x => x.OfType<Mili.Attribute>().FirstOrDefault()).Select(x => x.Value);
            var divisions = items.Select(x => x.OfType<Mili.Division>().FirstOrDefault()).Select(x => x.Value);
            var ages = items.Select(x => x.OfType<Mili.age>().FirstOrDefault()).Select(x => x.Value);
            var heights = items.Select(x => x.OfType<Mili.height>().FirstOrDefault()).Select(x => x.Value);
            var weights = items.Select(x => x.OfType<Mili.weight>().FirstOrDefault()).Select(x => x.Value);
            var busts = items.Select(x => x.OfType<Mili.Bust>().FirstOrDefault()).Select(x => x.Value);
            var waist = items.Select(x => x.OfType<Mili.Waist>().FirstOrDefault()).Select(x => x.Value);
            var hips = items.Select(x => x.OfType<Mili.Hip>().FirstOrDefault()).Select(x => x.Value);
            var birthDay = items.Select(x => x.OfType<Mili.birthDate>().FirstOrDefault()).Select(x => x.Value);
            var birthPlace = items.Select(x => x.OfType<Mili.birthPlace>().FirstOrDefault()).Select(x => x.Value);
            var bloods = items.Select(x => x.OfType<Mili.BloodType>().FirstOrDefault()).Select(x => x.Value);
            var Constellation = items.Select(x => x.OfType<Mili.Constellation>().FirstOrDefault()).Select(x => x.Value);
            var Hobby = items.Select(x => string.Join(",", x.OfType<Mili.Hobby>().Select(y => y.Value)));
            var talent = items.Select(x => string.Join(",", x.OfType<Mili.Talent>().Select(y => y.Value)));
            var color = items.Select(x => string.Join(",", x.OfType<Mili.Color>().Select(y => y.Value)));
            var hand = items.Select(x => string.Join(",", x.OfType<Mili.Handedness>().Select(y => y.Value)));

            var miri = Enumerable.Repeat(new MillionStar(), items.Count());
            miri = miri.Zip(namesJa, (x, y) => new MillionStar(x) { Name = y });
            miri = miri.Zip(namesKana, (x, y) => new MillionStar(x) { Phonetic = y });
            miri = miri.Zip(namesEn, (x, y) => new MillionStar(x) { English = y });
            miri = miri.Zip(Attribute, (x, y) => new MillionStar(x) { Attribute = y });
            miri = miri.Zip(divisions, (x, y) => new MillionStar(x) { Division = y });
            miri = miri.Zip(ages, (x, y) => new MillionStar(x) { Age = y });
            miri = miri.Zip(heights, (x, y) => new MillionStar(x) { Height = (double)y });
            miri = miri.Zip(weights, (x, y) => new MillionStar(x) { Weight = (double)y });
            miri = miri.Zip(busts, (x, y) => new MillionStar(x) { Bust = (double)y });
            miri = miri.Zip(waist, (x, y) => new MillionStar(x) { Waist = (double)y });
            miri = miri.Zip(hips, (x, y) => new MillionStar(x) { Hip = (double)y });
            miri = miri.Zip(birthDay, (x, y) => new MillionStar(x) { BirthDay = DateTime.TryParse(y.Replace("--", "").Replace("-", "/"), out var dt) ? dt.ToString("MM/dd") : string.Empty });
            miri = miri.Zip(birthPlace, (x, y) => new MillionStar(x) { BirthPlace = y });
            miri = miri.Zip(bloods, (x, y) => new MillionStar(x) { Blood = y });
            miri = miri.Zip(Hobby, (x, y) => new MillionStar(x) { Hobby = y });
            miri = miri.Zip(talent, (x, y) => new MillionStar(x) { Talent = y });
            miri = miri.Zip(color, (x, y) => new MillionStar(x) { Color = y });
            miri = miri.Zip(hand, (x, y) => new MillionStar(x) { Handedness = y });
            var miliList = miri.Zip(Constellation, (x, y) => new MillionStar(x) { Constellation = y }).ToArray();

            try
            {
                var idolJson = new RooTObjecTM {
                    MillionStar = miliList,
                };
                using (var fs = new FileStream(@"Resources\miri.json", FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, idolJson);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SetDere()
        {
            var rdf = Derera.IDOLDataBaseXML.RDFData;
            var items = rdf.Description.Select(x => x.Items);

            var namaeJa = items.Select(x => x.OfType<Derera.familyName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var myoujiJa = items.Select(x => x.OfType<Derera.givenName>().FirstOrDefault(y => y.lang == "ja")).Select(x => x?.Value);
            var namaeEn = items.Select(x => x.OfType<Derera.familyName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var myoujiEn = items.Select(x => x.OfType<Derera.givenName>().FirstOrDefault(y => y.lang == "en")).Select(x => x?.Value);
            var namaeKana = items.Select(x => x.OfType<Derera.familyNameKana>().FirstOrDefault()).Select(x => x?.Value);
            var myoujikana = items.Select(x => x.OfType<Derera.givenNameKana>().FirstOrDefault()).Select(x => x?.Value);

            var namesJa = namaeJa.Zip(myoujiJa, (x, y) => x + " " + y);
            var namesEn = namaeEn.Zip(myoujiEn, (x, y) => y + " " + x);
            var namesKana = namaeKana.Zip(myoujikana, (x, y) => x + " " + y);

            var Attribute = items.Select(x => x.OfType<Derera.Type>().FirstOrDefault()).Select(x => x.Value);
            var ages = items.Select(x => x.OfType<Derera.age>().FirstOrDefault()).Select(x => x.Value);
            var heights = items.Select(x => x.OfType<Derera.height>().FirstOrDefault()).Select(x => x.Value);
            var weights = items.Select(x => x.OfType<Derera.weight>().FirstOrDefault()).Select(x => x.Value);
            var busts = items.Select(x => x.OfType<Derera.Bust>().FirstOrDefault()).Select(x => x.Value);
            var waist = items.Select(x => x.OfType<Derera.Waist>().FirstOrDefault()).Select(x => x.Value);
            var hips = items.Select(x => x.OfType<Derera.Hip>().FirstOrDefault()).Select(x => x.Value);
            var birthDay = items.Select(x => x.OfType<Derera.birthDate>().FirstOrDefault()).Select(x => x.Value);
            var birthPlace = items.Select(x => x.OfType<Derera.birthPlace>().FirstOrDefault()).Select(x => x.Value);
            var bloods = items.Select(x => x.OfType<Derera.BloodType>().FirstOrDefault()).Select(x => x.Value);
            var Constellation = items.Select(x => x.OfType<Derera.Constellation>().FirstOrDefault()).Select(x => x.Value);
            var Hobby = items.Select(x => string.Join(",", x.OfType<Derera.Hobby>().Select(y => y.Value)));
            var color = items.Select(x => string.Join(",", x.OfType<Derera.Color>().Select(y => y.Value)));
            var hand = items.Select(x => string.Join(",", x.OfType<Derera.Handedness>().Select(y => y.Value)));

            var delera = Enumerable.Repeat(new CinderellaGirl(), items.Count());
            delera = delera.Zip(namesJa, (x, y) => new CinderellaGirl(x) { Name = y });
            delera = delera.Zip(namesKana, (x, y) => new CinderellaGirl(x) { Phonetic = y });
            delera = delera.Zip(namesEn, (x, y) => new CinderellaGirl(x) { English = y });
            delera = delera.Zip(Attribute, (x, y) => new CinderellaGirl(x) { Type = y });
            delera = delera.Zip(ages, (x, y) => new CinderellaGirl(x) { Age = int.TryParse(y, out var i) ? i : 0 });
            delera = delera.Zip(heights, (x, y) => new CinderellaGirl(x) { Height = (double)y });
            delera = delera.Zip(weights, (x, y) => new CinderellaGirl(x) { Weight = double.TryParse(y, out var d) ? d : 0 });
            delera = delera.Zip(busts, (x, y) => new CinderellaGirl(x) { Bust = double.TryParse(y, out var d) ? d : 0 });
            delera = delera.Zip(waist, (x, y) => new CinderellaGirl(x) { Waist = double.TryParse(y, out var d) ? d : 0 });
            delera = delera.Zip(hips, (x, y) => new CinderellaGirl(x) { Hip = double.TryParse(y, out var d) ? d : 0 });
            delera = delera.Zip(birthDay, (x, y) => new CinderellaGirl(x) { BirthDay = DateTime.TryParse(y.Replace("--", "").Replace("-", "/"), out var dt) ? dt.ToString("MM/dd") : string.Empty });
            delera = delera.Zip(birthPlace, (x, y) => new CinderellaGirl(x) { BirthPlace = y });
            delera = delera.Zip(bloods, (x, y) => new CinderellaGirl(x) { Blood = y });
            delera = delera.Zip(Hobby, (x, y) => new CinderellaGirl(x) { Hobby = y });
            delera = delera.Zip(color, (x, y) => new CinderellaGirl(x) { Color = y });
            delera = delera.Zip(hand, (x, y) => new CinderellaGirl(x) { Handedness = y });
            var deleraList = delera.Zip(Constellation, (x, y) => new CinderellaGirl(x) { Constellation = y }).ToArray();

            try
            {
                var idolJson = new RooTObjecTC {
                    CinderellaGirl = deleraList,
                };
                using (var fs = new FileStream(@"Resources\dere.json", FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, idolJson);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}