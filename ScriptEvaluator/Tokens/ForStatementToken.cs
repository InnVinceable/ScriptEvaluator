using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class ForStatementToken : TokenBase<ForStatement>
	{
		public ForStatementToken(ForStatement node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			TokenMap
				.Map(Node.Init)
				.Execute(scope);

			IValue lastResult = new UndefinedValue();

			while (!scope.LoopInterrupt && TokenMap.Map(Node.Test).Execute(scope).IsTruthy().Value)
			{
				lastResult = TokenMap
					.Map(Node.Body)
					.Execute(scope);

				TokenMap
					.Map(Node.Update)
					.Execute(scope);
			}

			return lastResult;
		}
	}
}
