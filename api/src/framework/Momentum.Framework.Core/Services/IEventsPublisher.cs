using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace momentum.framework.core.Services
{
    public interface IEventsPublisher
    {
        Task Publish(IList<IInternalEvent> events);
    }
}
