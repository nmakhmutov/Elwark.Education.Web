namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record AccountingModel(BudgetModel[] Budget, ProfitModel[] Earnings, ProfitModel[] Expenses);
