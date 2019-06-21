cd TR20.Loyalty.LedgerClient\LedgerClient.Host
dotnet build
cd ..\..

cd TR20.Loyalty.TxIndexer\TxIndexer.Host
dotnet build
cd ..\..

cd TR20.Loyalty.TxTracker\TxTracker.Host
dotnet build
cd ..\..

docker build -f Dockerfile_ledgerclient --rm -t tr20loyalty/ledgerclient:latest .
docker build -f Dockerfile_indexer --rm -t tr20loyalty/txindexer:latest .
docker build -f Dockerfile_tracker --rm -t tr20loyalty/txtracker:latest .


docker tag tr20loyalty/ledgerclient:latest tr20loyalty.azurecr.io/tr20loyalty/ledgerclient:latest
docker tag tr20loyalty/txindexer:latest tr20loyalty.azurecr.io/tr20loyalty/txindexer:latest
docker tag tr20loyalty/txtracker:latest tr20loyalty.azurecr.io/tr20loyalty/txtracker:latest

docker login tr20loyalty.azurecr.io -u tr20loyalty -p 1JrZYh2wKzIb5VcBtHGJ=qhmKrZ7bZYC

docker push tr20loyalty.azurecr.io/tr20loyalty/ledgerclient:latest
docker push tr20loyalty.azurecr.io/tr20loyalty/txindexer:latest
docker push tr20loyalty.azurecr.io/tr20loyalty/txtracker:latest