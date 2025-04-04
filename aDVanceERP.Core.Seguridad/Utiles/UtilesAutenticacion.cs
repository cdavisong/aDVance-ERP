using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace aDVanceERP.Core.Seguridad.Utiles; 

public static class UtilesAutenticacion {
    #region Autenticación de Google :

    private static readonly string[] Scopes =
        { Oauth2Service.Scope.UserinfoProfile, Oauth2Service.Scope.UserinfoEmail };

    private static readonly string ApplicationName = "aDVanceERP.Desktop";
    private static UserCredential? credential;

    public static async Task<bool> Autenticar() {
        try {
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read)) {
                var credentialPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credentialPath, true));
            }

            return true;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error en la autenticación: {ex.Message}");
            return false;
        }
    }

    public static async Task<string> ObtenerNombreUsuario() {
        if (credential == null) throw new InvalidOperationException("Debe autenticarse primero.");

        var service = new Oauth2Service(new BaseClientService.Initializer {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });

        var me = await service.Userinfo.Get().ExecuteAsync();
        return me.Name;
    }

    public static async Task<string> ObtenerCorreoUsuario() {
        if (credential == null) throw new InvalidOperationException("Debe autenticarse primero.");

        var service = new Oauth2Service(new BaseClientService.Initializer {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });

        var me = await service.Userinfo.Get().ExecuteAsync();
        return me.Email;
    }

    public static async Task<string> ObtenerImagenUsuario() {
        if (credential == null) throw new InvalidOperationException("Debe autenticarse primero.");

        var service = new Oauth2Service(new BaseClientService.Initializer {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });

        var me = await service.Userinfo.Get().ExecuteAsync();
        return me.Picture;
    }

    //private async void Login() {
    //    bool autenticado = await UtilesAutenticacion.Autenticar();
    //    if (autenticado) {
    //        string nombreUsuario = await UtilesAutenticacion.ObtenerNombreUsuario();
    //        string correoUsuario = await UtilesAutenticacion.ObtenerCorreoUsuario();
    //        string imagenUsuario = await UtilesAutenticacion.ObtenerImagenUsuario();
    //    } else {
    //        MessageBox.Show("Error en el inicio de sesión.");
    //    }
    //}

    #endregion
}