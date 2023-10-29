namespace Api.Core.Extensions.Models;
public class CorsSettings
{
    public string[] Origins { get; set; }
    public string[] Methods { get; set; }
    public string[] Headers { get; set; }
    public string[] ExposedHeaders { get; set; }

}

