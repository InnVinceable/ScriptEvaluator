using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens;

namespace ScriptEvaluator
{
	internal class Evaluator
	{
		public readonly Scope Scope;

		public Evaluator()
		{
			Scope = new Scope();
		}

		public Evaluator(Scope parentScope)
		{
			Scope = new Scope(parentScope);
		}

		public IValue Evaluate(Script script)
		{
			return Evaluate(script.Body);
		}

		public IValue Evaluate(NodeList<Statement> nodes)
		{
			var lastResult = default(IValue);
			foreach (var node in nodes)
			{
				var token = TokenMap.Map(node);
				lastResult = token.Execute(Scope);
			}

			return lastResult ?? new UndefinedValue();
		}
	}
}
