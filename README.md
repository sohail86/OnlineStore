# OnlineStore
API for Marketplace Store

# How to run project? 

First clone the repository locally and head into the `OnlineStore` folder and then run the following docker-compose command.
```sh
docker-compose up -d
```

Docker compose will create a SQL server container on post 1433 and a WebAPI container on 5000. Process will create the database and table for the application. It will also seed some data in the database. 
Follow the below link to access the swagger documentation.  

```
http://localhost:5000/swagger/index.html
```
