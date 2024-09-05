using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    /// <summary>
    /// 二叉树最大深度，深度优先搜索
    /// </summary>
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
            List<int?> list = new List<int?>(new int?[] { 3, 9, 20, null, null, 15, 7 });
            TreeNode tree = TreeUtil.BuildTreeByLevelOrder(list);
            int ret = maxDepth(tree);
            Console.WriteLine($"二叉树最大深度{ret}");
        }
    }
}
