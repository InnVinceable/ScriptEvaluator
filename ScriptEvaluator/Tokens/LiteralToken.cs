using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types.Factories;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
    internal class LiteralToken : TokenBase<Literal>
	{
		public LiteralToken(Literal node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			return ValueFactory.Create(Node.Raw);
		}
	}
}
