using ScriptEvaluator.Context.Types.Base;
using ScriptEvaluator.Context.Types.Interfaces;

namespace ScriptEvaluator.Context.Types
{
    internal class VoidValue : IValue
    {
        public string RawValue => "void";

        public TypedValue<bool> IsTruthy()
        {
            return new BooleanValue(false);
        }
    }
}
