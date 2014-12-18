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

            Area area6 = new Area
            {
                Name = "Nieaktywny",
                Description = "W tym rejonie znajdują się urządzenia o statusie Nieaktywne"
            };

            Area area7 = new Area
            {
                Name = "Złomowiec",
                Description = "W tym rejonie znajdują się urządzenia o statusie Usunięte"
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
               Description = "Jakiś1",
               Status = DeviceStatus.Aktywne
           };

           Device device2 = new Device
           {
               Name = "Urządzenie2",
               Description = "Jakiś2",
               Status = DeviceStatus.Aktywne
           };

           Device device3 = new Device
           {
               Name = "Urządzenie3",
               Description = "Jakiś3",
               Status = DeviceStatus.Aktywne
           };

           Device device4 = new Device
           {
               Name = "Urządzenie4",
               Description = "Jakiś4",
               Status = DeviceStatus.Aktywne
           };

           Device device5 = new Device
           {
               Name = "Urządzenie5",
               Description = "Jakiś5",
               Status = DeviceStatus.Aktywne
           };

           Device device6 = new Device
           {
               Name = "Urządzenie6",
               Description = "Jakiś6",
               Status = DeviceStatus.Aktywne
           };

           Device device7 = new Device
           {
               Name = "Urządzenie7",
               Description = "Jakiś7",
               Status = DeviceStatus.Aktywne
           };

           Device device8 = new Device
           {
               Name = "Urządzenie8",
               Description = "Jakiś8",
               Status = DeviceStatus.Aktywne
           };

           Device device9 = new Device
           {
               Name = "Urządzenie9",
               Description = "Jakiś9",
               Status = DeviceStatus.Aktywne
           };

           #endregion

           #region Part
           Part part1 = new Part
           {
               Name = "Część1",
               PartType = Data.PartType.Automatyka,
               Unit = Data.Unit.kg,
               Quantity = 2.40
           };

           Part part2 = new Part
           {
               Name = "Część2",
               PartType = Data.PartType.Elektryka,
               Unit = Data.Unit.szt,
               Quantity = 3.00
           };

           Part part3 = new Part
           {
               Name = "Część3",
               PartType = Data.PartType.Mechanika,
               Unit = Data.Unit.m,
               Quantity = 4.00
           };

           #endregion

           #region Part
           Breakdown breakdown1 = new Breakdown
           {
               RequestDate = DateTime.Now,
               OverhaulDate = DateTime.Now,
               Status = StatusBreakdown.Zgłoszona,
               Type = BreakedownType.Automatczna,
               RequestDescription = "dgsdgsdg",
               ReportingPerson = person1,
               Device = device1
           };

           Breakdown breakdown2 = new Breakdown
           {
               RequestDate = new DateTime(2014, 1, 18, 18, 16, 50),
               OverhaulDate = DateTime.Now,
               Status = StatusBreakdown.Zgłoszona,
               Type = BreakedownType.Elektryczna,
               ReportingPerson = person4,
               Device = device2
           };

           Breakdown breakdown3 = new Breakdown
           {
               RequestDate = new DateTime(2014, 6, 21, 14, 36, 50),
               OverhaulDate = DateTime.Now,
               Status = StatusBreakdown.Zgłoszona,
               Type = BreakedownType.Mechaniczna,
               ReportingPerson = person5,
               Device = device3
           };

           #endregion

           ctx.Breakdowns.Add(breakdown1);
           ctx.Breakdowns.Add(breakdown2);
           ctx.Breakdowns.Add(breakdown3);

           ctx.Devices.Add(device1);
           ctx.Devices.Add(device2);
           ctx.Devices.Add(device3);
           ctx.Devices.Add(device4);
           ctx.Devices.Add(device5);
           ctx.Devices.Add(device6);
           ctx.Devices.Add(device7);
           ctx.Devices.Add(device8);
           ctx.Devices.Add(device9);
           
           area1.Devices.Add(device1);
           area1.Devices.Add(device2);
           area2.Devices.Add(device3);
           area2.Devices.Add(device4);
           area3.Devices.Add(device5);
           area3.Devices.Add(device6);
           area4.Devices.Add(device7);
           area5.Devices.Add(device8);
           area5.Devices.Add(device9);
           ctx.Areas.Add(area1);
           ctx.Areas.Add(area2);
           ctx.Areas.Add(area3);
           ctx.Areas.Add(area4);
           ctx.Areas.Add(area5);
           ctx.Areas.Add(area6);
           ctx.Areas.Add(area7);

           ctx.Persons.Add(person1);
           ctx.Persons.Add(person2);
           ctx.Persons.Add(person3);
           ctx.Persons.Add(person4);
           ctx.Persons.Add(person5);

           ctx.Parts.Add(part1);
           ctx.Parts.Add(part2);
           ctx.Parts.Add(part3);

           ctx.SaveChanges();

        }
    }
}
