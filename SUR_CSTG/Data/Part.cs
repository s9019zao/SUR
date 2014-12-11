using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public PartType PartType { get; set; }
        public Unit Unit { get; set; }

        // Inicjalizacja relacji w bazie danych
        public virtual ICollection<Breakdown> UsedPartBreakdowns { get; set; } //Lista awarii do których część została użyta

        public Part()
        {
            UsedPartBreakdowns = new List<Breakdown>();
        }
    }
}
