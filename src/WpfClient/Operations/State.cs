using System;

namespace TDDCalculator.WpfClient.Operations
{
    using Processor = Func<float, float, string>;

    public struct State
    {
        public float? Accumulator { get; private set; }
        public Processor? Processor { get; private set; }
        public string Text { get; private set; }
        public bool HasExecuted { get; private set; }

        public State(float? accumulator = 0, Processor? processor = null, String? text = "", bool? hasExecuted = false)
        {
            Accumulator = accumulator;
            Processor = processor;
            Text = text ?? "";
            HasExecuted = hasExecuted ?? false;
        }

        public State withAccumulator(float? accumulator)
        {
            State returnState = this; /* copy */
            returnState.Accumulator = accumulator;
            return returnState;
        }

        public State withProcessor(Processor? processor)
        {
            State returnState = this; /* copy */
            returnState.Processor = processor;
            return returnState;
        }

        public State withText(string text)
        {
            State returnState = this; /* copy */
            returnState.Text = text;
            return returnState;
        }

        public State withHasExecuted(bool hasExecuted)
        {
            State returnState = this; /* copy */
            returnState.HasExecuted = hasExecuted;
            return returnState;
        }
    }
}
