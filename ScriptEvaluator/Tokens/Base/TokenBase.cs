using Esprima.Ast;
using ScriptEvaluator.Context;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Tokens.Interfaces;

namespace ScriptEvaluator.Tokens.Base
{
    internal abstract class TokenBase<T> : IToken
        where T : Node
    {
        protected T Node;

        public TokenBase(T node)
        {
            Node = node;
        }

        public abstract IValue Execute(Scope scope);
    }
}
