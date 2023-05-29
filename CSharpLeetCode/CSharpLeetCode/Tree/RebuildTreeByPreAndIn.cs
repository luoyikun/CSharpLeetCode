using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    public class TreeNode
    {
        public int m_value = 0;
        public TreeNode left;
        public TreeNode right;
    }
    class RebuildTreeByPreAndIn
    {
        private static TreeNode buildTree(int[] arrPre, int[] arrIn)
        {
            if (arrPre == null || arrIn == null || arrPre.Length != arrIn.Length || arrPre.Length < 1)
            {
                return null;
            }
            return helper(arrPre, arrIn, 0, arrPre.Length-1 ,0, arrIn.Length - 1);
        }

        /// <summary>
        /// 递归调用，输出节点
        /// </summary>
        /// <param name="arrPre">先序数组</param>
        /// <param name="arrIn">中序数组</param>
        /// <param name="preStart">先序开始idx，代表即将返回根节点在先序中idx</param>
        /// <param name="inStart">中序开始idx，代表左右子树在中序开始idx</param>
        /// <param name="inEnd">中序结束idx，代表左右子树在中序结束idx</param>
        /// <returns></returns>
        private static TreeNode helper(int[] arrPre, int[] arrIn, int preStart,int preEnd, int inStart, int inEnd)
        {
            //终止条件
            if (inStart > inEnd || preStart > preEnd)
            {
                Console.WriteLine(string.Format("preStart:{0}--preEnd{1};;;inStart:{1}--inEnd:{2}", preStart, preEnd, inStart, inEnd));
                return null;
            }
            
            int currentVal = arrPre[preStart];
            TreeNode current = new TreeNode();
            current.m_value = currentVal;

            //开始找中序中的根节点，然后分出左子树和右子树
            int inIndex = 0;
            //记录根节点
            for (int i = inStart; i <= inEnd; i++)
            {
                if (arrIn[i] == currentVal)
                {
                    inIndex = i;
                    break;
                }
            }

            int left_cnt = inIndex - inStart;//计算一下左子树的长度，方便确定

            Console.WriteLine(string.Format("preStart:{0}--preEnd{1};;;inStart:{2}--inEnd:{3};;;inIndex:{4} -- value:{5}", preStart,preEnd, inStart, inEnd, inIndex, currentVal));
            //左子树
            TreeNode left = helper(arrPre, arrIn, preStart + 1,preStart + left_cnt, inStart, inIndex - 1);
            //右子树
            TreeNode right = helper(arrPre, arrIn, preStart + 1 + left_cnt, preEnd, inIndex + 1, inEnd);
            current.left = left;
            current.right = right;
            return current;
        }

        public static void Rebuild()
        {
            int[] arrPre = { 1,2,4,7,3,5,6,8};
            int[] arrIn = { 4, 7, 2, 1, 5, 3, 8, 6 };
            TreeNode current = buildTree(arrPre, arrIn);
            int i = 0;
            TreeUtil.PrintTree(current);
        }
    }
}
