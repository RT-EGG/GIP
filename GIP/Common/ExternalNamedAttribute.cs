using System;

namespace GIP.Common
{
    public class ExternalNamedAttribute : Attribute
    {
        public ExternalNamedAttribute(string inName)
        {
            ExternalName = inName;
            return;
        }

        public string ExternalName
        { get; protected set; }
    }

    public static class ExternalNamedAttributeExtensions
    {
        public static string GetExternalName(this Enum inValue)
        {
            Type type = inValue.GetType();

            System.Reflection.FieldInfo info = type.GetField(inValue.ToString());
            if (info == null) {
                return inValue.ToString();
            }

            ExternalNamedAttribute[] atts = info.GetCustomAttributes(typeof(ExternalNamedAttribute), false) as ExternalNamedAttribute[];
            return atts.Empty() ? inValue.ToString() : atts[0].ExternalName;
        }
    }
}
