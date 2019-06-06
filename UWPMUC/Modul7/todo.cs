using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMUC.Modul06
{
   
    // HINWEIS: Für den generierten Code ist möglicherweise mindestens .NET Framework 4.5 oder .NET Core/Standard 2.0 erforderlich.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ToDo
    {

        private string aufgabeField;

        private string bearbeiterField;

        private System.DateTime? datumField;

        private bool doneField;

        private int idField;

        private System.DateTime? terminField;

        /// <remarks/>
        public string Aufgabe
        {
            get
            {
                return this.aufgabeField;
            }
            set
            {
                this.aufgabeField = value;
            }
        }

        /// <remarks/>
        public string Bearbeiter
        {
            get
            {
                return this.bearbeiterField;
            }
            set
            {
                this.bearbeiterField = value;
            }
        }

        /// <remarks/>
        public System.DateTime? Datum
        {
            get
            {
                return this.datumField;
            }
            set
            {
                this.datumField = value;
            }
        }

        /// <remarks/>
        public bool Done
        {
            get
            {
                return this.doneField;
            }
            set
            {
                this.doneField = value;
            }
        }

        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public System.DateTime? Termin
        {
            get
            {
                return this.terminField;
            }
            set
            {
                this.terminField = value;
            }
        }
    }


}
