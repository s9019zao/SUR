using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Inicjalizacja relacji w bazie danych
        public virtual Area Area { get; set; } //Rejon w którym znajduje się urządzenie
        public virtual ICollection<Breakdown> Breakdowns { get; set; } // Lista awarii na urządzeniu

        public Device()
        {
            Breakdowns = new List<Breakdown>();
        }
    }
}
