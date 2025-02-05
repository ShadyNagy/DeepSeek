using System;
using System.Collections.Generic;
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
  private List<DeepSeekMessage> _messages;

  public DeepSeekClient(HttpClient httpClient, DeepSeekSettings settings)
  {
    _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    _messages = new List<DeepSeekMessage>
            {
                new DeepSeekMessage("system", _settings.SystemMessage)
            };
  }

  public async Task<string> SendMessageAsync(string userMessage, DeepSeekModel model = DeepSeekModel.V3, int temperature = 1)
  {
    if (string.IsNullOrWhiteSpace(userMessage))
      throw new ArgumentException("Message cannot be empty", nameof(userMessage));

    _messages.Add(new DeepSeekMessage("user", userMessage));

    var modelName = model switch
    {
      DeepSeekModel.V3 => "deepseek-chat",
      DeepSeekModel.R1 => "deepseek-reasoner",
      _ => "deepseek-chat"
    };

    var requestPayload = new
    {
      temperature = temperature,
      model = modelName,
      messages = _messages,
      stream = false
    };

    var jsonOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
      PropertyNameCaseInsensitive = true
    };
    var json = JsonSerializer.Serialize(requestPayload, jsonOptions);
    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

    _httpClient.DefaultRequestHeaders.Clear();
    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_settings.ApiKey}");
    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

    var response = await _httpClient.PostAsync($"{_settings.BaseApi}/chat/completions", requestContent);
    response.EnsureSuccessStatusCode();

    var responseJson = await response.Content.ReadAsStringAsync();
    var parsedResponse = JsonSerializer.Deserialize<DeepSeekResponse>(responseJson, jsonOptions);
    var assistantReply = parsedResponse?.Choices?[0]?.Message?.Content ?? "No response";

    _messages.Add(new DeepSeekMessage("assistant", assistantReply));
    return assistantReply;
  }

  public void ClearMessages()
  {
    _messages.Clear();
    _messages.Add(new DeepSeekMessage("system", _settings.SystemMessage));
  }

  public List<DeepSeekMessage> GetMessages()
  {
    return _messages;
  }
}
