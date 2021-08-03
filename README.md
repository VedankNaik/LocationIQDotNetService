# LocationIQ Service #
Service is a .NET Core based application. This application makes use of Swagger UI for providing interface and documentation. It calls required [LocationIQ](https://locationiq.com) API's which returns response in JSON format.
* Clean Architecure, Repository pattern

* V2 controller calls some of the API's provided.
  * Can be used with [LocationIQLaravel](https://github.com/VedankNaik/LocationIQLaravel) Web Application which provides UI and perform DB opearations.
* V3 controller allows Angular Client [LocationIQAngular](https://github.com/VedankNaik/LocationIQAngular) to interact with this service/provides UI and service performs DB operations.

<hr>

* V2 Controller(With [LocationIQLaravel](https://github.com/VedankNaik/LocationIQLaravel)):<br/>
![Laravel project flow image](https://github.com/VedankNaik/LocationIQDotNetService/blob/main/LaravelFlow.png)

<hr>

* V3 Controller(With [LocationIQAngular](https://github.com/VedankNaik/LocationIQAngular)):<br/>
![Angular project flow image](https://github.com/VedankNaik/LocationIQDotNetService/blob/main/AngularFlow.png)


