using Education.Web.Client.Services.Model.Inventory;
using Education.Web.Client.Services.Model.Test;

namespace Education.Web.Client.Services.History.Test.Model;

public sealed record TestAnswerModel(
    TestOverviewModel Overview,
    AnswerResultModel Answer,
    TestQuestionModel? NextQuestion,
    TestInventoryModel[] Inventory
);
