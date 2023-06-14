using SouvenirsORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouvenirsORM.Controllers
{
    public class SouvenirLogic
    {
        private SouvenirsDbContext _souvenirsDbContext = new SouvenirsDbContext();
        public Souvenir Get(int id)
        {
            Souvenir foundSouvenir = _souvenirsDbContext.Souvenirs.Find(id);
            if (foundSouvenir!=null)
            {
                _souvenirsDbContext.Entry(foundSouvenir).Reference(x => x.SouvenirTypes).Load();
            }
            return foundSouvenir;
        }
        public List<Souvenir> GetAll()
        {
            return _souvenirsDbContext.Souvenirs.Include("SouvenirType").ToList();
        }
        public void Create(Souvenir souvenir)
        {
            _souvenirsDbContext.Souvenirs.Add(souvenir);
            _souvenirsDbContext.SaveChanges();
        }

        public void Update(int id, Souvenir souvenir)
        {
            Souvenir foundSouvenir = _souvenirsDbContext.Souvenirs.Find(id);
            if (foundSouvenir == null)
            {
                return;
            }
            foundSouvenir.Name = souvenir.Name;
            foundSouvenir.Price = souvenir.Price;
            foundSouvenir.SouvenirTypesId = souvenir.SouvenirTypesId;
            _souvenirsDbContext.SaveChanges();
        }

            public void Delete(int id)
            {
            Souvenir foundSouvenir = _souvenirsDbContext.Souvenirs.Find(id);
            _souvenirsDbContext.Souvenirs.Remove(foundSouvenir);
            _souvenirsDbContext.SaveChanges();
            }

        
    }
}
