using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using System.Windows.Media;

namespace GIP.Controls.GlslSyntax
{
    class SyntaxHighlightingBrush : HighlightingBrush
    {
        public Brush Brush
        { get; set; } = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        public override Brush GetBrush(ITextRunConstructionContext context)
            => Brush;
    }
}
