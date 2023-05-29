# Develop Azure Compute Solutions - Container Groups and Kubernetes


## Container Groups

### Building a custom MySQL image

- on the ubuntu command prompt
```
cd /mnt/c/source/.../path/to/folder/.../Dockerfile
docker build -t i-customsql .
docker run -d -p 3307:3306 --name c-appsql i-customsql
docker exec -it c-appsql bash
```

- once logged into the container, log to sql
```
mysql -u root -p
```

- play with data to make sure the Course table has been properly created and populated

- tag the image
```
docker tag i-customsql dockeralexei/i-customsql:v1
docker push dockeralexei/i-customsql:v1
```

- the image is now hosted on dockerhub
<img src="/pictures/dockerhub.png" title="image hosted on dockerhub"  width="900">
