namespace ScriptEvaluator.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			ScriptEngine s = new ScriptEngine();
			var result = s.Evalute(@"
				const s = 5;
				let b = 4 + 4;
				let z = 0;
				for (var x = 1 ; x < 10; x++) {
					z = z + 1;
				}

				z;
			");

			Assert.AreEqual("16", result);
		}
	}
}