using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingAPI.FiberConnection;

namespace BillingAPI.Repository
{
    public class BillingRepo : IBillingRepo<Billing>
    {
        private readonly IBilling<Billing> obj_bill;
        public BillingRepo(IBilling<Billing> _obj_bill)
        {
            obj_bill = _obj_bill;
        }
        public int AddBilling(Billing b, int id, int c_id)
        {
           return obj_bill.AddBilling(b,id,c_id);
        }

        public async Task<int> AddStatusBilling(Billing b)
        {
            return await obj_bill.AddStatusBilling(b);
        }

        public async Task<Billing> FindByID(int id)
        {
            return await obj_bill.FindByID(id);
        }
    }
}
