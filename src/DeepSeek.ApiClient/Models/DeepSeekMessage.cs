namespace DeepSeek.ApiClient.Models;
public class DeepSeekMessage
{
  public string Role { get; }
  public string Content { get; }

  public DeepSeekMessage(string role, string content)
  {
    Role = role;
    Content = content;
  }
}
