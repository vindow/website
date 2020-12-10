using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Activities.Core.Repository
{
    public interface IActivityRepository
    {
        public Task<List<Models.Activity>> Get();
    }
}
