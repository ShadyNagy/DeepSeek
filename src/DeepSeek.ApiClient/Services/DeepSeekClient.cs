using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DeepSeek.ApiClient.Interfaces;
using DeepSeek.ApiClient.Models;

namespace DeepSeek.ApiClient.Services;
public class DeepSeekClient : IDeepSeekClient
{
  private readonly HttpClient _httpClient;
  private readonly DeepSeekSettings _settings;
  private readonly JsonSerializerOptions _jsonOptions = new()
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNameCaseInsensitive = true
  };

  public DeepSeekClient(HttpClient httpClient, DeepSeekSettings settings)
  {
    _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    _settings = settings ?? throw new ArgumentNullException(nameof(settings));
  }
  public async Task<string> SendMessageAsync(DeepSeekRequest request)
  {
    var json = JsonSerializer.Serialize(request, _jsonOptions);
    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

    var response = await _httpClient.PostAsync($"/chat/completions", requestContent);
    response.EnsureSuccessStatusCode();

    var responseJson = await response.Content.ReadAsStringAsync();
    var parsedResponse = JsonSerializer.Deserialize<DeepSeekResponse>(responseJson, _jsonOptions);
    var assistantReply = parsedResponse?.Choices?[0]?.Message?.Content ?? "No response";

    return assistantReply;
  }  
    
  public async Task<string> SendMessageAsync(string userMessage, DeepSeekModel model = DeepSeekModel.V3)
  {
    if (string.IsNullOrWhiteSpace(userMessage))
      throw new ArgumentException("Message cannot be empty", nameof(userMessage));

    var request = new DeepSeekRequestBuilder()
      .SetModel(model)
      .SetStream(false);

    if (!string.IsNullOrEmpty(_settings.SystemMessage))
    {
      request.AddSystemMessage(_settings.SystemMessage);
    }
    request.AddUserMessage(userMessage);

    return await SendMessageAsync(request.Build());
  } 
}
