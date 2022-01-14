namespace Education.Client.Gateways.Models.Test;

public sealed record TopicAvailableTest(bool HasEasyTest, bool HasHardTest)
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
