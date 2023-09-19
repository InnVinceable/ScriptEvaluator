using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class EmptyToken : TokenBase<EmptyStatement>
	{
		public EmptyToken(EmptyStatement node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			return new VoidValue();
		}
	}
}
