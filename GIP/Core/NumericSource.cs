namespace GIP.Core
{
    public interface INumericSource
    {

    }

    public interface IIntSource : INumericSource
    {
        int Value { get; }
    }

    public interface IFloatSource : INumericSource
    {
        float Value { get; }
    }

    public class IntSource : IIntSource
    {
        public IntSource(int inValue = default)
        {
            Value = inValue;
            return;
        }

        public int Value
        { get; set; } = 0;

        public static implicit operator int(IntSource inValue)
        {
            return inValue.Value;
        }

        public static implicit operator IntSource(int inValue)
        {
            return new IntSource(inValue);
        }
    }

    public class FloatSource : IFloatSource
    {
        public FloatSource(float inValue = default)
        {
            Value = inValue;
            return;
        }

        public float Value
        { get; set; } = 0.0f;

        public static implicit operator float(FloatSource inValue)
        {
            return inValue.Value;
        }

        public static implicit operator FloatSource(float inValue)
        {
            return new FloatSource(inValue);
        }
    }
}
