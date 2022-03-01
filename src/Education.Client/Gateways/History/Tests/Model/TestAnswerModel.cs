using Education.Client.Gateways.Models.Inventory;
using Education.Client.Gateways.Models.Test;

namespace Education.Client.Gateways.History.Tests.Model;

public sealed record TestAnswerModel(
    TestOverviewModel Overview,
    AnswerResultModel Answer,
    TestQuestionModel? NextQuestion,
    TestInventoryItemModel[] Inventory
);
