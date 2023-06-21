namespace Education.Web.Client.Features.History.Services;

public sealed record UserCourseActivityModel(bool IsBookmarked, bool? IsLiked, uint? Completeness);
