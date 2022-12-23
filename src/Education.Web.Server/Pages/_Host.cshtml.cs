using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Education.Web.Server.Pages;

public class HostModel : PageModel
{
    public IReadOnlyDictionary<uint, string> Images =>
        new Dictionary<uint, string>
        {
            [60] = "https://res.cloudinary.com/elwark/image/upload/v1613019539/Elwark/primary/60x60_eonbge.png",
            [152] = "https://res.cloudinary.com/elwark/image/upload/v1613019538/Elwark/primary/152x152_bmtbvw.png",
            [180] = "https://res.cloudinary.com/elwark/image/upload/v1613019538/Elwark/primary/180x180_hqniub.png",
            [192] = "https://res.cloudinary.com/elwark/image/upload/v1613019539/Elwark/primary/192x192_gavmwf.png",
            [310] = "https://res.cloudinary.com/elwark/image/upload/v1613019539/Elwark/primary/310x310_i8masa.png"
        };
}
