using Education.Web.Client.Models.Inventory;
using Education.Web.Client.Models.Test;

namespace Education.Web.Client.Services.History.Test.Model;

public sealed record TestModel(TestOverview Overview, TestQuestion Question, TestInventoryModel[] Inventory);
