using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class WhileStatementToken : TokenBase<WhileStatement>
	{
		public WhileStatementToken(WhileStatement node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			IValue lastResult = new UndefinedValue();
			while (!scope.LoopInterrupt && TokenMap.Map(Node.Test).Execute(scope).IsTruthy().Value)
			{
				lastResult = TokenMap
					.Map(Node.Body)
					.Execute(scope);
			}

			scope.LoopInterrupt = false;

			return lastResult;
		}
	}
}
