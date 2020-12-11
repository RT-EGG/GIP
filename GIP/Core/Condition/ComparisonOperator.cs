using GIP.Common;

namespace GIP.Core.Condition
{
    public enum ComparisonOperator
    {
        Equals,
        NotEquals,
        Greater,
        GreaterOrEquals,
        Less,
        LessOrEquals
    }

    public static class ComparisonOperatorExtensions
    { 
        public static bool Compare(this ComparisonOperator inComparer, int inLeft, int inRight)
        {
            switch (inComparer) {
                case ComparisonOperator.Equals:
                    return inLeft == inRight;
                case ComparisonOperator.NotEquals:
                    return inLeft != inRight;
                case ComparisonOperator.Greater:
                    return inLeft > inRight;
                case ComparisonOperator.GreaterOrEquals:
                    return inLeft >= inRight;
                case ComparisonOperator.Less:
                    return inLeft < inRight;
                case ComparisonOperator.LessOrEquals:
                    return inLeft <= inRight;
                default:
                    throw new UnknownEnumValueException<ComparisonOperator>(inComparer);
            }
        }

        public static bool Compare(this ComparisonOperator inComparer, float inLeft, float inRight)
        {
            switch (inComparer) {
                case ComparisonOperator.Equals:
                    return inLeft.AlmostEquals(inRight);
                case ComparisonOperator.NotEquals:
                    return !inLeft.AlmostEquals(inRight);
                case ComparisonOperator.Greater:
                    return inLeft > inRight;
                case ComparisonOperator.GreaterOrEquals:
                    return inLeft >= inRight;
                case ComparisonOperator.Less:
                    return inLeft < inRight;
                case ComparisonOperator.LessOrEquals:
                    return inLeft <= inRight;
                default:
                    throw new UnknownEnumValueException<ComparisonOperator>(inComparer);
            }
        }

        public static bool Compare(this ComparisonOperator inComparer, double inLeft, double inRight)
        {
            switch (inComparer) {
                case ComparisonOperator.Equals:
                    return inLeft.AlmostEquals(inRight);
                case ComparisonOperator.NotEquals:
                    return !inLeft.AlmostEquals(inRight);
                case ComparisonOperator.Greater:
                    return inLeft > inRight;
                case ComparisonOperator.GreaterOrEquals:
                    return inLeft >= inRight;
                case ComparisonOperator.Less:
                    return inLeft < inRight;
                case ComparisonOperator.LessOrEquals:
                    return inLeft <= inRight;
                default:
                    throw new UnknownEnumValueException<ComparisonOperator>(inComparer);
            }
        }

        public static bool Compare(this ComparisonOperator inComparer, decimal inLeft, decimal inRight)
        {
            switch (inComparer) {
                case ComparisonOperator.Equals:
                    return inLeft == inRight;
                case ComparisonOperator.NotEquals:
                    return inLeft != inRight;
                case ComparisonOperator.Greater:
                    return inLeft > inRight;
                case ComparisonOperator.GreaterOrEquals:
                    return inLeft >= inRight;
                case ComparisonOperator.Less:
                    return inLeft < inRight;
                case ComparisonOperator.LessOrEquals:
                    return inLeft <= inRight;
                default:
                    throw new UnknownEnumValueException<ComparisonOperator>(inComparer);
            }
        }
    }
}
