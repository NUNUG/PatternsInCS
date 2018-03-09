using System;
using System.Collections.Generic;

namespace Memento
{
    public class DataStore
    {
        private List<string> _items;
        public DataStore()
        {
            this._items = new List<string>();
        }
        public void Show()
        {
            Console.WriteLine("Store contents ---------------------------");
            _items.ForEach(s => Console.WriteLine(s));
        }

        public void Clear()
        {
            _items.Clear();
        }
        public int AddValue(string s)
        {
            this._items.Add(s);
            return this._items.Count - 1;
        }
        public void SetValue(int index, string s)
        {
            if ((index > 0) && (index <= this._items.Count -1))
                this._items[index] = s;
        }

        public object GetMemento()
        {
            Console.WriteLine("Writing state to memento.");
            return (object) new DataStoreMemento(this._items);
        }
        public void RestoreFromMemento(object memento)
        {
            Console.WriteLine("Restoring state from memento.");
            
            try
            {
                // Add other checks here if you want, such as memento.Originator.Equals(this).
                // Adjust the exception message accordingly.
                DataStoreMemento m = (DataStoreMemento) memento;
                List<string> state = m.GetState();
                this._items.Clear();
                this._items.AddRange(state);

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine($"Intercepted wrong type {e.ToString()}");
                throw new Exception($"Incorrect Memento Type {memento.GetType().FullName} for Originator of type {this.GetType().FullName}", e);
            }

        }

        // This class is private nested inside the datastore. 
        // Nobody can construct it or see its static type except the DataStore type.
        private class DataStoreMemento
        {
            private List<string> _state;

            public DataStoreMemento(List<string> state)
            {
                this._state = new List<string>(state);
            }
            public List<string> GetState()
            {
                return this._state;
            }
        }
    }
}
