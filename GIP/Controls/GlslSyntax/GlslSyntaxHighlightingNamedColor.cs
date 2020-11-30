using GIP.Common;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Collections.Generic;
using System.Windows.Media;

namespace GIP.Controls.GlslSyntax
{
    partial class GlslSyntaxHighlightingDefinition
    {
        private void SetupNamedHighlightingColors()
        {
            m_NamedHighlightingColors.Clear();

            AddNamedHighlightingColors(Keyword.Comment, 0, 192, 0);
            AddNamedHighlightingColors(Keyword.ValueType, 255, 0, 255);
            AddNamedHighlightingColors(Keyword.ControlFlow, 0, 0, 255);
            AddNamedHighlightingColors(Keyword.ValueQualifier, 128, 0, 0);
            AddNamedHighlightingColors(Keyword.ImageQualifier, 128, 0, 0);
            return;
        }

        private void AddNamedHighlightingColors(Keyword inKeyword, byte r, byte g, byte b)
        {
            m_NamedHighlightingColors.Add(inKeyword, new HighlightingColor {
                Name = inKeyword.GetExternalName(),
                Foreground = NewSolidBrush(r, g, b),
            });
            return;
        }

        private SyntaxHighlightingBrush NewSolidBrush(byte r, byte g, byte b)
            => new SyntaxHighlightingBrush {
                Brush = new SolidColorBrush(Color.FromArgb(255, r, g, b))
            };

        private Dictionary<Keyword, HighlightingColor> m_NamedHighlightingColors = new Dictionary<Keyword, HighlightingColor>();
    }
}
