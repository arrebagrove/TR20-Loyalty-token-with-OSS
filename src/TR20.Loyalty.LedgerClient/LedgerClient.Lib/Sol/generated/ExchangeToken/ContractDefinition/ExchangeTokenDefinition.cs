using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace TR20.Loyalty.LedgerClient.Contracts.ExchangeToken
{


    public partial class ExchangeTokenDeployment : ExchangeTokenDeploymentBase
    {
        public ExchangeTokenDeployment() : base(BYTECODE) { }
        public ExchangeTokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class ExchangeTokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6060604052341561000f57600080fd5b6104fc8061001e6000396000f3006060604052600436106100325763ffffffff60e060020a60003504166322bfc3d781146100375780638963973c14610082575b600080fd5b341561004257600080fd5b61006e600160a060020a036004358116906024358116906044358116906064351660843560a4356100e6565b604051901515815260200160405180910390f35b341561008d57600080fd5b6100a4600160a060020a03600435166024356103df565b604051600160a060020a0396871681529490951660208501526040808501939093526060840191909152608083015260a082019290925260c001905180910390f35b600084848280600160a060020a0384166370a082318c60405160e060020a63ffffffff8416028152600160a060020a039091166004820152602401602060405180830381600087803b151561013a57600080fd5b5af1151561014757600080fd5b50505060405180519250508582101561015f57600080fd5b600a86101561016d57600080fd5b83600160a060020a03166323b872dd8c8c8960405160e060020a63ffffffff8616028152600160a060020a0393841660048201529190921660248201526044810191909152606401602060405180830381600087803b15156101ce57600080fd5b5af115156101db57600080fd5b505050604051805150506064878702049050600160a060020a0383166323b872dd8b8d8460405160e060020a63ffffffff8616028152600160a060020a0393841660048201529190921660248201526044810191909152606401602060405180830381600087803b151561024e57600080fd5b5af1151561025b57600080fd5b50505060405180515050600160a060020a038b16600090815260208190526040902080546001810161028d838261043e565b9160005260206000209060060201600060c06040519081016040908152600160a060020a03808f1683528d16602083015281018b9052606081018a9052608081018590524260a08201529190508151815473ffffffffffffffffffffffffffffffffffffffff1916600160a060020a0391909116178155602082015160018201805473ffffffffffffffffffffffffffffffffffffffff1916600160a060020a039290921691909117905560408201518160020155606082015181600301556080820151816004015560a082015181600501555050507f36fd55be696cf34a2bc0a2499aaefa34927dbb5339334a7158170f355a7d7c148b8a8a8a8a86604051600160a060020a0396871681529486166020860152929094166040808501919091526060840191909152608083019390935260a082015260c001905180910390a15060019a9950505050505050505050565b6000602052816000526040600020818154811015156103fa57fe5b6000918252602090912060069091020180546001820154600283015460038401546004850154600590950154600160a060020a039485169750929093169450929086565b81548183558181151161046a5760060281600602836000526020600020918201910161046a919061046f565b505050565b6104cd91905b808211156104c957805473ffffffffffffffffffffffffffffffffffffffff199081168255600182018054909116905560006002820181905560038201819055600482018190556005820155600601610475565b5090565b905600a165627a7a7230582098bcf8c51c09c583484a13ecf8031237f0f94bea9b75129575ed61fb67683bb60029";
        public ExchangeTokenDeploymentBase() : base(BYTECODE) { }
        public ExchangeTokenDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ExchangeFunction : ExchangeFunctionBase { }

    [Function("Exchange", "bool")]
    public class ExchangeFunctionBase : FunctionMessage
    {
        [Parameter("address", "txOwner", 1)]
        public virtual string TxOwner { get; set; }
        [Parameter("address", "exchangeMarketAddress", 2)]
        public virtual string ExchangeMarketAddress { get; set; }
        [Parameter("address", "sourceTokenAddress", 3)]
        public virtual string SourceTokenAddress { get; set; }
        [Parameter("address", "targetTokenAddress", 4)]
        public virtual string TargetTokenAddress { get; set; }
        [Parameter("uint256", "exchangerate", 5)]
        public virtual BigInteger Exchangerate { get; set; }
        [Parameter("uint256", "tokenAmount", 6)]
        public virtual BigInteger TokenAmount { get; set; }
    }

    public partial class MappingHistoryFunction : MappingHistoryFunctionBase { }

    [Function("mappingHistory", typeof(MappingHistoryOutputDTO))]
    public class MappingHistoryFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("uint256", "", 2)]
        public virtual BigInteger ReturnValue2 { get; set; }
    }

    public partial class ExchangeEventEventDTO : ExchangeEventEventDTOBase { }

    [Event("ExchangeEvent")]
    public class ExchangeEventEventDTOBase : IEventDTO
    {
        [Parameter("address", "txOwner", 1, false )]
        public virtual string TxOwner { get; set; }
        [Parameter("address", "sourceTokenAddress", 2, false )]
        public virtual string SourceTokenAddress { get; set; }
        [Parameter("address", "targetTokenAddress", 3, false )]
        public virtual string TargetTokenAddress { get; set; }
        [Parameter("uint256", "exchangerate", 4, false )]
        public virtual BigInteger Exchangerate { get; set; }
        [Parameter("uint256", "tokenAmount", 5, false )]
        public virtual BigInteger TokenAmount { get; set; }
        [Parameter("uint256", "convertedAmount", 6, false )]
        public virtual BigInteger ConvertedAmount { get; set; }
    }



    public partial class MappingHistoryOutputDTO : MappingHistoryOutputDTOBase { }

    [FunctionOutput]
    public class MappingHistoryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "sourceToken", 1)]
        public virtual string SourceToken { get; set; }
        [Parameter("address", "targetToken", 2)]
        public virtual string TargetToken { get; set; }
        [Parameter("uint256", "exchangerate", 3)]
        public virtual BigInteger Exchangerate { get; set; }
        [Parameter("uint256", "amount", 4)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("uint256", "convertedAount", 5)]
        public virtual BigInteger ConvertedAount { get; set; }
        [Parameter("uint256", "transactTime", 6)]
        public virtual BigInteger TransactTime { get; set; }
    }
}
