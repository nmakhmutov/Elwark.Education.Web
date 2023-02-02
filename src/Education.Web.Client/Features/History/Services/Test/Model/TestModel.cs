using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Features.History.Services.Test.Model;

public sealed record TestModel(TestOverview Overview, TestQuestion Question, TestInventoryModel[] Inventory);
