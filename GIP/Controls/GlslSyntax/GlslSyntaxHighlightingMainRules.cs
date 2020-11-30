using ICSharpCode.AvalonEdit.Highlighting;
using System.Text.RegularExpressions;

namespace GIP.Controls.GlslSyntax
{
    partial class GlslSyntaxHighlightingDefinition
    {
        private void SetupMainRules()
        {
            AddKeywordRule(m_NamedHighlightingColors[Keyword.ValueType],
                "void",
                "bool", "int", "uint", "float", "double",
                "bvec2", "ivec2", "uvec2", "vec2", "dvec2",
                "bvec3", "ivec3", "uvec3", "vec3", "dvec3",
                "bvec4", "ivec4", "uvec4", "vec4", "dvec4",
                "mat2", "mat3", "mat4", "mat2x3", "mat2x4",
                "mat3x2", "mat3x4", "mat4x2", "mat4x3",
                //"image1D", "iimage1D", "uimage1D",
                "image2D", "iimage2D", "uimage2D"
                //"image3D", "iimage3D", "uimage3D",
                //"imageCube", "iimageCube", "uimageCube",
                //"image2DRect", "iimage2DRect", "uimage2DRect",
                //"image1DArray", "iimage1DArray", "uimage1DArray",
                //"image2DArray", "iimage2DArray", "uimage2DArray",
                //"imageCubeArray", "iimageCubeArray", "uimageCubeArray",
                //"imageBuffer", "iimageBuffer", "uimageBuffer",
                //"image2DMS", "iimage2DMS", "uimage2DMS",
                //"image2DMSArray", "iimage2DMSArray", "uimage2DMSArray"
                ); // Some of variable types is not supported in editor.

            AddKeywordRule(m_NamedHighlightingColors[Keyword.ControlFlow],
                "if", "else", "for", "while", "do", "break", "continue",
                "return", "switch", "case"
                );

            AddKeywordRule(m_NamedHighlightingColors[Keyword.ValueQualifier],
                "const", "uniform", "in", "out", "inout"
                );

            AddKeywordRule(m_NamedHighlightingColors[Keyword.ImageQualifier],
                "writeonly", "readonly", "readwrite"
                );

            return;
        }

        private void AddKeywordRule(HighlightingColor inColor, params string[] inKeywords)
        {
            m_MainRuleSet.Rules.Add(new HighlightingRule {
                Regex = new Regex($"\\b(?>{string.Join("|", inKeywords)})\\b"),
                Color = inColor
            }); ;
        }
    }
}
