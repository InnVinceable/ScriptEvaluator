using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Evaluation;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class UpdateExpressionToken : TokenBase<UpdateExpression>
	{
		public UpdateExpressionToken(UpdateExpression node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			var identifier = Node.Argument as Identifier;

			if (identifier == null)
			{
				throw new InvalidOperationException("Could not evaluate update expression");
			}

			var value = scope.GetVariableValue(identifier.Name);

			var updatedValue = Operator.Unary(value, Node.Operator);

			scope.ReassignVariable(identifier.Name, updatedValue);

			return new UndefinedValue();
		}
	}
}
