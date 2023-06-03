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
```

- push the image to dockerhub
```
docker push dockeralexei/i-customsql:v1
```

- the image is now hosted on dockerhub
<img src="/pictures/dockerhub.png" title="image hosted on dockerhub"  width="900">
```

- push the image to *Azure Container Registry*
```
docker tag i-customsql alexeiregistry.azurecr.io/i-customsql:v1
az acr login --name alexeiregistry
docker push alexeiregistry.azurecr.io/i-customsql:v1
```

- the image is now hosted on azure
<img src="/pictures/dockerhub2.png" title="image hosted on azure"  width="900">
```

### Deploying the database

- grab the credential in the container registry in Azure and use them in the file *containersdb.yml*

- on the ubuntu command prompt, cd to the folder containing *containersdb.yml* and run
```
cd /mnt/c/source/.../path/to/folder/.../containersdb.yml
az container create --resource-group alexeirg --file containersdb.yml
```

- you should now see the container instance created and be able to connect to the db
<img src="/pictures/container_group.png" title="container group"  width="900">

### Deploying the application

- on the ubuntu command prompt, cd to the folder containing *containersdb.yml* and run
```
cd /mnt/c/source/.../path/to/folder/.../containersdb.yml
az container create --resource-group alexeirg --file containersapp.yml
```

- you should now see both container instances
<img src="/pictures/container_group2.png" title="container group"  width="900">

- and the app should be working and be able to retrieve data from the database
<img src="/pictures/container_group3.png" title="container group"  width="900">

### Persisting data

- publish BlobService app to an **Azure Container Registry**

- in your storage account, create a fileshare
<img src="/pictures/persisting_data.png" title="persisting data"  width="900">

- run 
```
az container create --resource-group alexeirg --file persistingData\containers.yml
```

- you should see the volume *filesharevolume* in the *AppGroup*
<img src="/pictures/persisting_data2.png" title="persisting data"  width="900">

- in the file share *containershare*, you should see the *Courses.json*
<img src="/pictures/persisting_data3.png" title="persisting data"  width="900">

### Container Groups using secrets

- publish BlobServiceSecret app to an **Azure Container Registry**
<img src="/pictures/using_secrets.png" title="using secrets"  width="900">

- grab the connection string of the storage account and paste it into *useOfSecrets\encode.ps1*

- run *useOfSecrets\encode.ps1* in order to encrypt the connection sting, and use the result in *containers.yml* for *volumesecret*

- run 
```
az container create --resource-group alexeirg --file useOfSecrets\containers.yml
```

- you should see the volume *filesharevolume* and *volumesecret* in the *AppGroup*
<img src="/pictures/using_secrets2.png" title="using secrets"  width="900">

- in the file share *containershare*, you should see the *Courses.json*
<img src="/pictures/using_secrets.png" title="using secrets"  width="900">
