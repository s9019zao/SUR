using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{
    public class Initializer : DropCreateDatabaseIfModelChanges<SUR_DbContext>
    {
       protected override void Seed(SUR_DbContext ctx)
        {
           #region Area
            Area area1 = new Area 
            { 
                Name = "Rejon1", 
                Description = "Jakiś1" 
            };

            Area area2 = new Area
            {
                Name = "Rejon2",
                Description = "Jakiś2"
            };

            Area area3 = new Area
            {
                Name = "Rejon3",
                Description = "Jakiś3"
            };

            Area area4 = new Area
            {
                Name = "Rejon4",
                Description = "Jakiś4"
            };

            Area area5 = new Area
            {
                Name = "Rejon5",
                Description = "Jakiś5"
            };
            #endregion

           #region Person
            Person person1 = new Person
            {
                Name = "Jan",
                Surname = "Kowalski",
                Login = "jankow",
                Password = "123",
                Position = Data.Position.Pracownik,
                PhoneNumber = "+48 600 300 101"
            };
            Person person2 = new Person
            {
                Name = "Roman",
                Surname = "Nowak",
                Login = "romnow",
                Password = "123",
                Position = Data.Position.Pracownik_SUR,
                PhoneNumber = "+48 600 300 102"
            };
            Person person3 = new Person
            {
                Name = "Alan",
                Surname = "Majkowski",
                Login = "alamaj",
                Password = "123",
                Position = Data.Position.Kierownik,
                PhoneNumber = "+48 600 300 103"
            };
            Person person4 = new Person
            {
                Name = "Marian",
                Surname = "Janicki",
                Login = "marjan",
                Password = "123",
                Position = Data.Position.Mistrz,
                PhoneNumber = "+48 600 300 104"
            };
            Person person5 = new Person
            {
                Name = "Paweł",
                Surname = "Michalski",
                Login = "pawmic",
                Password = "123",
                Position = Data.Position.Pracownik,
                PhoneNumber = "+48 600 300 105"
            };
            #endregion

           #region Device
           Device device1 = new Device
           {
               Name = "Urządzenie1",
               Description = "Jakiś1"
           };

           Device device2 = new Device
           {
               Name = "Urządzenie2",
               Description = "Jakiś2"
           };

           Device device3 = new Device
           {
               Name = "Urządzenie3",
               Description = "Jakiś3",
           };

           #endregion

           ctx.Devices.Add(device1);
           ctx.Devices.Add(device2);
           ctx.Devices.Add(device3);
           area1.Devices.Add(device1);
           area1.Devices.Add(device2);
           area1.Devices.Add(device3);
           ctx.Areas.Add(area1);
           ctx.Areas.Add(area2);
           ctx.Areas.Add(area3);
           ctx.Areas.Add(area4);
           ctx.Areas.Add(area5);
           ctx.Persons.Add(person1);
           ctx.Persons.Add(person2);
           ctx.Persons.Add(person3);
           ctx.Persons.Add(person4);
           ctx.Persons.Add(person5);
           ctx.SaveChanges();

        }
    }
}
