using System;
using System.Collections.Generic;
using System.Text;
using Momentum.Framework.Core;

namespace Momentum.Activities.Core.Models
{
    public class Activity : AggregateRoot
    {
        public Guid id { get; private set; }
        public int type { get; private set; }
        public int data { get; private set; }
        public DateTime createdAt { get; private set; }
        public DateTime updatedAt { get; private set; }
        public Guid userID { get; private set; }

    }

}
