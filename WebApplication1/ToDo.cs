namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ToDo")]
    public partial class ToDo
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Aufgabe { get; set; }

        public bool? Done { get; set; }

        [StringLength(3)]
        public string Bearbeiter { get; set; }

        public DateTime? Datum { get; set; }

        public DateTime? Termin { get; set; }
    }
}
