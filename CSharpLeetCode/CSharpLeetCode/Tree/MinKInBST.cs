using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    //第k小元素在二叉搜索树中
    public class MinKInBST
    {
        public static int KthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    Console.WriteLine($"入栈{TreeUtil.GetStrStackTreeNode(stack)}");
                    root = root.left;
                }
                root = stack.Pop();
                Console.WriteLine($"出栈{root.val}");
                --k;
                if (k == 0)
                {
                    break;
                }
                root = root.right;
            }
            return root.val;
        }

        public static void Test()
        {
            List<int?> list = new List<int?>(new int?[] { 5, 3, 6,  null,4 });
            TreeNode tree = TreeUtil.BuildTreeByLevelOrder(list);
            int ret = KthSmallest(tree,3);
            Console.WriteLine($"第K小在二叉搜索树中{ret}");
        }
    }
}
