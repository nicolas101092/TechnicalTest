# Example CRQS with DDD

This project implements a solution with .Net Core 6. In addition, it meets the following requirements:
- It uses the DDD paradigm, using the application, infrastructure and domain layers in addition to the REST API.
and domain layers in addition to the REST API, i.e., the solution has 4 main projects: API,
Application, Infrastructure and Domain. Additionally, support projects have been created.
- The included database is an in-memory database, so every time the application is started the data will have to be inserted again. It does not include any startup data.
- Different design patterns are included.
- Includes example of unit tests for some methods of the application.
- Includes swagger package.


# Execution of the application

No configuration is required to run the application. As the Api is secured, a token must be obtained as follows:
**Method**: POST
**Url** : https://demo.duendesoftware.com/connect/token
**Content type**: application/x-www-form-urlencoded
**Body**: 
> Client_id: m2m
> client_secret: secret
> scope: api
> grant_type: client_credentials