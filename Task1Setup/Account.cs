using Task1Setup.PageObjects;

namespace Task1Setup
{
	public class Account
	{
		public string Email { get; }
		public string Password { get; }

		public Account(CreateAccountPage createdAccount)
		{
			Email = createdAccount.Email.Text;
			Password = createdAccount.DesiredPassword.Text;
		}
	}
}
