<a name="top"></a>
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)
[![language](https://img.shields.io/badge/language-C%23-239120)](https://learn.microsoft.com/ru-ru/dotnet/csharp/tour-of-csharp/overview)
![OS](https://img.shields.io/badge/OS-linux%2C%20windows%2C%20macOS-0078D4)]
[![GitHub release](https://img.shields.io/github/v/release/waha-net/waha-net)](#)

⭐ Star us on GitHub — it motivates us a lot!

# Waha Aspire Hosting
Provides extension methods and resource definitions for the .NET Aspire AppHost to support running Waha containers.

### Installation
To install `Waha.Aspire.Hosting`, use the following command in your .NET Aspire AppHost project:

> dotnet add package Waha.Aspire.Hosting

### Usage
Below is a short example of how you can integrate `Waha.Aspire.Hosting` into your .NET Aspire AppHost project:

```csharp
using Aspire;
using Waha.Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var waha = builder.AddWaha("waha")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

builder.AddProject<Projects.API>("api")
    .WithReference(waha)
    .WaitFor(waha);
```
Explanation:

* `builder.AddWaha("waha")` registers a named container resource with default or custom settings.
* `.WithDataVolume()` attaches a persistent data volume to the container.
* `.WithLifetime(ContainerLifetime.Persistent)` ensures the container remains running across application restarts.

### Contributing
We welcome and appreciate contributions from the community. You can open a pull request or report issues through our [GitHub Issues](https://github.com/Waha-net/aspire-hosting-waha/issues/). Please review our contribution guidelines for details on coding standards and development practices.

### Feedback & Support
For any questions, issues, or ideas, feel free to reach out via:

* [GitHub Issues](https://github.com/Waha-net/aspire-hosting-waha/issues)
  
Your feedback helps us make `Waha.Aspire.Hosting` library even better!
