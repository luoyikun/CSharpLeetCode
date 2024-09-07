using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    /// <summary>
    /// 对称二叉树，深度优先搜索
    /// </summary>
    public class SymmetricTreeDFS
    {
        public static bool isSymmetric(TreeNode root)
        {
            return check(root, root);
        }

        public static  bool check(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            //上面已经排除了两个都为空的情况，这里只需判断有一个为空即返回
            if (p == null || q == null)
            {
                return false;
            }
            Console.WriteLine($"比较节点{p.val}--{q.val}");
            return p.val == q.val && check(p.left, q.right) && check(p.right, q.left);
        }

        public static void Test()
        {
            List<int?> list = new List<int?>(new int?[] { 1, 2, 2, 3, 4, 4, 3 });
            TreeNode tree = TreeUtil.BuildTreeByLevelOrder(list);
            bool ret = isSymmetric(tree);
            Console.WriteLine($"二叉树是否对称：{ret}");
        }


    }
}
