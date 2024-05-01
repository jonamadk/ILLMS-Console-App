using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Inter_Library_Mgmt_System.models;
using Newtonsoft.Json;

namespace Inter_Library_Mgmt_System.services
{
    public class RegisteredUserHandler
    {
        private string filePath;
        private string user_chosen;

        

        public RegisteredUserHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public List<string> GetRegisteredUsers()
        {
            string json = File.ReadAllText(this.filePath);
            List<RegisteredUser> users = JsonConvert.DeserializeObject<List<RegisteredUser>>(json) ?? new List<RegisteredUser>();
            List<string> registeredEmails = new List<string>();

            foreach (RegisteredUser user in users)
            {
                if (user != null && user.IsRegistered)
                {
                    registeredEmails.Add(user.Email);
                    if (!DataMapper.registeredUserMap.ContainsKey(user.Email)) {
                        DataMapper.registeredUserMap.Add(user.Email, user);
                    }

                }
            }
           



            return registeredEmails;
        }

        public string SelectUserFromList(List<string> users)
        {
            Console.WriteLine("Registered Users:");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i]}");
            }

            Console.Write("Please enter the number corresponding to the user you want to select: ");
            string input = Console.ReadLine();

            int selectedIndex;
            if (int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= users.Count)
            {
                string user_chosen = users[selectedIndex - 1];
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
