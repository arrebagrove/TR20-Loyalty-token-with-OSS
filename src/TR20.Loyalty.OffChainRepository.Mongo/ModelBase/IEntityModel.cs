using System;
using System.Collections.Generic;
using System.Text;

namespace TR20.Loyalty.OffChainRepository.Mongo.ModelBase
{
    public interface IEntityModel<TIdentifier>
    {
        TIdentifier Id { get; set; }
    }
}