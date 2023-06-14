using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SouvenirsORM.Models
{
    internal class SouvenirsDbContext:DbContext
    {
        public SouvenirsDbContext():base("SouvenirsDbContext")
        {
            
        }
        public DbSet<Souvenir> Souvenirs { get; set;}
        public DbSet<SouvenirType> SouvenirsTypes { get; set;}
    }
}
