using System.Collections.Generic;

namespace Elwark.Education.Web.Model
{
    public sealed record SubjectItem(
        SubjectType SubjectType,
        string Title,
        string Href,
        IDictionary<string, int> Statistics
    );
}