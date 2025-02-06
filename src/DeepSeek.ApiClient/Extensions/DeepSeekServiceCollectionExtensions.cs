using System;
using DeepSeek.ApiClient.Interfaces;
using DeepSeek.ApiClient.Models;
using DeepSeek.ApiClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeepSeek.ApiClient.Extensions;
public static class DeepSeekServiceCollectionExtensions
{
  public static IServiceCollection AddDeepSeekClient(this IServiceCollection services, string apiKey, string? baseApi = null, string systemMessage = "You are a helpful assistant.")
  {
    if (string.IsNullOrWhiteSpace(apiKey))
      throw new ArgumentNullException(nameof(apiKey), "API Key cannot be null or empty");

    var settings = new DeepSeekSettings(systemMessage);

    services.AddSingleton(settings);
    services.AddHttpClient<IDeepSeekClient, DeepSeekClient>(client =>
    {
      client.BaseAddress = new Uri(baseApi?? "https://api.deepseek.com");
      client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
      client.DefaultRequestHeaders.Add("Accept", "application/json");
    });


    return services;
  }
}
