using System;

namespace CQRS.Common
{
    public class ServiceRequestCreated : Event
    {
        public readonly Guid Id;
        public readonly string Name;

        public ServiceRequestCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
