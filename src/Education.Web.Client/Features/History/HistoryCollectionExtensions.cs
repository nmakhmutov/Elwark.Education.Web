using Education.Web.Client.Features.History.Clients;
using Education.Web.Client.Features.History.Clients.Article;
using Education.Web.Client.Features.History.Clients.Course;
using Education.Web.Client.Features.History.Clients.DateGuesser;
using Education.Web.Client.Features.History.Clients.Exchange;
using Education.Web.Client.Features.History.Clients.Flow;
using Education.Web.Client.Features.History.Clients.Leaderboard;
using Education.Web.Client.Features.History.Clients.Learner;
using Education.Web.Client.Features.History.Clients.Order;
using Education.Web.Client.Features.History.Clients.Quiz;
using Education.Web.Client.Features.History.Clients.Search;
using Education.Web.Client.Features.History.Clients.Store;
using Education.Web.Client.Features.History.Clients.User;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

internal static class HistoryCollectionExtensions
{
    public static WebAssemblyHostBuilder AddHistoryFeature(this WebAssemblyHostBuilder builder)
    {
        builder.Services
            .AddScoped<HistoryApiClient>()
            .AddScoped<IHistoryArticleClient, HistoryArticleClient>()
            .AddScoped<IHistoryCourseClient, HistoryCourseClient>()
            .AddScoped<IHistoryDateGuesserClient, HistoryDateGuesserClient>()
            .AddScoped<IHistoryExchangeClient, HistoryExchangeService>()
            .AddScoped<IHistoryFlowClient, HistoryFlowService>()
            .AddScoped<IHistoryLeaderboardClient, HistoryLeaderboardService>()
            .AddScoped<IHistoryLearnerClient, HistoryLearnerService>()
            .AddScoped<IHistoryOrderClient, HistoryOrderService>()
            .AddScoped<IHistorySearchClient, HistorySearchService>()
            .AddScoped<IHistoryStoreClient, HistoryStoreService>()
            .AddScoped<IHistoryQuizClient, HistoryQuizService>()
            .AddScoped<IHistoryUserClient, HistoryUserService>();

        return builder;
    }
}
