using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    /// <summary>
    /// 二叉树最大深度，广度优先搜索
    /// </summary>
    public class MaxDepthBFS
    {
        public static int maxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int ans = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count; //记录现在有多个父节点
                Console.WriteLine($"当前层个数{size}");
                while (size > 0)
                {
                    TreeNode node = queue.Dequeue();
                    Console.WriteLine( $"出队节点{node.m_value}");
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                        Console.WriteLine( $"入队左节点{node.left.m_value}");
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                        Console.WriteLine( $"入队右节点{node.right.m_value}");
                    }
                    size--;
                }
                ans++;
                PublicFunc.DebugObj(ans, "层数");
            }
            return ans;
        }

        public static void Test()
        {
            List<int?> list = new List<int?>(new int?[] { 3, 9, 20, null, null, 15, 7 });
            TreeNode tree = TreeUtil.BuildTreeByLevelOrder(list);
            int ret = maxDepth(tree);
            Console.WriteLine($"二叉树最大深度{ret}");
        }
 
    }
}
