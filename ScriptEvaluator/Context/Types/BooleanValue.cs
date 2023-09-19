using ScriptEvaluator.Context.Types.Base;
using ScriptEvaluator.Context.Types.Interfaces;

namespace ScriptEvaluator.Context.Types
{
	internal class BooleanValue : TypedValue<bool>
	{
		public BooleanValue(bool value)
			: base(value)
		{
		}

		public override BooleanValue Add(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Add)} operator on a {nameof(BooleanValue)}");
		}

		public override BooleanValue Multiply(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Multiply)} operator on a {nameof(BooleanValue)}");
		}
		public override BooleanValue Divide(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Divide)} operator on a {nameof(BooleanValue)}");
		}

		public override BooleanValue Subtract(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Subtract)} operator on a {nameof(BooleanValue)}");
		}

		public override TypedValue<bool> Modulo(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Modulo)} operator on a {nameof(BooleanValue)}");
		}

		public override BooleanValue IsTruthy()
		{
			return new BooleanValue(Value);
		}

		public override TypedValue<bool> Exponentiation(IValue rhs)
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> Greater(IValue rhs)
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> GreaterOrEqual(IValue rhs)
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> Less(IValue rhs)
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> LessOrEqual(IValue rhs)
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> LeftShift(IValue rhs)
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> RightShift(IValue rhs)
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> UnsignedRightShift(IValue rhs)
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> Increment()
		{
			throw new NotImplementedException();
		}

		public override TypedValue<bool> Decrement()
		{
			throw new NotImplementedException();
		}
	}
}
