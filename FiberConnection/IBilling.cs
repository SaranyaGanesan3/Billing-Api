using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingAPI.FiberConnection
{
    public interface IBilling<Billing>
    {
        public Task<Billing> FindByID(int id);
        public Task<int> AddStatusBilling(Billing b);
        public int AddBilling(Billing b,int id,int c_id);
    }
}
