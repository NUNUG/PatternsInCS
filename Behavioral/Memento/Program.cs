using System;
using System.Linq;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Execute();
        }

        private void Execute()
        {
            DataStore store = new DataStore();
            Enumerable.Range(1, 3)
                .Select(i => i.ToString())
                .ToList()
                .ForEach(s => store.AddValue(s));
            store.Show();

            // Object type is System.Object, because memento must be a black box.
            object memento = store.GetMemento();    

            Console.WriteLine("Wiping out all data.");
            store.Clear();
            store.Show();

            
            store.RestoreFromMemento(memento);
            store.Show();
        }
    }

}
