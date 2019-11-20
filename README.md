# ConferenceService

This repo is one of the microservices for the NextGenConf.

## Description

We're running .NET Core 2.2.
The setup is also dependent on a mongo db instance running on localhost.

First, start up a mongo db instance.
You can run it using docker:
```
docker run -d -p 27017:27017 -v ~/data:/data/db mongo
```

To build, run:
```
dotnet build
```

To start the service:

```
dotnet .\ConferenceService\bin\Debug\netcoreapp2.2\ConferenceService.dll
```
