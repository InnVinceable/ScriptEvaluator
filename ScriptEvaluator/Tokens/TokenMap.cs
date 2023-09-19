using Esprima.Ast;
using ScriptEvaluator.Tokens.Interfaces;

namespace ScriptEvaluator.Tokens
{
	internal class TokenMap
	{
		public static IToken Map(Node? node)
		{
			if (node == null)
				return new EmptyToken(node as EmptyStatement);

			return node.Type switch
			{
				Nodes.AssignmentExpression => new AssignmentExpressionToken(node as AssignmentExpression),
				Nodes.BinaryExpression => new BinaryExpressionToken(node as BinaryExpression),
				Nodes.BlockStatement => new BlockStatementToken(node as BlockStatement),
				Nodes.ExpressionStatement => new ExpressionStatementToken(node as ExpressionStatement),
				Nodes.Identifier => new IdentifierToken(node as Identifier),
				Nodes.IfStatement => new IfStatementToken(node as IfStatement),
				Nodes.Literal => new LiteralToken(node as Literal),
				Nodes.VariableDeclaration => new VariableDeclarationToken(node as VariableDeclaration),
				Nodes.WhileStatement => new WhileStatementToken(node as WhileStatement),
				Nodes.DoWhileStatement => new DoWhileStatementToken(node as DoWhileStatement),
				Nodes.ForStatement => new ForStatementToken(node as ForStatement),
				Nodes.UnaryExpression => new UnaryExpressionToken(node as UnaryExpression),
				Nodes.UpdateExpression => new UpdateExpressionToken(node as UpdateExpression),

				Nodes.ForOfStatement => throw new NotImplementedException(),
				Nodes.ForInStatement => throw new NotImplementedException(),
				Nodes.BreakStatement => throw new NotImplementedException(),
				Nodes.AccessorProperty => throw new NotImplementedException(),
				Nodes.ArrayExpression => throw new NotImplementedException(),
				Nodes.ArrayPattern => throw new NotImplementedException(),
				Nodes.ArrowFunctionExpression => throw new NotImplementedException(),
				Nodes.AssignmentPattern => throw new NotImplementedException(),
				Nodes.AwaitExpression => throw new NotImplementedException(),
				Nodes.CallExpression => throw new NotImplementedException(),
				Nodes.CatchClause => throw new NotImplementedException(),
				Nodes.ChainExpression => throw new NotImplementedException(),
				Nodes.ClassBody => throw new NotImplementedException(),
				Nodes.ClassDeclaration => throw new NotImplementedException(),
				Nodes.ClassExpression => throw new NotImplementedException(),
				Nodes.ConditionalExpression => throw new NotImplementedException(),
				Nodes.ContinueStatement => throw new NotImplementedException(),
				Nodes.DebuggerStatement => throw new NotImplementedException(),
				Nodes.Decorator => throw new NotImplementedException(),
				Nodes.EmptyStatement => throw new NotImplementedException(),
				Nodes.ExportAllDeclaration => throw new NotImplementedException(),
				Nodes.ExportDefaultDeclaration => throw new NotImplementedException(),
				Nodes.ExportNamedDeclaration => throw new NotImplementedException(),
				Nodes.ExportSpecifier => throw new NotImplementedException(),
				Nodes.FunctionDeclaration => throw new NotImplementedException(),
				Nodes.FunctionExpression => throw new NotImplementedException(),
				Nodes.ImportAttribute => throw new NotImplementedException(),
				Nodes.ImportDeclaration => throw new NotImplementedException(),
				Nodes.ImportDefaultSpecifier => throw new NotImplementedException(),
				Nodes.ImportExpression => throw new NotImplementedException(),
				Nodes.ImportNamespaceSpecifier => throw new NotImplementedException(),
				Nodes.ImportSpecifier => throw new NotImplementedException(),
				Nodes.LabeledStatement => throw new NotImplementedException(),
				Nodes.LogicalExpression => throw new NotImplementedException(),
				Nodes.MemberExpression => throw new NotImplementedException(),
				Nodes.MetaProperty => throw new NotImplementedException(),
				Nodes.MethodDefinition => throw new NotImplementedException(),
				Nodes.NewExpression => throw new NotImplementedException(),
				Nodes.ObjectExpression => throw new NotImplementedException(),
				Nodes.ObjectPattern => throw new NotImplementedException(),
				Nodes.PrivateIdentifier => throw new NotImplementedException(),
				Nodes.Program => throw new NotImplementedException(),
				Nodes.Property => throw new NotImplementedException(),
				Nodes.PropertyDefinition => throw new NotImplementedException(),
				Nodes.RestElement => throw new NotImplementedException(),
				Nodes.ReturnStatement => throw new NotImplementedException(),
				Nodes.SequenceExpression => throw new NotImplementedException(),
				Nodes.SpreadElement => throw new NotImplementedException(),
				Nodes.StaticBlock => throw new NotImplementedException(),
				Nodes.Super => throw new NotImplementedException(),
				Nodes.SwitchCase => throw new NotImplementedException(),
				Nodes.SwitchStatement => throw new NotImplementedException(),
				Nodes.TaggedTemplateExpression => throw new NotImplementedException(),
				Nodes.TemplateElement => throw new NotImplementedException(),
				Nodes.TemplateLiteral => throw new NotImplementedException(),
				Nodes.ThisExpression => throw new NotImplementedException(),
				Nodes.ThrowStatement => throw new NotImplementedException(),
				Nodes.TryStatement => throw new NotImplementedException(),
				Nodes.VariableDeclarator => throw new NotImplementedException(),
				Nodes.WithStatement => throw new NotImplementedException(),
				Nodes.YieldExpression => throw new NotImplementedException(),
				_ => new EmptyToken(node as EmptyStatement)
			};
		}
	}
}
