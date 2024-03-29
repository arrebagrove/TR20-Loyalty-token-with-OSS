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

namespace TR20.Loyalty.LedgerClient.Contracts.TokenRewarder
{


    public partial class TokenRewarderDeployment : TokenRewarderDeploymentBase
    {
        public TokenRewarderDeployment() : base(BYTECODE) { }
        public TokenRewarderDeployment(string byteCode) : base(byteCode) { }
    }

    public class TokenRewarderDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6060604052341561000f57600080fd5b604051610487380380610487833981016040528080519190602001805160028054600160a060020a03338116600160a060020a03199283161790925560018054928716929091169190911790559091019050600081805161007492916020019061007c565b505050610117565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106100bd57805160ff19168380011785556100ea565b828001600101855582156100ea579182015b828111156100ea5782518255916020019190600101906100cf565b506100f69291506100fa565b5090565b61011491905b808211156100f65760008155600101610100565b90565b610361806101266000396000f3006060604052600436106100615763ffffffff7c01000000000000000000000000000000000000000000000000000000006000350416635cf0346f8114610066578063abb06dfa14610095578063b2bdfa7b146100cb578063d28d8852146100de575b600080fd5b341561007157600080fd5b610079610168565b604051600160a060020a03909116815260200160405180910390f35b34156100a057600080fd5b6100b7600160a060020a0360043516602435610177565b604051901515815260200160405180910390f35b34156100d657600080fd5b610079610288565b34156100e957600080fd5b6100f1610297565b60405160208082528190810183818151815260200191508051906020019080838360005b8381101561012d578082015183820152602001610115565b50505050905090810190601f16801561015a5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b600154600160a060020a031681565b6002546000908190819033600160a060020a0390811691161461019957600080fd5b600154600160a060020a031691508163a9059cbb86866040517c010000000000000000000000000000000000000000000000000000000063ffffffff8516028152600160a060020a0390921660048301526024820152604401602060405180830381600087803b151561020b57600080fd5b5af1151561021857600080fd5b50505060405180516002549092507f4b302b3515c4585a42795bda270e1a118c3b10c2570e23cc29525dfd00f920889150600160a060020a03168686604051600160a060020a039384168152919092166020820152604080820192909252606001905180910390a1949350505050565b600254600160a060020a031681565b60008054600181600116156101000203166002900480601f01602080910402602001604051908101604052809291908181526020018280546001816001161561010002031660029004801561032d5780601f106103025761010080835404028352916020019161032d565b820191906000526020600020905b81548152906001019060200180831161031057829003601f168201915b5050505050815600a165627a7a7230582082b5ab5c137e91304daa8a3c2a562b8e81f0978e857cf991deca487a6e4fbeaa0029";
        public TokenRewarderDeploymentBase() : base(BYTECODE) { }
        public TokenRewarderDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "tokenContractAddress", 1)]
        public virtual string TokenContractAddress { get; set; }
        [Parameter("string", "rewarderName", 2)]
        public virtual string RewarderName { get; set; }
    }

    public partial class TokenContractAddressFunction : TokenContractAddressFunctionBase { }

    [Function("_tokenContractAddress", "address")]
    public class TokenContractAddressFunctionBase : FunctionMessage
    {

    }

    public partial class SendRewardTokenFunction : SendRewardTokenFunctionBase { }

    [Function("SendRewardToken", "bool")]
    public class SendRewardTokenFunctionBase : FunctionMessage
    {
        [Parameter("address", "recipient", 1)]
        public virtual string Recipient { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("_owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("_name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class SendRewardTokenEventEventDTO : SendRewardTokenEventEventDTOBase { }

    [Event("SendRewardTokenEvent")]
    public class SendRewardTokenEventEventDTOBase : IEventDTO
    {
        [Parameter("address", "_sender", 1, false )]
        public virtual string Sender { get; set; }
        [Parameter("address", "_recipient", 2, false )]
        public virtual string Recipient { get; set; }
        [Parameter("uint256", "_amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TokenContractAddressOutputDTO : TokenContractAddressOutputDTOBase { }

    [FunctionOutput]
    public class TokenContractAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
