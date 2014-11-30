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
        public virtual Area Area { get; set; }

        public Device()
        {
        }
    }
}
