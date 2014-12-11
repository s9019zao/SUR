using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Inicjalizacja relacji w bazie danych
        public virtual ICollection<Device> Devices { get; set; } //Lista urządzeń rejonu

        public Area()
        {
            Devices = new List<Device>();
        }
    }
}
