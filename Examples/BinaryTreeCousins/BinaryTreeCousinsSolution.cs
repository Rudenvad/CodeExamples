namespace Examples.BinaryTreeCousins;

public class BinaryTreeCousinsSolution
{
    public bool IsCousins(TreeNode root, int x, int y)
    {
        // Initialize a queue for BFS
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        // Traverse the tree level by level
        while (queue.Count > 0)
        {
            int size = queue.Count;
            bool xFound = false;
            bool yFound = false;

            for (int i = 0; i < size; i++)
            {
                TreeNode current = queue.Dequeue();

                // Check if current node's children are x and y
                if (current.left is not null && current.right is not null)
                {
                    int leftVal = current.left.val;
                    int rightVal = current.right.val;

                    if ((leftVal == x && rightVal == y) || (leftVal == y && rightVal == x))
                        return false; // x and y are siblings, hence not cousins
                }

                // Check if current node is either x or y
                if (current.val == x) xFound = true;
                if (current.val == y) yFound = true;

                // Add child nodes to the queue for next level
                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }

            // After traversing the current level
            if (xFound && yFound) return true; // x and y found at the same level and are not siblings

            if (xFound || yFound) return false; // Found one node at current level, the other is either at a different level or not present
        }

        return false;
    }
}
