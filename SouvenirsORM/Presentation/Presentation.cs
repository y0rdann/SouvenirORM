using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SouvenirsORM.Models;
using SouvenirsORM.Controllers;
using System.Windows.Forms;

namespace SouvenirsORM.Presentation
{
    public class Presentation
    {
        private SouvenirLogic souvenirLogic = new SouvenirLogic();
        private int closeOperation = 6;
        public Presentation() 
        {
            Input();
        }
        public void ShowMenu()
        {
            Console.WriteLine(new string ('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        public void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                        case 2:
                        Add();
                        break;
                        case 3:
                        Update(); 
                        break;
                        case 4:
                        Fetch();
                        break;
                        case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperation);
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            SouvenirLogic souvenirController = new SouvenirLogic();
            Souvenir souvenir = souvenirController.Get(id);
            if (souvenir!=null)
            {
                souvenirController.Delete(id);
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch");
            int id=int.Parse(Console.ReadLine());
            SouvenirLogic souvenirController = new SouvenirLogic();
            Souvenir souvenir=souvenirController.Get(id);
            if (souvenir!=null)
            {
                PrintSouvenir(souvenir);
            }

        }
        public void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "SOUVENIRS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            SouvenirLogic souvenirLogic = new SouvenirLogic();
            var products = souvenirLogic.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Price} {item.SouvenirTypesId}");
            }
        }
        private void Add()
        {
            Souvenir newSouvenir=new Souvenir();
            Console.WriteLine("Name: ");
            newSouvenir.Name = Console.ReadLine();
            Console.WriteLine("Price: ");
            newSouvenir.Price = double.Parse(Console.ReadLine());
            SouvenirTypeLogic typeLogic = new SouvenirTypeLogic();
            List<SouvenirType> allTypes=typeLogic.GetAllSouvenirTypes();
            Console.WriteLine("Видове сувенири: ");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allTypes)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Избери вид: ");
            newSouvenir.SouvenirTypesId=int.Parse(Console.ReadLine());
            SouvenirLogic souvenirLogic=new SouvenirLogic();
            souvenirLogic.Create(newSouvenir);
            Console.WriteLine($"{newSouvenir.Id}. {newSouvenir.Name} >>> {newSouvenir.Price} >> Souvenir type:{ newSouvenir.SouvenirTypesId}");
        }
        private void PrintSouvenir(Souvenir souvenir)
        {
            Console.WriteLine($"{souvenir.Id}. {souvenir.Name} -- Price: {souvenir.Price} Souvenir type ID: {souvenir.SouvenirTypesId}");
        }
        private void Update()
        {
            Console.WriteLine("Enter souvenir ID: ");
            int souvenirId=int.Parse(Console.ReadLine());
            Souvenir newSouvenir = souvenirLogic.Get(souvenirId);
            if (newSouvenir==null)
            {
                Console.WriteLine("No searching dog");
                return;
            }
            PrintSouvenir(newSouvenir);
            Console.WriteLine("Enter new values: ");
            Console.WriteLine("Name: ");
            newSouvenir.Name = Console.ReadLine();
            Console.WriteLine("Price: ");
            newSouvenir.Price=double.Parse(Console.ReadLine());
            SouvenirTypeLogic typesLogic=new SouvenirTypeLogic();
            List<SouvenirType> allTypes = typesLogic.GetAllSouvenirTypes();
            Console.WriteLine(new string('-', 4));
            foreach (var item in allTypes)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Избери вид: ");
            newSouvenir.SouvenirTypesId = int.Parse(Console.ReadLine());
            SouvenirLogic souvenirController=new SouvenirLogic();
            souvenirLogic.Update(souvenirId, newSouvenir);
        }
    }
}
