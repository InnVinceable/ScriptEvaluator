using Esprima.Ast;
using ScriptEvaluator.Context.Types.Interfaces;
using System.Reflection;

namespace ScriptEvaluator.Context.Types.Base
{
    internal abstract class TypedValue<T> : IValue
    {
        public T Value { get; }

		public string RawValue => Value?.ToString() ?? string.Empty;

		public TypedValue(T value)
        {
            Value = value;
        }

        public abstract TypedValue<T> Add(IValue rhs);

		public abstract TypedValue<T> Subtract(IValue rhs);

        public abstract TypedValue<T> Multiply(IValue rhs);

        public abstract TypedValue<T> Divide(IValue rhs);

		public abstract TypedValue<T> Modulo(IValue rhs);

		public abstract TypedValue<T> Exponentiation(IValue rhs);

		public abstract TypedValue<T> Increment();

		public abstract TypedValue<T> Decrement();

		public abstract TypedValue<bool> IsTruthy();

		public abstract TypedValue<bool> Greater(IValue rhs);

		public abstract TypedValue<bool> GreaterOrEqual(IValue rhs);

		public abstract TypedValue<bool> Less(IValue rhs);

		public abstract TypedValue<bool> LessOrEqual(IValue rhs);

		public abstract TypedValue<bool> LeftShift(IValue rhs);

		public abstract TypedValue<bool> RightShift(IValue rhs);

		public abstract TypedValue<bool> UnsignedRightShift(IValue rhs);

		public IValue BitwiseAnd(IValue rhs)
		{
			return new BooleanValue(IsTruthy().Value & rhs.IsTruthy().Value);
		}

		public IValue BitwiseOr(IValue rhs)
		{
			return new BooleanValue(IsTruthy().Value | rhs.IsTruthy().Value);
		}

		public IValue BitwiseXor(IValue rhs)
		{
			return new BooleanValue(IsTruthy().Value ^ rhs.IsTruthy().Value);
		}

		public IValue LogicalAnd(IValue rhs)
		{
			return new BooleanValue(IsTruthy().Value && rhs.IsTruthy().Value);
		}

		public IValue LogicalOr(IValue rhs)
		{
			return new BooleanValue(IsTruthy().Value || rhs.IsTruthy().Value);
		}

		public IValue Equals(IValue rhs)
		{
			return new BooleanValue(RawValue == rhs.RawValue.Trim('\''));
		}

		public IValue NotEquals(IValue rhs)
		{
			return new BooleanValue(RawValue != rhs.RawValue);
		}

		public IValue StrictEquals(IValue rhs)
		{
			var rhsValue = rhs as TypedValue<T>;
			if (rhsValue == null)
			{
				return new BooleanValue(false);
			}

			return new BooleanValue(RawValue == rhs.RawValue);
		}

		public IValue StrictNotEquals(IValue rhs)
		{
			var rhsValue = rhs as TypedValue<T>;
			if (rhsValue == null)
			{
				return new BooleanValue(false);
			}

			return new BooleanValue(RawValue != rhs.RawValue);
		}

		public IValue Not()
		{
			return new BooleanValue(!IsTruthy().Value);
		}

		public IValue Binary(IValue rhs, BinaryOperator op)
		{
			return op switch
			{
				BinaryOperator.Plus => Add(rhs),
				BinaryOperator.Minus => Subtract(rhs),
				BinaryOperator.Times => Multiply(rhs),
				BinaryOperator.Divide => Divide(rhs),
				BinaryOperator.Modulo => Modulo(rhs),
				BinaryOperator.Exponentiation => Exponentiation(rhs),
				BinaryOperator.BitwiseOr => BitwiseOr(rhs),
				BinaryOperator.LogicalOr => LogicalOr(rhs),
				BinaryOperator.BitwiseAnd => BitwiseAnd(rhs),
				BinaryOperator.LogicalAnd => LogicalAnd(rhs),
				BinaryOperator.BitwiseXor => BitwiseXor(rhs),
				BinaryOperator.Equal => Equals(rhs),
				BinaryOperator.StrictlyEqual => StrictEquals(rhs),
				BinaryOperator.NotEqual => NotEquals(rhs),
				BinaryOperator.StrictlyNotEqual => StrictNotEquals(rhs),
				BinaryOperator.Greater => Greater(rhs),
				BinaryOperator.GreaterOrEqual => GreaterOrEqual(rhs),
				BinaryOperator.Less => Less(rhs),
				BinaryOperator.LessOrEqual => LessOrEqual(rhs),
				BinaryOperator.LeftShift => LeftShift(rhs),
				BinaryOperator.RightShift => RightShift(rhs),
				BinaryOperator.UnsignedRightShift => UnsignedRightShift(rhs),
				BinaryOperator.InstanceOf => throw new InvalidOperationException("Operator not supported"),
				BinaryOperator.In => throw new InvalidOperationException("Operator not supported"),
				BinaryOperator.NullishCoalescing => throw new InvalidOperationException("Operator not supported"),
				_ => throw new InvalidOperationException($"Operator {op} unsupported")
			};
		}

		public IValue Unary(UnaryOperator op)
		{
			return op switch
			{
				UnaryOperator.BitwiseNot => Not(),
				UnaryOperator.LogicalNot => Not(),
				UnaryOperator.Increment => Increment(),
				UnaryOperator.Decrement => Decrement(),
				UnaryOperator.Plus => throw new InvalidOperationException($"Operator {op} unsupported"),
				UnaryOperator.Minus => throw new InvalidOperationException($"Operator {op} unsupported"),
				UnaryOperator.Delete => throw new InvalidOperationException($"Operator {op} unsupported"),
				UnaryOperator.Void => throw new InvalidOperationException($"Operator {op} unsupported"),
				UnaryOperator.TypeOf => throw new InvalidOperationException($"Operator {op} unsupported"),
				_ => throw new InvalidOperationException($"Operator {op} unsupported")
			};
		}
	}
}
