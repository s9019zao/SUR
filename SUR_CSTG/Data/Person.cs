using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{

   

    public enum Position
    {
        
        Pracownik_SUR = 1 ,
        Mistrz = 2,
        Kierownik = 3,
        Pracownik = 0,
        Admin = 4,
        Prezes = 5
    }

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
  
    }
}
