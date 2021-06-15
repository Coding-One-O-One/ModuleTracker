Mistakes Made

Added too much, without needing it yet.
Should have started with the test methods.
Should have done the development top-down: Do demoable front-end first, then expand to services, and finally a repository.
The controller must not directly use the repo, but rather a service. As per: https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/ApiGateways/Mobile.Bff.Shopping/aggregator/Controllers/BasketController.cs

To Do

Add ModuleDependency controller
Add tests
Add client