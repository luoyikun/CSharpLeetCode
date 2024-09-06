using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    /// <summary>
    /// 翻转二叉树
    /// </summary>
    public class InvertTree
    {
        static TreeNode invertTree(TreeNode root)
        {
            if (root == null) return root;
            if (!(root.left == null && root.right == null))
            {
                swap(ref root.left, ref root.right);  // 中
                Console.WriteLine("交换后");
                TreeUtil.PrintTree(root);
            }
            
            invertTree(root.left);         // 左
            invertTree(root.right);        // 右
            return root;
        }

        static void swap(ref TreeNode left, ref TreeNode right)
        {
            TreeNode tmp = new TreeNode();
            tmp = left;
            left = right;
            right = tmp;
            
        }

        public static void Test()
        {
            List<int?> list = new List<int?>(new int?[] { 4, 2, 7, 1, 3, 6, 9 });
            TreeNode tree = TreeUtil.BuildTreeByLevelOrder(list);
            TreeNode newTree = invertTree(tree);
            Console.WriteLine("最终结果");
            TreeUtil.PrintTree(newTree);
        }
    }
}
