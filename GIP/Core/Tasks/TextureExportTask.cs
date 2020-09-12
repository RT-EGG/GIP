using System;
using System.IO;
using System.Collections.Generic;
using Reactive.Bindings;
using GIP.Core.Variables;
using GIP.IO.Json;
using GIP.IO.Project;

namespace GIP.Core.Tasks
{
    public class TextureExportTask : ProcessTask
    {
        public ReactiveProperty<string> FilePath
        { get; } = new ReactiveProperty<string>("");

        public ReactiveProperty<TextureVariable> Texture
        { get; } = new ReactiveProperty<TextureVariable>(initialValue: null);

        public ReactiveProperty<bool> OverwriteIfExistAlready
        { get; } = new ReactiveProperty<bool>(true);

        public override bool Execute(ILogger inLogger = null)
        {
            if (Texture.Value == null) {
                inLogger.PushLog(this, new ProcessTaskLogData(this, LogLevel.Error, "Export target texture is not assigned."));
                return false;
            }
            string directory = Path.GetDirectoryName(FilePath.Value);
            if (!Directory.Exists(directory)) {
                try {
                    Directory.CreateDirectory(directory);
                } catch {
                    inLogger.PushLog(this, new ProcessTaskLogData(this, LogLevel.Error, $"Failed to create directory \"{directory}\"."));
                    return false;
                }
            }

            try {
                Texture.Value.ExportToFile(FilePath.Value);

            } catch (Exception e) {
                inLogger.PushLog(this, new LogExceptionData(e));
            }
            return true;
        }

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonTextureExportTask) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            var src = inSource as JsonTextureExportTask;
            FilePath.Value = src.FilePath;
            OverwriteIfExistAlready.Value = src.OverwriteIfExistAlready;

            inBuffer.RegisterComplementTask((data, logger) => {
                data.TryGetValueAs<TextureVariable>(src.Texture, out var texture, logger);
                Texture.Value = texture;
            });
            return true;
        }

        protected override JsonDataObject CreateJson() => new JsonTextureExportTask();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonTextureExportTask;
            dst.FilePath = FilePath.Value;
            dst.Texture = Texture.Value == null ? Guid.Empty : Texture.Value.GUID;
            dst.OverwriteIfExistAlready = OverwriteIfExistAlready.Value;
            return;
        }
    }
}
