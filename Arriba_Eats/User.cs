using System.Security.Cryptography;

namespace Assignment_2B
{
    /// <summary>
    /// Represents a user of Arriba Eats
    /// </summary> 
    
    public class User
    {
        // A set of fields and properties to represent the user
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        protected int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
        }

        private string phoneNumber;
        protected string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }

        }
        private string userType;

        protected string UserType
        {
            get  { return userType; }
        }
        
        /// <summary>
        /// A constructor for the users class
        /// </summary>
        /// <param name="name">The name of the user</param>
        /// <param name="age">The age of the user</param>
        /// <param name="password">The password of the user</param>
        /// <param name="email">The email address of the user</param>
        /// <param name="phoneNumber">The phone number of the user</param>
        /// <param name="userType">The type of the user</param>
        protected User(string name, int age, string email, string phoneNumber, string password, string userType)
        {
            this.name = name;
            this.age = age;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.userType = userType;
        }
        
        /// <summary>
        /// A method to display the successful registration of user
        /// </summary>
        public virtual void GetUserInfo()
        {
            CmdLineUI.DisplayMessage("Your user details are as follows:" +
                                     $"\nName: {Name}" + $"\nAge: {Age}" 
                                     + $"\nEmail: {Email}" + $"\nMobile: {PhoneNumber}");
        }
        
        /// <summary>
        /// Displaying the user registration
        /// </summary>
        public virtual void DisplayMessageUser()
        {
            CmdLineUI.DisplayMessage($"You have been successfully registered as a {userType}, {Name}!");
        }
    }
    
}