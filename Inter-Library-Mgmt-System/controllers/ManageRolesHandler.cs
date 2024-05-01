using System;
using Inter_Library_Mgmt_System.services; 
using System.Collections.Generic;

namespace Inter_Library_Mgmt_System.controllers
{
    public class ManageRolesHandler
    {
        private RegisteredUserHandler registeredUserHandler;
        private UserRoleHandler userRoleHandler;
        private AssignUserRole assignUserRole;
        private Validator validator;

        public ManageRolesHandler(string filePath1, String filepath2)
        {
            registeredUserHandler = new RegisteredUserHandler(filePath1);
            userRoleHandler = new UserRoleHandler(filepath2);
            assignUserRole = new AssignUserRole();
            validator = new Validator();
        }

        public List<string> GetRegisteredUserEmails()
        {
            return registeredUserHandler.GetRegisteredUsers();
        }

        public string SelectUser()
        {
            // Get the list of registered users
            List<string> registeredUsersList = registeredUserHandler.GetRegisteredUsers();

            // Prompt the user to select a username
            string selectedUser = registeredUserHandler.SelectUserFromList(registeredUsersList);

            if (selectedUser != null)
            {
                Console.WriteLine($"Selected user: {selectedUser}");
            }
            else
            {
                Console.WriteLine("No user selected.");
            }
            return selectedUser;
        }

        public List<string> GetUserRoles()
        {
            return userRoleHandler.GetUserRoles();
        }

        public string SelectUserRole()
        {
            // Get the list of registered users
            List<string> userRoleHandlerlist = userRoleHandler.GetUserRoles();

            // Prompt the user to select a username
            string selectedUserRole = userRoleHandler.SelectUserRoleFromList(userRoleHandlerlist);

            if (selectedUserRole != null)
            {
                Console.WriteLine($"Selected user: {selectedUserRole}");
            }
            else
            {
                Console.WriteLine("No user selected.");
            }
            return selectedUserRole;
        }


        public void assign(String email, String roleType)
        {
            if (validator.validate(email, roleType))
            {
                Console.WriteLine("At least One User Role is Selected!");
                assignUserRole.assign(email, roleType);
            } else
            {
                Console.WriteLine("ERROR: Select at least one User Role!");
            }

        }


        
    }
}
