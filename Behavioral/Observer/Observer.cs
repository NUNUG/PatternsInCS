using System;
using System.Collections.Generic;
using System.Linq;

namespace Observer
{
    public interface IListener
    {
        void Trigger(Observer observer, object sender, string eventName, object payload);
        object Subscriber();
    }

    public class Listener: IListener
    {
        private object _subscriber;
        private Action<Observer, object, string, object> _callback;
        public Listener(object subscriber, Action<Observer, object, string, object> callback)
        {
            this._callback = callback;
            this._subscriber = subscriber;
        }

        public void Trigger(Observer observer, object sender, string eventName, object payload)
        {
            this._callback(observer, sender, eventName, payload);
        }

        public object Subscriber()
        {
            return _subscriber;
        }
    }

    public class Observer
    {
        private Dictionary<string, List<IListener>> _listeners;
        public Observer()
        {
            this._listeners = new Dictionary<string, List<IListener>>();
        }

        public void AddListener(string aEventName, IListener listener)
        {
            if (!this._listeners.ContainsKey(aEventName))
                this._listeners.Add(aEventName, new List<IListener>());
            this._listeners[aEventName].Add(listener);
        }
        public void RemoveListener(string aEventName, Listener listener)
        {
            this._listeners.Keys.ToList().ForEach(e => 
            {
                var toRemove =
                    this._listeners[e].Where(l => l.Equals(listener))
                        .ToList();
                toRemove.ForEach(r => this._listeners[e].Remove(r));
            });
        }
        public void RemoveSubscriber(string aEventName, object subscriber)
        {
            this._listeners.Keys.ToList().ForEach(e => 
            {
                var toRemove =
                    this._listeners[e].Where(l => l.Subscriber().Equals(subscriber))
                        .ToList();
                toRemove.ForEach(r => this._listeners[e].Remove(r));
            });
        }

        public void Trigger(object sender, string eventName, object payload)
        {
            if (this._listeners.ContainsKey(eventName))
            {
                var listenerList = this._listeners[eventName];
                listenerList.ForEach(l => l.Trigger(this, sender, eventName, payload));
            }
        }
    }
}