using ScriptEvaluator.Context.Types.Base;

namespace ScriptEvaluator.Context.Types.Interfaces
{
	internal interface IValue
	{
		string RawValue { get; }

		TypedValue<bool> IsTruthy();
	}
}
