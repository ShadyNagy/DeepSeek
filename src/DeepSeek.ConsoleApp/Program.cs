using Microsoft.Extensions.DependencyInjection;
using DeepSeek.ApiClient.Interfaces;
using DeepSeek.ApiClient.Extensions;
using DeepSeek.ApiClient.Models;

namespace DeepSeek.ConsoleApp;

internal class Program
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
