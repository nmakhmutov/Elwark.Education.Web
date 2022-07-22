using Education.Web.Services.Model.Inventory;
using Education.Web.Services.Model.Test;

namespace Education.Web.Services.History.Test.Model;

public sealed record TestAnswerModel(
    TestOverviewModel Overview,
    AnswerResultModel Answer,
    TestQuestionModel? NextQuestion,
    TestInventoryItemModel[] Inventory
);
