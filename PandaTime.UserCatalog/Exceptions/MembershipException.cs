using System;
namespace PandaTime.UserCatalog.Exceptions
{
    public class MembershipException : Exception
    {
        public MembershipException()
        {
        }

        public MembershipException(string message)
            : base(message)
        {
        }

        public MembershipException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
