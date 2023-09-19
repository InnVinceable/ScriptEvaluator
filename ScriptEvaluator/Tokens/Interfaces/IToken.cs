using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types.Interfaces;

namespace ScriptEvaluator.Tokens.Interfaces
{
	internal interface IToken
	{
		IValue Execute(Scope scope);
	}
}
