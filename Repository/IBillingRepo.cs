using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingAPI.Repository
{
    public interface IBillingRepo<Billing>
    {
        public Task<Billing> FindByID(int id);
        public Task<int> AddStatusBilling(Billing b);
        public int AddBilling(Billing b, int id, int c_id);
    }
}
