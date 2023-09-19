using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Evaluation;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class BinaryExpressionToken : TokenBase<BinaryExpression>
    {
		public BinaryExpressionToken(BinaryExpression node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			var left = TokenMap.Map(Node.Left);
			var right = TokenMap.Map(Node.Right);

			var lvalue = left.Execute(scope);
			var rvalue = right.Execute(scope);

			return Operator.Binary(lvalue, rvalue, Node.Operator);
		}
	}
}
