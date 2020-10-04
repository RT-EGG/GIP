using System;
using System.Collections.Generic;
using GIP.IO.Json;
using GIP.IO.Project;

namespace GIP.Core.Tasks
{
    public abstract class ProcessTaskSequenceLoop : ProcessTaskSequence
    {
        public override bool Execute(ILogger inLogger)
        {
            return base.Execute(inLogger);
        }

        protected abstract bool DoContinue { get; }

        public int LoopIndex
        { get; private set; } = 0;
    }

    public class ProcessTaskSequenceCountingForLoop : ProcessTaskSequenceLoop
    {
        public int MaxLoopCount
        { get; set; } = 10;

        protected override bool DoContinue => LoopIndex < MaxLoopCount;

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonTaskSequenceCountingForLoop) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            var src = inSource as JsonTaskSequenceCountingForLoop;
            MaxLoopCount = src.MaxLoopCount;
            return true;
        }

        protected override JsonDataObject CreateJson() => new JsonTaskSequenceCountingForLoop();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonTaskSequenceCountingForLoop;
            dst.MaxLoopCount = MaxLoopCount;
            return;
        }
    }
}
