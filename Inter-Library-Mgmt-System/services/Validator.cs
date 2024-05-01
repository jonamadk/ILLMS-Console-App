using System;
using Inter_Library_Mgmt_System.models;
namespace Inter_Library_Mgmt_System.services
{
	public class Validator
	{
		public Validator()
		{
		}


		public Boolean validate(string email, string roleType)
		{
			return !(isNotValid(email) || isNotValid(roleType)); 
		}

		public Boolean isNotValid(String property)
		{
			return (property == null) || (property == "");
		}


	}
}

