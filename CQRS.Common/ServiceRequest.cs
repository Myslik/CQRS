using System;

namespace CQRS.Common
{
    public class ServiceRequest : AggregateRoot
    {
        private Guid id;

        public ServiceRequest(Guid id, string name)
        {
            Register<ServiceRequestCreated>(Apply);

            ApplyChange(new ServiceRequestCreated(id, name));
        }

        private void Register<TEvent>(Action<TEvent> apply) where TEvent : Event
        {
            throw new NotImplementedException();
        }

        private void Apply(ServiceRequestCreated e)
        {
            id = e.Id;
        }

        public override Guid Id
        {
            get { return id; }
        }
    }
}
