using InventoryManager.Domain.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace InventoryManager.Views.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        //Vamos a guardar los detalles del inicio de sesión del usuario en el almacenamiento de sesion protegido
        private readonly ProtectedSessionStorage _sessionStorage;
        //Se necesita para  guardar la información de la sesion. 
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                //Se inspecciona el detalle de la sesion del usuario desde el almacenamiento.
                //Esto tambien permitira que los datos se guarden en formato clave valor, con esto almacenamos el detalle
                //de la sesión
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                //Condicion para devolver el estado de autenticacion del usuario anomimo, esto si la sesion es nula
                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                new Claim(ClaimTypes.Name, userSession!.UserName!),
                new Claim(ClaimTypes.Role, userSession!.Role!)
                }, "CustomAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
          
        }

        //Metodo para actualizar el estado de la autenticacion, se utilizara para cuando se haga 
        //login y logout
        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if(userSession != null)
            {
                //Login
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession!.UserName!),
                    new Claim(ClaimTypes.Role, userSession!.Role!)
                }));
            }
            else
            {
                //Logout
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
