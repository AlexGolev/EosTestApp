using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EosTestApp.Models
{
    public class ActivitySphere
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Organization
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int ActivitySphereId { get; set; }
        public ActivitySphere ActivitySphere { get; set; }
        public string DirectorFIO { get; set; }
        public int AuthorizedCapital { get; set; }
        public int INN { get; set; }
        public int KPP { get; set; }
        public int OGRN { get; set; }

    }
}
