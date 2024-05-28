using Microsoft.AspNetCore.Identity;

namespace Project_5.CustomDescriber
{
    public class CustomErrorDescriber :IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Password is too short min 6"
            };
            // return base.PasswordTooShort(length);
        }
    }
}