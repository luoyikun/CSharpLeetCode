using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    /// <summary>
    /// 对称二叉树BFS
    /// </summary>
    public class SymmetricTreeBFS
    {
        public static bool isSymmetric(TreeNode root)
        {
            return check(root, root);
        }

        public static bool check(TreeNode u, TreeNode v)
        {
            Queue<TreeNode> q = new Queue<TreeNode>(8);
            q.Enqueue(u);
            Console.WriteLine($"队列塞入左{u.val}后：{TreeUtil.GetStrQueueTreeNode(q)}");
            q.Enqueue(v);
            Console.WriteLine($"队列塞入右{v.val}后：{TreeUtil.GetStrQueueTreeNode(q)}");
            while (q.Count > 0)
            {
                u = q.Dequeue();
                v = q.Dequeue();
                Console.WriteLine($"队列出队左{u?.val},右{v?.val}后：{TreeUtil.GetStrQueueTreeNode(q)}");
                if (u == null && v == null)
                {
                    continue;
                }
                if ((u == null || v == null) || (u.val != v.val))
                {
                    return false;
                }

                q.Enqueue(u.left);
                q.Enqueue(v.right);
                Console.WriteLine($"队列入队左的左{(u.left?.val)},右的右{v.right?.val}后：{TreeUtil.GetStrQueueTreeNode(q)}");
                q.Enqueue(u.right);
                q.Enqueue(v.left);
                Console.WriteLine($"队列入队左的右{u.right?.val},右的左{v.left?.val}后：{TreeUtil.GetStrQueueTreeNode(q)}");
            }
            return true;
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
