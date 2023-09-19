using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class ExpressionStatementToken : TokenBase<ExpressionStatement>
	{
		public ExpressionStatementToken(ExpressionStatement node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			var expression = TokenMap.Map(Node.Expression);
			return expression.Execute(scope);
		}
	}
}
