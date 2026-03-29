using System;

namespace CST2550
{
	// tree logic
	public class RecoveryTree
	{
		public Node Root;

		// Just a simple way to start adding cars to the tree
		public void Add(RecoveryRecord newRecord)
		{
			Root = InsertRecursive(Root, newRecord);
		}

		// It just checks if the plate should go left or right.
		private Node InsertRecursive(Node root, RecoveryRecord record)
		{
			// If we hit an empty spot, drop the new car record here
			if (root == null)
			{
				return new Node(record);
			}

			// compare plates alphabetically - left if it's "smaller", right if "bigger"
			int comparison = string.Compare(record.NumberPlate, root.Data.NumberPlate);

			if (comparison < 0)
			{
				root.Left = InsertRecursive(root.Left, record);
			}
			else if (comparison > 0)
			{
				root.Right = InsertRecursive(root.Right, record);
			}

			return root;
		}
	}
}
