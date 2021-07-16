using Education.Client.Gateways;
using Education.Client.Gateways.Models.Test;
using Microsoft.Extensions.Localization;

namespace Education.Client
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

        public string Localize(TestStatus status) => _localizer[$"TestStatus:{status}"].Value;
    }
}
