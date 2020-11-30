using ICSharpCode.AvalonEdit.Highlighting;
using System.Collections.Generic;
using System.Linq;

namespace GIP.Controls.GlslSyntax
{
    partial class GlslSyntaxHighlightingDefinition : IHighlightingDefinition
    {
        public GlslSyntaxHighlightingDefinition()
        {
            SetupNamedHighlightingColors();
            SetupMainRules();
            SetupMainSpans();
            return;
        }

        string IHighlightingDefinition.Name => "GLSL";
        HighlightingRuleSet IHighlightingDefinition.MainRuleSet => m_MainRuleSet;
        IEnumerable<HighlightingColor> IHighlightingDefinition.NamedHighlightingColors => m_NamedHighlightingColors.Values;
        IDictionary<string, string> IHighlightingDefinition.Properties => m_Properties;

        Dictionary<string, string> m_Properties = new Dictionary<string, string>();

        HighlightingColor IHighlightingDefinition.GetNamedColor(string inName)
            => m_NamedHighlightingColors.Values.FirstOrDefault(c => c.Name == inName);

        HighlightingRuleSet IHighlightingDefinition.GetNamedRuleSet(string name)
            //=> m_MainRuleSet.Rules.FirstOrDefault(r => r.name)
            => m_MainRuleSet;

        private HighlightingRuleSet m_MainRuleSet = new HighlightingRuleSet();
    }
}
