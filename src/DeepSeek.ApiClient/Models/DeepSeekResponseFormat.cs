using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeepSeek.ApiClient.Models;
public class DeepSeekResponseFormat
{
  public string Type { get; set; }

  public DeepSeekResponseFormat(string type)
  {
    Type = type;
  }
}
