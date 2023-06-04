using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Repository.Constants
{
    public static class StatusRequest
    {
        public static class Actions
        {
            public const string Add = "Added";
            public const string Update = "Updated";
            public const string Delete = "Deleted";
            public const string Get = "Get";
            public const string AddFailed = "Add failed";
        }
        public static string AccessDenied = "Access Denied";
        public static string AddFailure = "Failed to add a new resource";
        public static string AddRangeFailure = "Failed to add a new list of resources";
        public static string AddSuccess = "New resource added successfully!";
        public static string DeleteFailure = "Failed to delete a resource";
        public static string DeleteSuccess = "Resource deleted successfully!";
        public static string EmailExist = "Email already in use";
        public static string ErrorOccurred = "An error occurred in ";
        public static string ExistCartItem = "Item is already in your cart";
        public static string GetDataSuccess = "Get Data Successfully";
        public static string GetDataFailed = "Get Data Failed";
        public static string IncorrectPassword = "Password is incorrect";
        public static string InvalidParameters = "The parameter's provided is/are invalid";
        public static string LoginFailure = "Invalid login request";
        public static string UpdateFailure = "Failed to update a resource";
        public static string UpdateSuccess = "Resource updated successfully!";
        public static string RegisterFailure = "Invalid register request";
        public static string InvalidId = "The ID provided is invalid. Must be greater than 0.";
        public static string NotMatch = "Id doesn't match";
        public static string NotFound = "The data with the provided parameters doesn't exist";
        public static string BookNotFound = "There is no Book found with the provided Book id";
        public static string EnrollBookNotFound = "There is no enrollment found with the provided Book id of the signed in User";
        public static string NOT_MATCH = "Id doesn't match";
        public static string LoginFailed = "Failed to login, please double check username and password !!!";
        public static string RESOURCE_NOTFOUND(string id) => $"{id} Not Found";
    }
}
