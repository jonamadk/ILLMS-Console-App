using System;
using Inter_Library_Mgmt_System.models;
namespace Inter_Library_Mgmt_System.services
{
	public class RoleManager
	{
		public RoleManager()
		{


		}

		public void assign(String email, String roleType)
		{
			
			RegisteredUser user = DataMapper.registeredUserMap[email];
			Console.WriteLine("Before updating the Role Type\n");
			user.display();
			user.RoleType = roleType;
            Console.WriteLine("After updating the Role\n");
            user.display();

		}
	}
}

