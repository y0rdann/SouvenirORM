using SouvenirsORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SouvenirsORM.Controllers
{
    public class SouvenirTypeLogic
    {
        private SouvenirsDbContext _souvenirsDbContext = new SouvenirsDbContext();
        public List<SouvenirType> GetAllSouvenirTypes()
        {
            return _souvenirsDbContext.SouvenirsTypes.ToList();
        }
        public string GetSouvenirTypeById(int id)
        {
            return _souvenirsDbContext.SouvenirsTypes.Find(id).Name;
        }

    }
}
