#docker stop $(docker ps -a -q)
#docker rm $(docker ps -a -q)

docker run -d -p 8080:80 --name ledgerapi tr20loyalty/serviceapi:latest 
docker run -d -p 8081:80 --name ledgerclient tr20loyalty/ledgerclient:latest
docker run -d -p 8082:80 --name txindexer tr20loyalty/txindexer:latest
docker run -d -p 8083:80 --name txtracker tr20loyalty/txtracker:latest