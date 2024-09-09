using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpLeetCode.Tree.TreeUtil;

namespace CSharpLeetCode.Tree
{
    //有序数组转为二叉搜索树
    public class SortArrayToBinarySearchTree
    {
        
        public static TreeNode sortedArrayToBST(int[] nums)
        {
            return helper(nums, 0, nums.Length - 1,EnNode.Root);
        }

        public static TreeNode helper(int[] nums, int left, int right,EnNode node = EnNode.Root)
        {
            if (left > right)
            {
                return null;
            }

            // 总是选择中间位置左边的数字作为根节点
            int mid = (left + right) / 2;

            TreeNode root = new TreeNode(nums[mid]);
            Console.WriteLine($"创建节点{nums[mid]},mid{mid},left{left},right{right},EnNode.{node.ToString()}");
            root.left = helper(nums, left, mid - 1,EnNode.Left);
            root.right = helper(nums, mid + 1, right,EnNode.Right);
            TreeUtil.PrintTree(root);
            return root;
        }

        public static void Test()
        {
            int[] array = new int[] { -10, -3, 0, 5, 9 };
            sortedArrayToBST(array);
        }
    }
}
