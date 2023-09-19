using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class DoWhileStatementToken : TokenBase<DoWhileStatement>
	{
		public DoWhileStatementToken(DoWhileStatement node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			IValue lastResult = new UndefinedValue();
			do
			{
				lastResult = TokenMap
					.Map(Node.Body)
					.Execute(scope);
			}
			while (!scope.LoopInterrupt && TokenMap.Map(Node.Test).Execute(scope).IsTruthy().Value);

			scope.LoopInterrupt = false;

			return lastResult;
		}
	}
}
