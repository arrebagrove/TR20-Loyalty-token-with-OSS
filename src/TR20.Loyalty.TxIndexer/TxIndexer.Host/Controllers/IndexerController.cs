using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TR20.Loyalty.TxIndexer.Library;
using TR20.Loyalty.OffChainRepository.Mongo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Numerics;
using Newtonsoft.Json.Linq;

namespace TR20.Loyalty.TxIndexer.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexerController : ControllerBase
    {
        private IConfiguration _configuration;
        private string _mongoConnectionString;
        public IndexerController(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoConnectionString = _configuration["offchain_connectionstring"];
        }


        [HttpPost()]
        [Route("LogTransaction")]
        public void LogTransaction([FromBody] ContractTransaction contractTransaction, string transactionDescription = "")
        {
            TransactionIndexer _agent = new TransactionIndexer(_mongoConnectionString);
            _agent.LogTransaction(contractTransaction, transactionDescription).GetAwaiter().GetResult();
        }


    }
}
