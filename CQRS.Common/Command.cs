using System;

namespace CQRS.Common
{
    public class Command
    {
        public readonly Guid AggregateId;
        public readonly int Version;
        public readonly int UserId;
        public readonly Guid ProcessId;

        public Command(Guid aggregateId, int version, int userId) 
            : this(aggregateId, version, userId, Guid.NewGuid()) { }

        public Command(Guid aggregateId, int version, int userId, Guid processId)
        {
            AggregateId = aggregateId;
            Version = version;
            UserId = userId;
            ProcessId = processId;
        }
    }
}
