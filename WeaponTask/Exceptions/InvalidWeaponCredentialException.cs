namespace WeaponTask.Exceptions
{
    public class InvalidWeaponCredentialException : Exception
    {
        public InvalidWeaponCredentialException()
        {
        }

        public InvalidWeaponCredentialException(string? message) : base(message)
        {
        }
    }
}
