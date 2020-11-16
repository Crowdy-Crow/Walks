using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Walks
{
    delegate void EventDelegate(object o, EventArgs e);
    class Program
    {
        static List<Person> people;
        static void Main(string[] args)
        {

            while (true)
            {
                string input;
                Console.WriteLine("Нажмите 1, чтобы создать личность" +
                    "\nНажмите 2, чтобы выбрать личность");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1": CreatePerson(); break;
                    case "2": ChoosePerson(); break;
                    default: Console.WriteLine("Неправильно выбрана операция"); break;
                }
            }
        }
        static void CreatePerson()
        {
            if (people == null) { people = new List<Person>();}
            Console.WriteLine("Введите имя");
            string Name = Console.ReadLine();
            Person person = new Person(Name, (o, e) => Console.WriteLine(e.mes));
            people.Add(person);
            Console.WriteLine($"Личность с именем {person.Name} создана");
        }
        static void ChoosePerson()
        {
            if (people == null) { Console.WriteLine("Список личностей пуст"); return; }
            int count  = 1;
            for (int A = 0; A<people.Count; A++)
            {
                Console.WriteLine($"{A+1}: {people[A].Name}");
            }
            Console.WriteLine("Введите номер");
            int PersonNumber = Convert.ToInt32(Console.ReadLine());
            if (PersonNumber >= people.Count || PersonNumber<=0) { Console.WriteLine("Неправильный номер"); return; }
            foreach(string name in Map.Locations)
            {
                Console.WriteLine($"{count}: {name}");
                count++;
            }
            count = 1;
            Console.WriteLine("Куда пойдем?Введите номер");
            int Place = Convert.ToInt32(Console.ReadLine());
            Person ChosenPerson = people[PersonNumber-1];
            ChosenPerson.GoToLocationAsync(Place-1); //комментарий
        }
    }
}
