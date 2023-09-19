using ScriptEvaluator.Context.Types.Base;
using ScriptEvaluator.Context.Types.Interfaces;

namespace ScriptEvaluator.Context.Types.Factories
{
    internal static class ValueFactory
    {
        public static IValue Create(string raw)
        {
            if (double.TryParse(raw, out var number))
            {
                return new NumericValue(number);
            }

			if (bool.TryParse(raw, out var isTrue))
			{
				return new BooleanValue(isTrue);
			}

			return new StringValue(raw);
        }
	}
}
