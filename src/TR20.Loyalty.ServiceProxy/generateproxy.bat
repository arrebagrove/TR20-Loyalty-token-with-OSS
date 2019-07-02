@echo off

echo ***********   Generate Ledger service Proxy
start nSwag swagger2csclient /input:http://localhost:8081/swagger/v1/swagger.json /classname:LedgerServiceProxy /namespace:TR20.Loyalty.LedgerClient.Proxy /output:LedgerClientProxy.cs

echo ***********   Generate Indexer Proxy
start nSwag swagger2csclient /input:http://localhost:8082/swagger/v1/swagger.json /classname:IndexerServiceProxy /namespace:TR20.Loyalty.TxIndexer.Proxy /output:IndexerProxy.cs

echo ***********   Generate Tracker Proxy
start nSwag swagger2csclient /input:http://localhost:8083/swagger/v1/swagger.json /classname:TrackerServiceProxy /namespace:TR20.Loyalty.TxTracker.Proxy /output:TrackerProxy.cs

echo ========>>> after generating all proxy classes, try compile it as Proxylib
