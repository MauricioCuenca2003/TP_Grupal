using practicas.Models;

namespace practicas.basefake
{
    public class BaseFakeLogin
    {
        public static List<LoginModel> Users = new List<LoginModel>
        {
            new LoginModel
            {
                Id = 1,
                User ="admin",
                Password = "1234"

            },
            new LoginModel
            {
                Id = 2,
                User = "1234",
                Password =  "password"

            }
        };

    }
}
