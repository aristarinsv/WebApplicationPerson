using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationPerson.Models
{
    public static class ResultForPerson
    {
        private static List<PFRStorage> peoples = new List<PFRStorage>();

        public static IEnumerable<PFRStorage> Peoples
            {
            get {
                    return peoples;
            }
        }
        //public static void addPerson(PFRSumm people) {
            //           peoples.Add(people);
        //}
    }
}
