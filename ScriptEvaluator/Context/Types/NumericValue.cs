using ScriptEvaluator.Context.Types.Base;
using ScriptEvaluator.Context.Types.Interfaces;

namespace ScriptEvaluator.Context.Types
{
	internal class NumericValue : TypedValue<double>
	{
		public NumericValue(double value)
			: base(value)
		{
		}

		public override NumericValue Add(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new NumericValue(Value + value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override NumericValue Divide(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new NumericValue(Value / value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override NumericValue Multiply(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new NumericValue(Value * value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override NumericValue Subtract(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new NumericValue(Value - value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override TypedValue<double> Modulo(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new NumericValue(Value % value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override BooleanValue IsTruthy()
		{
			return new BooleanValue(Value > 0);
		}

		public override TypedValue<double> Exponentiation(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new NumericValue(Math.Pow(Value, value));

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override TypedValue<bool> Greater(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new BooleanValue(Value > value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override TypedValue<bool> GreaterOrEqual(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new BooleanValue(Value >= value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override TypedValue<bool> Less(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new BooleanValue(Value < value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override TypedValue<bool> LessOrEqual(IValue rhs)
		{
			if (double.TryParse(rhs.RawValue, out var value))
				return new BooleanValue(Value <= value);

			throw new InvalidOperationException($"Could not convert value {rhs.RawValue} to {nameof(NumericValue)}");
		}

		public override TypedValue<double> Increment()
		{
			return new NumericValue(Value + 1);
		}

		public override TypedValue<double> Decrement()
		{
			return new NumericValue(Value - 1);
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
	}
}
