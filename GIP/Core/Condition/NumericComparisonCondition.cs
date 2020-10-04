using System;
using System.Collections.Generic;
using GIP.IO.Json;
using GIP.IO.Project;

namespace GIP.Core.Condition
{
    public interface INumericSource
    {

    }

    public interface IIntSource : INumericSource
    {
        int Value { get; }
    }

    public class IntSource : IIntSource
    {
        public int Value
        { get; set; } = 0;
    }

    public interface IFloatSource : INumericSource
    {
        float Value { get; }
    }

    public abstract class NumericComparisonCondition : ConditionBase
    {
        public static NumericComparisonCondition CreateByType(string inType)
        {
            switch (inType) {
                case "Int":
                    return new IntComparisonCondition();
                case "Float":
                    return new FloatComparisonCondition();
            }
            return null;
        }

        public INumericSource Left
        { get; set; } = null;
        public INumericSource Right
        { get; set; } = null;

        public ComparisonOperator Operator
        { get; set; } = ComparisonOperator.Equals;

        public override bool Fulfill(ILogger inLogger)
        {
            if ((Left == null) || (Right == null)) {
                string message ="";
                if ((Left == null) && (Right == null)) {
                    message = $"Parameter [{nameof(Left)}] and [{nameof(Right)}] is not set.";
                } else if (Left == null) {
                    message = $"Parameter [{nameof(Left)}] is not set.";
                } else {
                    message = $"Parameter [{nameof(Right)}] is not set.";
                }
                throw new NullReferenceException(message);
            }
            return true;
        }

        protected abstract string NumericType { get; }

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonNumericComparisonCondition) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            var src = inSource as JsonNumericComparisonCondition;
            Operator = src.Operator;

            return true;
        }

        protected override JsonDataObject CreateJson() => new JsonNumericComparisonCondition();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonNumericComparisonCondition;
            dst.Type = NumericType;
            dst.Operator = Operator;
            return;
        }
    }

    public sealed class IntComparisonCondition : NumericComparisonCondition
    {
        public override bool Fulfill(ILogger inLogger)
        {
            base.Fulfill(inLogger);
            return Operator.Compare(Left.Value, Right.Value);
        }

        public new IIntSource Left
        { get; set; } = null;
        public new IIntSource Right
        { get; set; } = null;

        protected override string NumericType => "Int";
    }

    public sealed class FloatComparisonCondition : NumericComparisonCondition
    {
        public override bool Fulfill(ILogger inLogger)
        {
            base.Fulfill(inLogger);
            return Operator.Compare(Left.Value, Right.Value);
        }

        public new IFloatSource Left
        { get; set; } = null;
        public new IFloatSource Right
        { get; set; } = null;

        protected override string NumericType => "Float";
    }
}
