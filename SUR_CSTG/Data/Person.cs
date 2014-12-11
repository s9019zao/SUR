using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public Position Position { get ; set;}
        public string PhoneNumber { get; set; }

        // Inicjalizacja relacji w bazie danych
        public virtual ICollection<Breakdown> RequestedBreakdowns { get; set; } // Lista awari zgłoszonych
        public virtual ICollection<Breakdown> FixedBreakdowns { get; set; } // Lista awarii usuniętych

        public Person()
        {
            RequestedBreakdowns = new List<Breakdown>();
            FixedBreakdowns = new List<Breakdown>();
        }
  
    }
}
