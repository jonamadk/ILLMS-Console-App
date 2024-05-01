using Inter_Library_Mgmt_System.controllers;
using Inter_Library_Mgmt_System.services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Path to the JSON file containing user data
        string userFilePathRegUser = @"/Users/manojadhikari/Projects/Inter-Library-Mgmt-System/Inter-Library-Mgmt-System/data/reg_user.json";
        string userFilePathUserRole = @"/Users/manojadhikari/Projects/Inter-Library-Mgmt-System/Inter-Library-Mgmt-System/data/user_roles.json";


        // Create an instance of ManageRolesHandler
        ManageRolesHandler manageRolesHandler = new ManageRolesHandler(userFilePathRegUser, userFilePathUserRole);

        // Retrieve registered user emails and print them
        List<string> registeredUserEmails = manageRolesHandler.GetRegisteredUserEmails();
        string selectedUser = manageRolesHandler.SelectUser();


        List<string> userRolesList = manageRolesHandler.GetUserRoles();
        string selectedUserRole = manageRolesHandler.SelectUserRole();

        // Assign
        manageRolesHandler.assign(selectedUser, selectedUserRole);

        //manageRolesHandler.assign(null, null);


        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
