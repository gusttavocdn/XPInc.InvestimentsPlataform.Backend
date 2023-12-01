using Domain.Entities;

namespace Application.Dtos.Responses.Account;

public class GetTransactionsExtractResponse
{
	public IEnumerable<InvestmentTransaction> InvestmentsTransactions { get; set; } = null!;
	public IEnumerable<AccountTransaction> AccountTransactions { get; set; } = null!;
}
