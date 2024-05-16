using Microsoft.AspNetCore.Authorization;

namespace MVCAPIBiblioteca.Autorization
{
    public class CheckAdmim : IAuthorizationRequirement
    {
        public CheckAdmim(int role)
        {
            Role = role;
        }
        public int Role { get; set; }
    }
}
