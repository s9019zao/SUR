using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{
    public class Breakdown
    {
        [Key]
        public int BreakdownId { get; set; }
        public StatusBreakdown Status { get; set; }
        public BreakedownType Type { get; set; }
        public string RequestDescription { get; set; }
        public string OverhaulDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime OverhaulDate { get; set; }

        // Inicjalizacja relacji w bazie danych
        public virtual Device Device { get; set; } //Urządzenia na którym wystąpiła awaria
        public virtual Person ReportingPerson { get; set; } // Pracownik zgłaszający
        public virtual ICollection<Person> MaintanancePersons { get; set; } // Lista pracowników usuwających
        public virtual ICollection<Part> UseParts { get; set; } // Lista urzytych części

        public Breakdown()
        {
            MaintanancePersons = new List<Person>();
            UseParts = new List<Part>();
        }
    }
}
