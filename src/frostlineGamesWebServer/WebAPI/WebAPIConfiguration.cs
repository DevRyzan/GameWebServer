namespace WebAPI;

public class WebAPIConfiguration
{
    public string APIDomain { get; set; }
    public string[] AllowedOrigins { get; set; }

    public WebAPIConfiguration()
    {
        APIDomain = string.Empty;
        AllowedOrigins = Array.Empty<string>();
    }

    public WebAPIConfiguration(string apiDomain, string[] allowedOrigins)
    {
        APIDomain = apiDomain;
        AllowedOrigins = allowedOrigins;
    } 
}
