using System;
using System.Collections.Generic;
using System.Text;

namespace Momentum.Framework.Core
{

    public abstract class AggregateRoot
    {
        public IList<IInternalEvent> Events { get; private set; } = new List<IInternalEvent>();
        public void AddEvent(IInternalEvent @event)
        {
            Events.Add(@event);
        }
        public void Clear()
        {
            Events = new List<IInternalEvent>();
        }
    }
}
