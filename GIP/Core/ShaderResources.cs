using System.Collections.Generic;

namespace GIP.Core
{
    public class ShaderResources
    {
        public IDictionary<TextureInitializer, int> Textures
        { get; } = new Dictionary<TextureInitializer, int>();

        public int NextBindableTextureUnit
        { get; set; } = 0;
    }
}
