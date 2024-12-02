
using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.MyArray
{
    //链表排序
    public class SortList
    {
        public static ListNode sortList(ListNode head)
        {
            return sortList(head, null);
        }

        public static  ListNode sortList(ListNode head, ListNode tail)
        {
            if (head == null)
            {
                return head;
            }
            if (head.next == tail)
            {
                head.next = null;
                return head;
            }
            ListNode slow = head, fast = head;
            while (fast != tail)
            {
                slow = slow.next;
                fast = fast.next;
                if (fast != tail)
                {
                    fast = fast.next;
                }
            }
            ListNode mid = slow;
            Console.WriteLine($"拆分两列{DebugHeadTail(head,mid)}--{ DebugHeadTail(mid,tail)}");
            ListNode list1 = sortList(head, mid);
            ListNode list2 = sortList(mid, tail);
            //Console.WriteLine($"拆分两列{PublicFunc.GetObjet2Str(list1)}--{PublicFunc.GetObjet2Str(list2)}");

            ListNode sorted = merge(list1, list2);
            return sorted;
        }

        static string DebugHeadTail(ListNode head, ListNode tail)
        {
            string str = "[";
            ListNode cur = head;
            while (cur != tail)
            {
                str += cur.val + ";";
                cur = cur.next;
            }
            str += "]";
            return str;

        }

        public static  ListNode merge(ListNode head1, ListNode head2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode temp = dummyHead, temp1 = head1, temp2 = head2;
            while (temp1 != null && temp2 != null)
            {
                if (temp1.val <= temp2.val)
                {
                    temp.next = temp1;
                    temp1 = temp1.next;
                }
                else
                {
                    temp.next = temp2;
                    temp2 = temp2.next;
                }
                temp = temp.next;
            }
            if (temp1 != null)
            {
                temp.next = temp1;
            }
            else if (temp2 != null)
            {
                temp.next = temp2;
            }
            Console.WriteLine($"合并后{PublicFunc.GetObjet2Str(dummyHead.next)}");
            return dummyHead.next;
        }

        public static void Test()
        {
            ListNode head = new ListNode(5);
            ListNode cur = head;
            int n = 5;
            for (int i = 1; i < n; i++)
            {
                ListNode tmp = new ListNode(n - i);
                cur.next = tmp;
                cur = tmp;
            }
            PublicFunc.DebugObj(head, "排序前：");
            head = sortList(head);
            PublicFunc.DebugObj(head, "结果：");
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int pVal)
        {
            val = pVal;
        }
    }
}
