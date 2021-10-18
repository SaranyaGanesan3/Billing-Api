using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingAPI.FiberConnection;
using BillingAPI.Repository;

namespace BillingAPI.Service
{
    public class BillingServ : IBillingServ<Billing>
    {
        private readonly IBillingRepo<Billing> b_repo;
        public BillingServ(IBillingRepo<Billing> _b_repo)
        {
            b_repo = _b_repo;
        }
        public int AddBilling(Billing b, int id, int c_id)
        {
            return b_repo.AddBilling(b,id,c_id);
        }

        public async Task<int> AddStatusBilling(Billing b)
        {
            return await b_repo.AddStatusBilling(b);
        }

        public async Task<Billing> FindByID(int id)
        {
            return await b_repo.FindByID(id);
        }
    }
}
