using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class IfStatementToken : TokenBase<IfStatement>
	{
		public IfStatementToken(IfStatement node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			var testExpression = TokenMap.Map(Node.Test);

			var result = testExpression.Execute(scope);
			
			if (result.IsTruthy().Value)
			{
				var concequent = TokenMap.Map(Node.Consequent);

				return concequent.Execute(scope);
			}
            else if (Node.Alternate is not null)
            {
				var alternate = TokenMap.Map(Node.Alternate);

				return alternate.Execute(scope);
			}

			return new VoidValue();
        }
	}
}
