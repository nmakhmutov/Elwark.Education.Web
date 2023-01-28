namespace Education.Web.Client.Services.History.User.Model;

public sealed record MoneyStatisticsModel(BudgetModel[] Budget, ProfitModel[] Earnings, ProfitModel[] Expenses);
