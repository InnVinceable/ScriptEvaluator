using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class AssignmentExpressionToken : TokenBase<AssignmentExpression>
	{
		public AssignmentExpressionToken(AssignmentExpression node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			var identifier = Node.Left as Identifier;
			if (identifier == null)
			{
				return null;
			}

			var rhs = TokenMap.Map(Node.Right);
			var rhsValue = rhs.Execute(scope);

			scope.ReassignVariable(identifier.Name, rhsValue);
			return rhsValue;
		}
	}
}
