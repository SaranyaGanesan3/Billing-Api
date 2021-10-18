using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingAPI.FiberConnection;
using BillingAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BillingController));

        private readonly IBillingServ<Billing> serv_b;
        public BillingController(IBillingServ<Billing> _serv_b)
        {
            serv_b = _serv_b;
        }
        [HttpPost]
        public IActionResult AddBilling(Billing b, int id, int c_id)
        {
            _log4net.Info($"Getting the Bill For Customer");
            return Ok(serv_b.AddBilling(b, id, c_id));
        }
        [HttpPut]
        public async Task<IActionResult> AddStatusBilling(Billing b,int id)
        {
            _log4net.Info($"Adding the Bill With  {id}");
            return Ok(await serv_b.AddStatusBilling(b));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindByID(int id)
        {
            _log4net.Info($"Getting the Bill from {id}");
            return Ok(await serv_b.FindByID(id));
        }
    }
}
