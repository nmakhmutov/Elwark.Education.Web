using Elwark.Education.Web.Gateways;
using Elwark.Education.Web.Gateways.Models;
using Microsoft.Extensions.Localization;

namespace Elwark.Education.Web
{
    public class ErrorManager
    {
        private readonly IStringLocalizer<ErrorManager> _localizer;

        public ErrorManager(IStringLocalizer<ErrorManager> localizer) =>
            _localizer = localizer;

        public Error Localize(Error error)
        {
            var type = _localizer[error.Type].Value;
            var title = _localizer[error.Type + ":" + error.Title].Value;

            return error with{Title = title, Type = type};
        }

        public string Localize(string key) => _localizer[key].Value;

        public string Localize(PermissionStatus status) => _localizer[$"UserRestriction:{status}"].Value;
    }
}