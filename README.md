[![License](https://img.shields.io/badge/License-Apache--2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)

# Byndyusoft.Net.YandexAuth [![Nuget](https://img.shields.io/nuget/v/ExampleProject.svg)](https://www.nuget.org/packages/ExampleProject/)[![Downloads](https://img.shields.io/nuget/dt/ExampleProject.svg)](https://www.nuget.org/packages/ExampleProject/)

The package contains an implementation for authentication and authorization with the Yandex ID service. The implemented service is capable of:
- Creating a redirection link for the user to authenticate with Yandex ID.
- Retrieving user authentication data based on the code from the service.
- Retrieving authentication data based on a refresh token.
- Retrieving user data from the Yandex ID system.

## Installing

```shell
dotnet add package Byndyusoft.Net.YandexAuth
```

## Usage


- To use this package, first add the Yandex ID service parameters to the configuration:
```json
"YandexIdOptions": {
       "ClientId": "<your client id>",
       "ClientSecret": "<your client secret>"
   }
```
   More details on registering the application and obtaining these parameters can be found at the [provided link](https://yandex.ru/dev/id/doc/en/register-client).
- Register the service for working with Yandex ID in the ConfigureServices method:
```csharp
   // IServiceCollection
   services.AddYandexAuthorization(Configuration);
```
- Retrieving service from DI.
```csharp
public class MyClass
{
    private readonly IYandexAuthService _yandexAuthService;

    public MyClass(IYandexAuthService service)
    {
        _yandexAuthService = service;
    }
}
```
- Generate a link for user authentication in the Yandex ID service ([documentation](https://yandex.ru/dev/id/doc/en/codes/code-url)):
   In this implementation, the "redirect_uri" and "state" fields are used to create the link.
```csharp
var redirectLink = _yandexAuthService.GetYandexAuthLink("<your-application-page-link>", "optional parameters");
```
- Obtain user authentication data based on the code.
```csharp
    var authenticateDataResult = await _yandexAuthService.GetAuthenticationDataByCodeAsync("<code-from-yandex-id>", cancellationToken);
```
- Obtain user authentication data based on the refresh token.
```csharp
    var authenticateData = await _yandexAuthService.GetAuthenticationDataByRefreshTokenAsync("<yandex-id-refresh-token>", cancellationToken);
```
- Retrieve user data from the Yandex ID service.
```csharp
    var yandexUserInfoResult = await _yandexAuthService.GetUserInfo("<yandex-id-access-token>", cancellationToken);
```

# Contributing

To contribute, you will need to setup your local environment, see [prerequisites](#prerequisites). For the contribution and workflow guide, see [package development lifecycle](#package-development-lifecycle).

## Prerequisites

Make sure you have installed all of the following prerequisites on your development machine:

- Git - [Download & Install Git](https://git-scm.com/downloads). OSX and Linux machines typically have this already installed.
- .NET (.net version) - [Download & Install .NET](https://dotnet.microsoft.com/en-us/download/dotnet/).

## Package development lifecycle

- Implement package logic in `src`
- Add or change the documentation as needed
- Open pull request in the correct branch. Target the project's `master` branch

# Maintainers
[github.maintain@byndyusoft.com](mailto:github.maintain@byndyusoft.com)