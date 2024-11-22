using System.Diagnostics;

namespace OtusFibonaci
{
	internal class Program
	{
		private static readonly int[] values = { 5, 10, 20 };
		static void Main(string[] args)
		{
			var stopwatch = new Stopwatch();
			int recursiveAnswer;
			int cyclicAnswer;
			foreach (int i in values)
			{
				stopwatch.Start();
				recursiveAnswer = Recursive(i);
				stopwatch.Stop();
				Console.WriteLine($"F(n) = F(n-1) + F(n-2) where n = {i}, answer is {recursiveAnswer}" +
					$", executed in {stopwatch.ElapsedMilliseconds} ms by recursive");
				stopwatch.Restart();
				cyclicAnswer = Cyclic(i);
				stopwatch.Stop();
				Console.WriteLine($"F(n) = F(n-1) + F(n-2) where n = {i}, answer is {cyclicAnswer}" +
					$", executed in {stopwatch.ElapsedMilliseconds} ms by cycles");
			}
		}

		private static int Recursive(int n)
		{
			if (n == 0) return 0;
			if (n == 1) return 1;
			else return Recursive(n - 1) + Recursive (n - 2);
		}
		private static int Cyclic(int n)
		{
			int result = 0;
			int b = 1;
			int tmp;
			for (int i = 0; i < n; i++)
			{
				tmp = result;
				result = b;
				b += tmp;
			}
			return result;
		}

	}
}
