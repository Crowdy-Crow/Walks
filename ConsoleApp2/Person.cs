using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Walks
{
    class Person
    {
        event EventDelegate MessEvent;
        public string Name;
        string Location;
        object locker = new object();
        public Person(string Name, EventDelegate Del)
        {
            this.Name = Name;
            MessEvent += Del;
        }
        public async void GoToAsync(int numberLocation)
        {
           
            await Task.Run(() => GoTo(numberLocation));
            
        }
        void GoTo(int A)
        {
            lock (locker)
            {
                if (Location == Map.Locations[A])
                {
                    Console.WriteLine($"{Name} уже здесь");
                    return;
                }
                Console.WriteLine($"{Name} пошел на(в) {Map.Locations[A]}");
                Thread.Sleep(10000);
                Location = Map.Locations[A];
                CallEvent($"{Name} пришел на (в) {Location}");
            }
        }
        void CallEvent(string a)
        {
            MessEvent(this, new EventArgs(a));
        }
    }
}
