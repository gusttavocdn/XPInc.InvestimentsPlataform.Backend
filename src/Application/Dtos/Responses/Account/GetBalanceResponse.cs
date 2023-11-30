namespace Application.Dtos.Responses.Account;

public class GetBalanceResponse
{
	public decimal AvailableBalance { get; set; }

	public GetBalanceResponse(decimal availableBalance)
	{
		AvailableBalance = availableBalance;
	}
}