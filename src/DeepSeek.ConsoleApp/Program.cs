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
    services.AddDeepSeekClient(AppConstants.API_KEY, AppConstants.BASE_URL, "You are a professional technical assistant.");

    var serviceProvider = services.BuildServiceProvider();
    var deepSeekClient = serviceProvider.GetRequiredService<IDeepSeekClient>();

    Console.WriteLine("Send message is started.");
    string response = await deepSeekClient.SendMessageAsync("How can I improve my C# skills?", DeepSeekModel.V3, 0);
    Console.WriteLine("Response: " + response);
  }
}
