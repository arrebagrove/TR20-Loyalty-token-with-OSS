pragma solidity ^0.4.21;
import "./EIP20.sol";
contract TokenRewarder {
    string public _name;
    address public _tokenContractAddress;
    address public _owner;

    function TokenRewarder(
        address tokenContractAddress,
        string rewarderName
    ) public {
        _owner = msg.sender;
        _tokenContractAddress = tokenContractAddress;
        _name = rewarderName;
	}


    function SendRewardToken(address recipient,
                            uint256 amount) public returns (bool success) {
		require(_owner == msg.sender);

        EIP20 _erc20 = EIP20(_tokenContractAddress);
        bool result = _erc20.transfer(recipient, amount);
        emit SendRewardTokenEvent(_owner, recipient, amount);
        return result;
    }

    event SendRewardTokenEvent(address _sender, address _recipient, uint256 _amount);
}