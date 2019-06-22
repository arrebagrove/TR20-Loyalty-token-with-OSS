using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using TR20.Loyalty.OffChainRepository.Mongo.ModelBase;

namespace TR20.Loyalty.OffChainRepository.Mongo.Model
{
    public class TokenTransfer
    {
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string TokenAmount { get; set; }
        public string TokenAddress { get; set; }
        public string Description { get; set; }
    }
}