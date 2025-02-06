[![publish to nuget](https://github.com/ShadyNagy/DeepSeek/actions/workflows/nugt-publish.yml/badge.svg)](https://github.com/ShadyNagy/DeepSeek/actions/workflows/nugt-publish.yml)
[![DeepSeek.ApiClient on NuGet](https://img.shields.io/nuget/v/DeepSeek.ApiClient?label=DeepSeek.ApiClient)](https://www.nuget.org/packages/DeepSeek.ApiClient/)
[![NuGet](https://img.shields.io/nuget/dt/DeepSeek.ApiClient)](https://www.nuget.org/packages/DeepSeek.ApiClient)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/ShadyNagy/DeepSeek/blob/main/LICENSE)
[![paypal](https://img.shields.io/badge/PayPal-tip%20me-green.svg?logo=paypal)](https://www.paypal.me/shadynagy)

# DeepSeek API Client
Api for DeepSeek

## Overview
**DeepSeek.ApiClient** is a .NET library for interacting with the DeepSeek API, enabling developers to send and receive messages from DeepSeek’s AI models with ease.

## Features
- Supports DeepSeek models dynamically via an `enum`.
- Uses Dependency Injection (DI) for seamless integration.
- Allows customizable system messages.
- Handles API calls using `HttpClient` with built-in serialization.

## Installation
You can install the package via NuGet:
```sh
 dotnet add package DeepSeek.ApiClient
```

## Configuration
To integrate the `DeepSeek.ApiClient` into your .NET application, add the client to your dependency injection container:

```csharp
var services = new ServiceCollection();
services.AddDeepSeekClient("your-api-key");
var serviceProvider = services.BuildServiceProvider();
```

## Usage
### Basic Example
```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DeepSeekExample
{
  class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("Application is started.");
      var services = new ServiceCollection();
      services.AddDeepSeekClient(AppConstants.API_KEY);

      var serviceProvider = services.BuildServiceProvider();
      var deepSeekClient = serviceProvider.GetRequiredService<IDeepSeekClient>();

      Console.WriteLine("Send message is started.");
      var request = new DeepSeekRequestBuilder()
        .SetModel(DeepSeekModel.V3)
        .SetStream(false)
        .SetTemperature(0)
        .AddUserMessage("How can I improve my C# skills?");

      string response = await deepSeekClient.SendMessageAsync(request.Build());
      Console.WriteLine("Response: " + response);
    }
  }
}
```

### Using Enum for Model Selection
```csharp
string response = await deepSeekClient.SendMessageAsync("Explain SOLID principles", DeepSeekModel.DeepSeekV3);
```

### Handling Multiple Messages in a Conversation
```csharp
var messages = new List<string>
{
    "How can I improve my C# skills?",
    "What are the best design patterns in C#?",
    "Explain SOLID principles with examples."
};

foreach (var message in messages)
{
    string response = await deepSeekClient.SendMessageAsync(message);
    Console.WriteLine($"User: {message}\nAssistant: {response}\n");
}
```

## API Response Handling
The DeepSeek API returns structured responses. The library deserializes these responses into a `DeepSeekResponse` class, which includes:
- `Choices`: Contains the AI-generated message.
- `Usage`: Provides token usage details.
- `Model`: Identifies the DeepSeek model used.

## License
This package is released under the **MIT License**. See [LICENSE](LICENSE) for details.

## Contribution
Feel free to open issues or pull requests.
