using ICSharpCode.AvalonEdit.Highlighting;
using System.Text.RegularExpressions;

namespace GIP.Controls.GlslSyntax
{
    partial class GlslSyntaxHighlightingDefinition
    {
        private void SetupMainSpans()
        {
            m_MainRuleSet.Spans.Add(new HighlightingSpan {
                SpanColorIncludesStart = true,
                SpanColorIncludesEnd = true,
                StartExpression = new Regex("//"),
                EndExpression = new Regex("$"),
                SpanColor = m_NamedHighlightingColors[Keyword.Comment]
            });

            m_MainRuleSet.Spans.Add(new HighlightingSpan {
                SpanColorIncludesStart = true,
                SpanColorIncludesEnd = true,
                StartExpression = new Regex("/\\*"),
                EndExpression = new Regex("\\*/"),
                SpanColor = m_NamedHighlightingColors[Keyword.Comment]
            });
            return;
        }
    }
}
