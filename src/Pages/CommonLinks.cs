namespace Education.Web.Pages;

public static class CommonLinks
{
    public const string Root = "/";

    public const string Account = "/account";

    public const string LogOut = "/authentication/logout";

    public static string LogIn(string returnUrl) =>
        $"/authentication/login?returnUrl={Uri.EscapeDataString(returnUrl)}";
}
