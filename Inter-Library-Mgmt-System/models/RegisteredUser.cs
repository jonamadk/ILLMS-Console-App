using Newtonsoft.Json;
namespace Inter_Library_Mgmt_System.models

{
    public class RegisteredUser
    {
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool IsRegistered { get; set; }
        public string RoleType { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public void display()
        {
            Console.WriteLine(JsonConvert.SerializeObject(this));
        }
    }

   
}
