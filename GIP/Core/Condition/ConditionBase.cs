namespace GIP.Core.Condition
{
    public abstract class ConditionBase : DataObjectBase
    {
        public abstract bool Fulfill(ILogger inLogger);
    }
}
