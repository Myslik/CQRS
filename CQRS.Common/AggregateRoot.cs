using System;
using System.Collections.Generic;

namespace CQRS.Common
{
    public abstract class AggregateRoot
    {
        private readonly List<Event> changes = new List<Event>();
        private readonly Dictionary<Type, Action<Event>> actors = new Dictionary<Type, Action<Event>>();

        public abstract Guid Id { get; }
        public int Version { get; internal set; }

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return changes;
        }

        public void MarkChangesAsCommitted()
        {
            changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach(var e in history)
            {
                ApplyChange(e, false);
            }
        }

        protected void Register<TEvent>(Action<TEvent> apply) where TEvent : Event
        {
            //actors.Add(typeof(TEvent), apply);
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(Event @event, bool isNew)
        {
            // TODO: Call private Apply in implementing class
            if (isNew)
            {
                changes.Add(@event);
            }
        }
    }
}
