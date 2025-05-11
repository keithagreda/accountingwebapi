namespace accountingwebapi.Errors
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        // Factory method for custom errors
        public static Error Custom(string code, string message) => new Error(code, message);

        public override string ToString() => $"{Code}: {Message}";

        // Equality overrides (optional but helpful)
        public override bool Equals(object obj) =>
            obj is Error other && Code == other.Code && Message == other.Message;

        public override int GetHashCode() => HashCode.Combine(Code, Message);
    }
}
