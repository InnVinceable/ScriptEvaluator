using ScriptEvaluator.Context.Types.Base;
using ScriptEvaluator.Context.Types.Interfaces;

namespace ScriptEvaluator.Context.Types
{
	internal class StringValue : TypedValue<string>
	{
		public StringValue(string value)
			: base(value)
		{
		}

		public override StringValue Add(IValue rhs)
		{
			return new StringValue(Value + rhs.RawValue);
		}

		public override TypedValue<string> Divide(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Divide)} operator on a {nameof(StringValue)}");
		}

		public override TypedValue<string> Multiply(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Multiply)} operator on a {nameof(StringValue)}");
		}

		public override TypedValue<string> Subtract(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Subtract)} operator on a {nameof(StringValue)}");
		}
		public override TypedValue<string> Modulo(IValue rhs)
		{
			throw new InvalidOperationException($"Cannot use {nameof(Modulo)} operator on a {nameof(StringValue)}");
		}

		public override TypedValue<bool> IsTruthy()
		{
			throw new NotImplementedException();
		}

		public override TypedValue<string> Exponentiation(IValue rhs)
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

		public override TypedValue<string> Increment()
		{
			throw new NotImplementedException();
		}

		public override TypedValue<string> Decrement()
		{
			throw new NotImplementedException();
		}
	}
}
