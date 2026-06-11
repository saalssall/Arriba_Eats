

namespace A2;
using System.Security.Cryptography;

    /// <summary>
    /// Represents a user of Arriba Eats
    /// </summary> 
    
     abstract class User
    {
        // A set of fields to represent the user
        
        private string name;

        protected abstract string Name{get;set;}

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
        protected string UserType { get; set; }


        /// <summary>
        /// A constructor for the users class
        /// </summary>
        /// <param name="name">The name of the user</param>
        /// <param name="age">The age of the user</param>
        /// <param name="password">The password of the user</param>
        /// <param name="email">The email address of the user</param>
        /// <param name="phoneNumber">The phone number of the user</param>
        public User(string name, int age, string email, string phoneNumber, string password, string UserType)
        {
            this.name = name;
            this.age = age;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.UserType = UserType;
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
        public virtual void DisplayMessage()
        {
            CmdLineUI.DisplayMessage($"You have been successfully registered as a {UserType}, {Name}!");
        }
    }
    

