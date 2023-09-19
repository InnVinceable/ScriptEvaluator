using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class IdentifierToken : TokenBase<Identifier>
	{
		public IdentifierToken(Identifier node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			return scope.GetVariableValue(Node.Name);
		}
	}
}
