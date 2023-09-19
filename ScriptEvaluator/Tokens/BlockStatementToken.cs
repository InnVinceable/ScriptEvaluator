using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class BlockStatementToken : TokenBase<BlockStatement>
	{
		public BlockStatementToken(BlockStatement node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			var evaluator = new Evaluator(scope);
			return evaluator.Evaluate(Node.Body);
		}
	}
}
