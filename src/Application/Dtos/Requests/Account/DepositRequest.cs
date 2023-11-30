using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Requests.Account;

public class DepositRequest
{
	[Required(ErrorMessage = "Deposit value is required")]
	[Range(1, int.MaxValue, ErrorMessage = "Deposit value must be greater than 0")]
	public int Value { get; set; }
}