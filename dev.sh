#!/usr/bin/env bash
echo "Running the dev server"

# Starting the DB
docker rm -f itemsInventory

# System cleanup
docker image prune -f
docker volume prune -f

echo "Finished cleaning up system"

# docker pull mongo

docker run -d -p 27017:27017 --name itemsInventory mongo
echo "Item Database is now online"

# Running the web server
dotnet run ./Program.cs
echo "Web server is now listening on port 5134"
