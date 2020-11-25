namespace Elwark.Education.Web.Model
{
    public sealed record SubjectItem(
        Subject Subject,
        string Title,
        string Href,
        string Avatar,
        int Topics,
        int Articles,
        int Questions
    );
}