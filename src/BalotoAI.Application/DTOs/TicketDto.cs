namespace BalotoAI.Application.DTOs
{
    public record TicketDto(Guid Id, Guid PlayerId, int[] Numbers, DateTime CreatedAt);
}
