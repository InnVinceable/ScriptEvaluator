using ScriptEvaluator.Context.Types;
using ScriptEvaluator.Context.Types.Interfaces;
using ScriptEvaluator.Exceptions;

namespace ScriptEvaluator.Context
{
	internal class Scope
	{
		private Scope? _parentScope;
		private Dictionary<string, IValue> _variables;
		private IEnumerable<string> _immutables;

		public Scope()
		{
			_parentScope = null;
			_variables = new Dictionary<string, IValue>();
			_immutables = new List<string>();
			LoopInterrupt = false;
		}

		public bool LoopInterrupt { get; set; }

		public Scope(Scope parentScope)
		{
			_parentScope = parentScope;
			_variables = new Dictionary<string, IValue>();
			_immutables = new List<string>();
			LoopInterrupt = false;
		}

		public void DeclareVariable(string variableName, IValue value)
		{
			if (GetAllVariables().ContainsKey(variableName))
			{
				throw new VariableAlreadyDeclaredException();
			}

			_variables.Add(variableName, value);
		}

		public void ReassignVariable(string variableName, IValue value)
		{
			if (_immutables.Contains(variableName))
			{
				throw new ImmutableVariableReassignmentException();
			}

			if (_variables.ContainsKey(variableName))
			{
				_variables[variableName] = value;
			}
			else if (_parentScope != null && _parentScope._variables.ContainsKey(variableName))
			{
				_parentScope.ReassignVariable(variableName, value);
			}
			else
			{
				throw new VariableNotDeclaredException();
			}
		}

		public IValue GetVariableValue(string variableName)
		{
			var variables = GetAllVariables();
			if (!variables.ContainsKey(variableName))
			{
				throw new VariableNotDeclaredException();
			}

			return variables[variableName];
		}

		private IEnumerable<string> GetAllImmutables()
		{
			return _parentScope is null
				? _immutables
				: _parentScope
					.GetAllImmutables()
					.Union(_immutables);
		}

		private Dictionary<string, IValue> GetAllVariables()
		{
			return _parentScope is null
				? _variables
				: _parentScope
					.GetAllVariables()
					.Union(_variables)
					.ToDictionary(v => v.Key, v => v.Value);
		}
	}
}
