namespace GIP.Common
{
    public class ColorRGB
    {
        public ColorRGB()
        { }
        public ColorRGB(byte inR, byte inG, byte inB)
        {
            R = inR;
            G = inG;
            B = inB;
            return;
        }
        public ColorRGB(System.Drawing.Color inSystemColor)
            : this(inSystemColor.R, inSystemColor.G, inSystemColor.B)
        { }

        public virtual System.Drawing.Color ToSystemColor() => System.Drawing.Color.FromArgb(R, G, B);

        public byte R
        { get; set; } = 0;
        public byte G
        { get; set; } = 0;
        public byte B
        { get; set; } = 0;
    }

    public class ColorRGBA : ColorRGB
    {
        public ColorRGBA() : base()
        { }
        public ColorRGBA(byte inR, byte inG, byte inB, byte inA = 255)
            : base (inR, inG, inB)
        {
            A = inA;
            return;
        }

        public ColorRGBA(System.Drawing.Color inSystemColor)
            : base(inSystemColor)
        {
            A = inSystemColor.A;
            return;
        }

        public override System.Drawing.Color ToSystemColor() => System.Drawing.Color.FromArgb(A, R, G, B);

        public byte A
        { get; set; } = 0;
    }
}
