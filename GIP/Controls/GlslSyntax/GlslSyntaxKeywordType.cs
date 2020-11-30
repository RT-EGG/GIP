using GIP.Common;

namespace GIP.Controls.GlslSyntax
{
    partial class GlslSyntaxHighlightingDefinition
    {
        public enum Keyword
        {
            [ExternalNamed("Comment")]
            Comment,
            [ExternalNamed("ValueType")]
            ValueType,
            [ExternalNamed("ControlFlow")]
            ControlFlow,
            [ExternalNamed("ValueModifier")]
            ValueQualifier,
            [ExternalNamed("ImageModifier")]
            ImageQualifier,
        }
    }
}
