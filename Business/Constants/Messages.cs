using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Constants
{
    public static class Messages
    {

        public static string UserNameInvalid = "Kullanıcı adı geçersiz.";
        public static string UserAdded = "User Added successfully";
        public static string UserUpdated = "User Updated successfully";
        public static string UserDeleted = "User Deleted successfully";
        public static string FirstAndLastNameUpdated = "First And LastName Updated successfully";
        public static string EmailUpdated = "Email Updated successfully";
        public static string EmailUpEmailIsAlreadyRegistereddated = "Email Is Already Registereddated";
       
        
        
        public static string UserRegistered = "User registered successfully";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "Wrong Password";
        public static string SuccessfulLogin = "Login is successfully";
        public static string AccessTokenCreated = "Access Token Created successfully";
        public static string PasswordUpdated = "Password Updated successfully";
        public static string PasswordsDoNotMatch = "Passwords Do Not Match";
        
        
        public static string BrandAdded = "Brand Added successfully";

        public static string ColorAdded = "Color Added successfully";
        public static string ColorDeleted = "Color Deleted successfully";
        public static string ColorUpdated = "Color Updated successfully";
        public static string ColorNameInvalid = "Color Name Invalid";
       
        
        public static string ProductImageAdded = "ProductImage Added successfully";
        public static string ProductImageDeleted = "ProductImage Deleted successfully";
        public static string ProductImageUpdated = "ProductImage Updated successfully";
        public static string ProductImageDoesNotFound = "ProductImage Does Not Found";
        
        public static string AuthorizationDenied = "Authorization Denied";
        public static string ProductImageLimitExceeded = "ProductImage Limit Exceeded";


       
    }

  

    
}
