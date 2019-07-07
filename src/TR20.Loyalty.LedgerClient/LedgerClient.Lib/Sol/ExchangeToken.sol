pragma solidity ^0.4.21;

import "./EIP20.sol";
contract ExchangeToken {
    mapping(address => ExchangeInfo[]) public mappingHistory;
    
    struct ExchangeInfo
    {
        address sourceToken;
        address targetToken;
        uint256 exchangerate;
        uint256 amount;
        uint256 convertedAount;
        uint256 transactTime;
    }
    
   function Exchange(address txOwner,address exchangeMarketAddress, address sourceTokenAddress, address targetTokenAddress, uint256 exchangerate, uint256 tokenAmount) public 
   returns (bool success)
   {
       EIP20 _sourceTokenErc20 = EIP20(sourceTokenAddress);
       EIP20 _targetTokenErc20 = EIP20(targetTokenAddress);
       
       
       //check token amount
       uint256 _balance = _sourceTokenErc20.balanceOf(txOwner); 
       
       require( _balance >= tokenAmount);
       require( tokenAmount >= 10);
       
       //_sourceTokenErc20.approve()
       _sourceTokenErc20.transferFrom(txOwner,exchangeMarketAddress, tokenAmount);
       
       //safe code
       uint256 convertedAmountToken = tokenAmount * exchangerate / 100;
       
       //_sourceTokenErc20.transfer
       _targetTokenErc20.transferFrom(exchangeMarketAddress, txOwner, convertedAmountToken);
        
        //recording histroy
        mappingHistory[txOwner].push(ExchangeInfo(sourceTokenAddress, targetTokenAddress, exchangerate, tokenAmount, convertedAmountToken, now));
        //emit
        emit ExchangeEvent(txOwner, sourceTokenAddress, targetTokenAddress, exchangerate, tokenAmount, convertedAmountToken);
    
        return true;    
   }

    event ExchangeEvent(address txOwner,address sourceTokenAddress, address targetTokenAddress, uint256 exchangerate, uint256 tokenAmount, uint256 convertedAmount);
}

