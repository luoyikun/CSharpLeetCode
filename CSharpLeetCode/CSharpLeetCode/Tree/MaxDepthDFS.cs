using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    public class MaxDepthDFS
    {
        public static int maxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = maxDepth(root.left);
                int rightHeight = maxDepth(root.right);
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public static void Test()
        {
            //int[]
        }
    }
}
