using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    //验证是否满足二叉搜索树
    public class ValidateBinarySearchTree
    {
        public static bool isValidBST(TreeNode root)
        {
            return isValidBST(root, int.MinValue, int.MaxValue);
        }

        public static bool isValidBST(TreeNode node, int lower, int upper)
        {
            if (node == null)
            {
                return true;
            }
            //返回true的不能处理，要接着遍历到null节点返回
            Console.WriteLine($"当前节点{node.val},min{lower},max{upper}");
            if (node.val <= lower || node.val >= upper)
            {
                return false;
            }
            //用的是&&，如果有1个为false就会返回，停止递归
            return isValidBST(node.left, lower, node.val) && isValidBST(node.right, node.val, upper);
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
