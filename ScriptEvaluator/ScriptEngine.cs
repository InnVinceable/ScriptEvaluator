using Esprima;
using Esprima.Utils;

namespace ScriptEvaluator;

public class ScriptEngine
{
	public string Evalute(string script)
	{
		var parser = new JavaScriptParser();
		var program = parser.ParseScript(script);

		var s = program.ToJsonString();

		var evaluator = new Evaluator();
		var result = evaluator.Evaluate(program);

		return result.RawValue;
	}
}
