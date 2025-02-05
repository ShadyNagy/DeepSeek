using System;
using DeepSeek.ApiClient.Interfaces;
using DeepSeek.ApiClient.Models;
using DeepSeek.ApiClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeepSeek.ApiClient.Extensions;
public static class DeepSeekServiceCollectionExtensions
{
  public static IServiceCollection AddDeepSeekClient(this IServiceCollection services, string baseApi, string apiKey, string systemMessage = "You are a helpful assistant.")
  {
    if (string.IsNullOrWhiteSpace(apiKey))
      throw new ArgumentNullException(nameof(apiKey), "API Key cannot be null or empty");

    var settings = new DeepSeekSettings(baseApi, apiKey, systemMessage);

    services.AddSingleton(settings);
    services.AddHttpClient<IDeepSeekClient, DeepSeekClient>();


    return services;
  }
}
