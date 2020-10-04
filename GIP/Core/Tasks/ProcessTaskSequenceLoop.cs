using System;
using System.Collections.Generic;
using Reactive.Bindings;
using GIP.IO.Json;
using GIP.IO.Project;

namespace GIP.Core.Tasks
{
    public abstract class ProcessTaskSequenceLoop : ProcessTaskSequence
    {
        public override bool Execute(ILogger inLogger)
        {
            LoopIndex = 0;
            while (DoContinue) {
                inLogger.PushLog(this, new LogData(LogLevel.Information, $"loop[{LoopIndex++}]"));
                if (!base.Execute(inLogger)) {
                    inLogger.PushLog(this, new LogData(LogLevel.Information, $"braek loop by failer task."));
                    return false;
                }
            }
            inLogger.PushLog(this, new LogData(LogLevel.Information, $"Finish loop."));
            return true;
        }

        protected abstract bool DoContinue { get; }

        public int LoopIndex
        { get; private set; } = 0;
    }

    public class ProcessTaskSequenceCountingForLoop : ProcessTaskSequenceLoop
    {
        public ReactiveProperty<int> MaxLoopCount
        { get; } = new ReactiveProperty<int>(10);

        protected override bool DoContinue => LoopIndex < MaxLoopCount.Value;

        protected override IEnumerable<Type> ReadableJsonClass => new Type[] { typeof(JsonTaskSequenceCountingForLoop) };
        public override bool ReadJson(JsonDataObject inSource, JsonDataReadBuffer inBuffer, ILogger inLogger)
        {
            if (!base.ReadJson(inSource, inBuffer, inLogger)) {
                return false;
            }

            var src = inSource as JsonTaskSequenceCountingForLoop;
            MaxLoopCount.Value = src.MaxLoopCount;
            return true;
        }

        protected override JsonDataObject CreateJson() => new JsonTaskSequenceCountingForLoop();
        protected override void ExportToJson(JsonDataObject inDst)
        {
            base.ExportToJson(inDst);

            var dst = inDst as JsonTaskSequenceCountingForLoop;
            dst.MaxLoopCount = MaxLoopCount.Value;
            return;
        }
    }
}
