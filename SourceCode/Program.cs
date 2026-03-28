using System;

namespace CST2550
{
	class Program
	{
		static void Main(string[] args)
		{
			// Setting up the tree
			RecoveryTree myTree = new RecoveryTree();

			// Creating some test data to see if it actually works
			var car1 = new RecoveryRecord("ABC-123", "Tesla");
			var car2 = new RecoveryRecord("MDX-101", "Mercedes");

			// Try to add them to our custom tree
			myTree.Add(car1);
			myTree.Add(car2);
			
			Console.WriteLine("\nPress any key...");
			Console.ReadKey();
		}
	}
}
