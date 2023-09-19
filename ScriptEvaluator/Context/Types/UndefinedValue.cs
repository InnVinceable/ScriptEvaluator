using ScriptEvaluator.Context.Types.Base;
using ScriptEvaluator.Context.Types.Interfaces;

namespace ScriptEvaluator.Context.Types
{
	internal class UndefinedValue : IValue
	{
		public string RawValue => "undefined";

		public TypedValue<bool> IsTruthy()
		{
			return new BooleanValue(false);
		}
	}
}
