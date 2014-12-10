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
        public DateTime FilingDate { get; set; }
        public DateTime RemoveDate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Breakdown()
        {
        }
    }
}
