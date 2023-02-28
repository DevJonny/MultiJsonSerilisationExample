namespace MultiSerialisation;

public record PascalCaseRequest(string? IAmPedroNull, string? IAmPedroPascal) : BasePascalCaseRequest<PascalCaseRequest>;

public abstract record BasePascalCaseRequest<T>
{
    public static async ValueTask<T?> BindAsync(HttpContext context, ParameterInfo parameter) =>
        await JsonSerializer.DeserializeAsync<T>(
            context.Request.Body,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false
            });
}