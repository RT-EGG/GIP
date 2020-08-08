using System.Collections.Generic;
using GIP.Core.Variables;

namespace GIP.Core
{
    public class ShaderResources
    {
        public IDictionary<TextureVariable, int> Textures
        { get; } = new Dictionary<TextureVariable, int>();

        public int NextBindableTextureUnit
        { get; set; } = 0;
    }
}
