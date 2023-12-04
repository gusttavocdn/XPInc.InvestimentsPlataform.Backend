using Domain.Entities;

namespace Application.Dtos.Responses.Investments;

public class GetPortfolioResponse
{
	public IEnumerable<Portfolio> Portfolios { get; set; }

	public GetPortfolioResponse(IEnumerable<Portfolio> portfolios)
	{
		Portfolios = portfolios;
	}
}
