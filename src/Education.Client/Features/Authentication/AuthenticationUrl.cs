namespace Education.Client.Features.Authentication;

public static class AuthenticationUrl
{
    public const string LogOut = "/authentication/logout";

    public static string LogIn(string returnUrl) =>
        $"/authentication/login?returnUrl={Uri.EscapeDataString(returnUrl)}";
}
