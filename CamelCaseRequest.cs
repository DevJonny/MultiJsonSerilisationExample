namespace MultiSerialisation;

public record CamelCaseRequest(string? IShallBeNull, string? IShallBeACamel) : BaseCameCaseRequest<CamelCaseRequest>;

public abstract record BaseCameCaseRequest<T>
{
    public static async ValueTask<T?> BindAsync(HttpContext context, ParameterInfo parameter) =>
        await JsonSerializer.DeserializeAsync<T>(
            context.Request.Body, 
            new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = false
        });
}