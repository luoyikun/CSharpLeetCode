using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    //二叉搜索树中序遍历
    public class ValidateBinarySearchTreeInorder
    {
        public static bool isValidBST(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            int inorder = int.MinValue;

            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    Console.WriteLine($"插入堆栈{TreeUtil.GetStrStackTreeNode(stack)}");
                    root = root.left;
                }
                root = stack.Pop();
                // 如果中序遍历得到的节点的值小于等于前一个 inorder，说明不是二叉搜索树
                Console.WriteLine($"弹出栈顶{root.val},跟中序值比较{inorder}");
                if (root.val <= inorder)
                {
                    return false;
                }
                inorder = root.val;
                root = root.right;
                Console.WriteLine($"中序值改为{inorder}，树走右节点");
            }
            return true;
        }

        public static void Test()
        {
            List<int?> list = new List<int?>(new int?[] { 5, 1, 4, null, null, 3, 6 });
            TreeNode tree = TreeUtil.BuildTreeByLevelOrder(list);
            bool isValid = isValidBST(tree);
            Console.WriteLine($"是否是二叉搜索树{isValid}");
        }
        
    }
}
