using BSAF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Helper
{
    public class DbHelper
    {
        public static List<Lookup> GetcmbLookups(string lookupCode)
        {
            dbContext db = new dbContext();
            var lookuplist = db.LookupValues.Where(l => l.IsActive == true && l.LookupCode == lookupCode)
                .Select(l => new Lookup { ValueCode = l.ValueCode, LookupName = l.EnName }).ToList();
            lookuplist.Insert(0, new Lookup { ValueCode = "0", LookupName = "-Select-" });
            return lookuplist;
        }

    }
    public class Lookup
    {
        public string ValueCode { get; set; }
        public string LookupName { get; set; }
    }

}
