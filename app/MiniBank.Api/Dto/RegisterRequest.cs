namespace MiniBank.Api.Dto
{
    public record RegisterRequest(string Login, string Password, int? ClientId)
    {
    }
}
