using Inter_Library_Mgmt_System.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
// Assuming this is where UserRole class is defined

namespace Inter_Library_Mgmt_System.services
{
    public class UserRoleHandler
    {
        private string filePath;
       

        public UserRoleHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public List<string> GetUserRoles()
        {
            string json = File.ReadAllText(this.filePath);
           
            List<UserRole> roles = JsonConvert.DeserializeObject<List<UserRole>>(json) ?? new List<UserRole>();
            List<string> userRolesList = new List<string>();

            foreach (UserRole role in roles)
            {
                if (role != null)
                {
                    userRolesList.Add(role.RoleType);
                    //DataMapper.userRoleMap.Add(role.RoleType, role);
                }
            }

           

            return userRolesList;
        }


       

        public string SelectUserRoleFromList(List<string> roles)
        {
            Console.WriteLine("User Roles\n:");
            for (int i = 0; i < roles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {roles[i]}");
            }

            Console.Write("Assign the User Role:");
            string input = Console.ReadLine();

            int selectedIndex;
            if (int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= roles.Count)
            {
                string user_chosen = roles[selectedIndex - 1];
                return user_chosen;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return null;
            }
        }


    }
}
