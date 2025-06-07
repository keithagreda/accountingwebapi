using static System.Runtime.InteropServices.JavaScript.JSType;

namespace accountingwebapi.Errors
{
    public static class Errors
    {
        public static readonly Error UninmplementedFunction = new("UninmplementedFunction", "This Feature Hasn't Been Implemented Yet!");

        public static class Generic
        {
            /// <summary>
            /// input function for tracking
            /// </summary>
            /// <param name="func"></param>
            /// <returns></returns>
            public static Error GenericError(string func, string? err) => new($"GenericError.{func}", $"Invalid Action! Something went wrong! {err}");
        }
        public static class Validation
        {
            public static Error RequiredField(string fieldName, string? func) =>
            Error.Custom("Validation.Required", $"{fieldName} is required. {func}");
            public static Error TooShort(string field, int minLength) =>
                new("Validation.TooShort", $"{field} must be at least {minLength} characters.");
            public static Error AlreadyExists(string field) =>
                new("Validation.AlreadyExists", $"{field} already exists.");
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

        public static class JournalEntry
        {
            public static readonly Error NotFound = new("JournalEntry.NotFound", "Journal Entry Not Found.");
        }

        public static class JournalEntryLine
        {
            public static readonly Error IsEmpty = new("JournalEntryLine.IsEmpty", "Invalid Action! Journal Entry Line Not Found!");
        }

        public static class AccountingPeriod
        {
            public static readonly Error NoOpen = new("AccountingPeriod.NoOpen", "Invalid Action! There is no open accounting period.");
            public static readonly Error ReachedEndDate = new("AccountingPeriod.ReachedEndDate", "Warning! Accounting Period Has Reached It's End Date!");
        }

        public static class EntryTemplate
        {
            public static readonly Error MatchinTemplateAlreadyExists = new("EntryTemplate.CheckIfExisting", "Matching template already exists");
            public static readonly Error DoesNotExist = new("EntryTemplate.CheckIfExisting", "Template Doesn't Exist!");
        }
        

    }
}
