using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    //二叉树展开为链表
    public class Tree2List
    {
        public static void flatten(TreeNode root)
        {
            while (root != null)
            {
                //左子树为 null，直接考虑下一个节点
                if (root.left == null)
                {
                    Console.WriteLine($"左子树为 null，直接考虑下一个节点,当前root:{root.val},right:{root.right ?.val}");
                    root = root.right;
                }
                else
                {
                    // 找左子树最右边的节点
                    TreeNode pre = root.left;
                    while (pre.right != null)
                    {
                        pre = pre.right;
                    }
                    //将原来的右子树接到左子树的最右边节点
                    pre.right = root.right;
                    // 将左子树插入到右子树的地方
                    root.right = root.left;
                    root.left = null;
                    // 考虑下一个节点
                    root = root.right;
                }
            }
        }

        public static void Test()
        {
            List<int?> list = new List<int?>(new int?[] { 1, 2, 5, 3, 4, null, 6 });
            TreeNode tree = TreeUtil.BuildTreeByLevelOrder(list);
            flatten(tree);
            Console.WriteLine($"二叉树转链表{PublicFunc.GetObjet2Str(TreeUtil.GetLevelOrder(tree))}");
        }


    }
}
