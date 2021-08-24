using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPerson.Models;
namespace WebApplicationPerson
{
    public class Program
    {
        public static void Main(string[] args)
        {


            // добавление данных, сначала баловался с миграциями, но надеюсь тут и этого достаточно
            using (ApplicationContext db = new ApplicationContext())
            {


                var all = from c in db.Persons select c;
                db.Persons.RemoveRange(all);
                db.SaveChanges();

                Person pers1 = new Person {FirstName = "Иван", SecondName = "Васильевич", MiddleName = "Иванов", DateBirth =  DateTimeOffset.FromUnixTimeMilliseconds(-380257200).UtcDateTime, Snils = "123-325-555 23" };
                Person pers2 = new Person {FirstName=  "Денис", SecondName = "Петрович", MiddleName = "Сергеев", DateBirth = DateTimeOffset.FromUnixTimeMilliseconds(324162000).UtcDateTime, Snils = "126-324-132 21" };
                Person pers3 = new Person {FirstName =  "Ольга", SecondName =  "Ивановна", MiddleName = "Сомова", DateBirth =  DateTimeOffset.FromUnixTimeMilliseconds(423691200).UtcDateTime, Snils =  "166-022-256 22" };
                Person pers4 = new Person { FirstName = "Сергей", SecondName = "Константинович", MiddleName = "Никитин", DateBirth = DateTimeOffset.FromUnixTimeMilliseconds(563058000).UtcDateTime, Snils =  "161-334-111 24" };

                // добавляем их в бд
                db.Persons.AddRange(pers1, pers2, pers3, pers4);
                db.SaveChanges();

                var allPfr = from c in db.PFRStorages select c;
                db.PFRStorages.RemoveRange(allPfr);
                db.SaveChanges();

                PFRStorage pfr1 = new PFRStorage { SnilsPFR = "123-325-555 23", Summa = 145623, Period = "01.06.1992 - 01.11.2020" };
                PFRStorage pfr2 = new PFRStorage {SnilsPFR = "126-324-132 21", Summa =  199992, Period =  "11.12.1999 - 11.12.2010" };
                PFRStorage pfr3 = new PFRStorage {SnilsPFR =  "161-334-111 24", Summa =  10, Period = "01.01.2019 - 3.12.2019" };

                db.PFRStorages.AddRange(pfr1, pfr2, pfr3);
                db.SaveChanges();
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                //если связывать таблицы, но у нас идет из запроса
                //var result = new List<PFRStorages>();
                /*var res = db.Persons.Join(db.PFRStorages, 
                        u => u.Snils, 
                        c => c.SnilsPFR,
                        (u, c) => new 
                        {
                            FirstName = u.FirstName,
                            SecondName = u.SecondName,
                            MidleName = u.MiddleName,
                            DateBirth = u.DateBirth,
                            Summa = c.Summa,
                            Snils = u.Snils,
                            Period = c.Period
                        }) ;*/
               // foreach (var u in res)
                    //ResultForPerson.addPerson(u);
                    //Console.WriteLine($"{u.Summa} ({u.Snils})");
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
