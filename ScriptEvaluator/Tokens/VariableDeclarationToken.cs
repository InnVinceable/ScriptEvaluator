using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Base;

namespace ScriptEvaluator.Tokens
{
	internal class VariableDeclarationToken : TokenBase<VariableDeclaration>
	{
		public VariableDeclarationToken(VariableDeclaration node)
			: base(node)
		{
		}

		public override IValue Execute(Scope scope)
		{
			IValue lastResult = new UndefinedValue();
			foreach (var variableDeclaration in Node.Declarations)
			{
				if (variableDeclaration.Id is not Identifier)
				{
					continue;
				}

				var identifier = variableDeclaration.Id as Identifier;
				if (identifier is null)
				{
					continue;
				}

				var initializer = TokenMap.Map(variableDeclaration.Init);
				var result = initializer.Execute(scope);
				scope.DeclareVariable(identifier.Name, result);
				lastResult = result;
			}

			return lastResult;
		}
	}
}
