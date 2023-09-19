using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Evaluation;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class UnaryExpressionToken : TokenBase<UnaryExpression>
	{
		public UnaryExpressionToken(UnaryExpression node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			var value = TokenMap
				.Map(Node.Argument)
				.Execute(scope);

			return Operator.Unary(value, Node.Operator);
		}
	}
}
