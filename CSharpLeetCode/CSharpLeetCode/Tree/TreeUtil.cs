using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Tree
{
    class TreeUtil
    {
        /*
      树的结构示例：
                1
              /   \
            2       3
           / \     / \
          4   5   6   7
      */

        // 用于获得树的层数
        public static int getTreeDepth(TreeNode root)
        {
            return root == null ? 0 : (1 + Math.Max(getTreeDepth(root.left), getTreeDepth(root.right)));
        }


        private static void writeArray(TreeNode currNode, int rowIndex, int columnIndex, String[][] res, int treeDepth)
        {
            // 保证输入的树不为空
            if (currNode == null) return;
            // 先将当前节点保存到二维数组中
            res[rowIndex][columnIndex] = currNode.m_value.ToString();

            // 计算当前位于树的第几层
            int currLevel = ((rowIndex + 1) / 2);
            // 若到了最后一层，则返回
            if (currLevel == treeDepth) return;
            // 计算当前行到下一行，每个元素之间的间隔（下一行的列索引与当前元素的列索引之间的间隔）
            int gap = treeDepth - currLevel - 1;

            // 对左儿子进行判断，若有左儿子，则记录相应的"/"与左儿子的值
            if (currNode.left != null)
            {
                res[rowIndex + 1][columnIndex - gap] = "/";
                writeArray(currNode.left, rowIndex + 2, columnIndex - gap * 2, res, treeDepth);
            }

            // 对右儿子进行判断，若有右儿子，则记录相应的"\"与右儿子的值
            if (currNode.right != null)
            {
                res[rowIndex + 1][columnIndex + gap] = "\\";
                writeArray(currNode.right, rowIndex + 2, columnIndex + gap * 2, res, treeDepth);
            }
        }


        public static void PrintTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            // 得到树的深度
            int treeDepth = getTreeDepth(root);

            // 最后一行的宽度为2的（n - 1）次方乘3，再加1
            // 作为整个二维数组的宽度
            int arrayHeight = treeDepth * 2 - 1;
            int arrayWidth = (2 << (treeDepth - 2)) * 3 + 1;
            // 用一个字符串数组来存储每个位置应显示的元素
            String[][] res = new String[arrayHeight][];
            for (int i =0; i < arrayHeight; i++)
            {
                res[i] = new String[arrayWidth];
            }
            // 对数组进行初始化，默认为一个空格
            for (int i = 0; i < arrayHeight; i++)
            {
                for (int j = 0; j < arrayWidth; j++)
                {
                    res[i][j] = " ";
                }
            }

            // 从根节点开始，递归处理整个树
            // res[0][(arrayWidth + 1)/ 2] = (char)(root.val + '0');
            writeArray(root, 0, arrayWidth / 2, res, treeDepth);

            // 此时，已经将所有需要显示的元素储存到了二维数组中，将其拼接并打印即可
            for (int row = 0; row < arrayHeight; row++)
            {
                String[] line = res[row];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < line.Length; i++)
                {
                    sb.Append(line[i]);
                    if (line[i].Length > 1 && i <= line.Length - 1)
                    {
                        i += line[i].Length > 4 ? 2 : line[i].Length - 1;
                    }
                }
                Console.WriteLine(sb.ToString());
            }
        }

    }
}
