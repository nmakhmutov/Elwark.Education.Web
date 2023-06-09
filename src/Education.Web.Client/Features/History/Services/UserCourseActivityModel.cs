namespace Education.Web.Client.Features.History.Services;

public sealed record UserCourseActivityModel(uint Completeness, bool IsStarted, bool IsBookmarked, bool? IsLiked);
