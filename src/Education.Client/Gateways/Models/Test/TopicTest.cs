using System.Collections.Generic;
using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.Models.Test;

public sealed record TopicTest(TestPermission Permission, bool HasEasyTest, bool HasHardTest)
{
    public IEnumerable<TestType> TestTypes
    {
        get
        {
            if (HasEasyTest)
                yield return TestType.Easy;

            if (HasHardTest)
                yield return TestType.Hard;
        }
    }
}