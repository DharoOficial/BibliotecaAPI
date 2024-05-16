using Microsoft.AspNetCore.Authorization;

namespace MVCAPIBiblioteca.Autorization
{
    public class AdmimAuthorization : AuthorizationHandler<CheckAdmim>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CheckAdmim requirement)
        {
            var role = context.User.Claims.FirstOrDefault(x=>x.Type == "Role");
            if (role == null) 
                return Task.CompletedTask; 
            var value = Convert.ToInt32(role.Value);
            if (value == requirement.Role)
                context.Succeed(requirement);
            return Task.CompletedTask;
                
        }
    }
}
