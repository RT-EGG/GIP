using System.Collections.Generic;

namespace GIP.Core
{
    public class Project
    {
        public string FilePath
        { get; set; } = "";

        public TextureInitializerList Textures
        { get; } = new TextureInitializerList();
        public IList<ImageProcessTask> ProcessTasks
        { get; } = new List<ImageProcessTask>();
    }
}
