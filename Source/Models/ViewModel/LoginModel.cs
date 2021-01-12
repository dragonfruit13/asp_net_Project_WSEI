using System.ComponentModel.DataAnnotations;

namespace asp_net_Project_WSEI.ViewModel
{
	public class LoginModel

	{
		[Required]
		public string UserName { get; set; }

		[Required]
		[UIHint("Password")]
		public string Password { get; set; }

		public string ReturnedURL { get; set; } = "/";
	}
}