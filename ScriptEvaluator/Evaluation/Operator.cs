using Esprima.Ast;
using ScriptEvaluator.Context.Types.Base;
using ScriptEvaluator.Context.Types.Factories;
using ScriptEvaluator.Context.Types.Interfaces;

namespace ScriptEvaluator.Evaluation
{
	internal static class Operator
	{
		public static IValue Unary(IValue arg, UnaryOperator op)
		{
			switch (arg)
			{
				case TypedValue<bool> b:
					return b.Unary(op);

				case TypedValue<string> b:
					return b.Unary(op);

				case TypedValue<double> b:
					return b.Unary(op);

				default:
					throw new InvalidOperationException($"Value type does not support the use of operator {op}");
			}
		}

		public static IValue Binary(IValue lhs, IValue rhs, BinaryOperator op)
		{
			switch (lhs)
			{
				case TypedValue<bool> b:
					return b.Binary(rhs, op);

				case TypedValue<string> b:
					return b.Binary(rhs, op);

				case TypedValue<double> b:
					return b.Binary(rhs, op);

				default:
					throw new InvalidOperationException($"Value type does not support the use of operator {op}");
			}
		}
	}
}
