using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Requests.Account;

public class WithdrawRequest
{
	[Required(ErrorMessage = "Deposit value is required")]
	[Range(1, int.MaxValue, ErrorMessage = "Withdraw value must be greater than 0")]
	public int Value { get; set; }
}