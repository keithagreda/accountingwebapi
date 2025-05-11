using static System.Runtime.InteropServices.JavaScript.JSType;

namespace accountingwebapi.Errors
{
    public static class Errors
    {
        public static class Validation
        {
            public static Error RequiredField(string fieldName) =>
            Error.Custom("Validation.Required", $"{fieldName} is required.");
            public static Error TooShort(string field, int minLength) =>
                new("Validation.TooShort", $"{field} must be at least {minLength} characters.");
        }

        public static class User
        {
            public static readonly Error NotFound = new("User.NotFound", "User was not found.");
            public static readonly Error EmailAlreadyExists = new("User.EmailExists", "This email is already taken.");
        }

        public static class Auth
        {
            public static readonly Error InvalidCredentials = new("Auth.InvalidCredentials", "Invalid username or password.");
        }

        public static class Server
        {
            public static readonly Error Unexpected = new("Server.Unexpected", "An unexpected error occurred.");
        }
    }
}
