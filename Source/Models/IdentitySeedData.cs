using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_Project_WSEI.Models
{
	public class IdentitySeedData
	{
		private const string Login = "Admin";
		private const string Password = "Admin12345!";

		public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
			IdentityUser user = await userManager.FindByIdAsync(Login);
			await userManager.CreateAsync(user, Password);
        }
	}
}