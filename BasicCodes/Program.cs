using System.Collections.Generic;

namespace BasicCodes
{
    public class Program
    {
        private static void Main(string[] args)
        {
//            ListTest();
            TreeTest();
        }

        private static void ListTest()
        {
            var list = new List<int> { 13, 4, 3, 8, 21, 332, 2, 4 };
            list.Print();
            list.QuickSort();
            list.Print();
            list.QuickSort((a, b) => -a.CompareTo(b));
            list.Print();
        }

        private static void TreeTest()
        {
            var tree = new BinaryTree<int>
            {
                Root = new BinaryTree<int>.TreeNode(10)
                {
                    LeftChild = new BinaryTree<int>.TreeNode(5)
                    {
                        LeftChild = new BinaryTree<int>.TreeNode(3)
                        {
                            LeftChild = new BinaryTree<int>.TreeNode(9)
                        },
                        RightChild = new BinaryTree<int>.TreeNode(6)
                        {
                            LeftChild = new BinaryTree<int>.TreeNode(11)
                        }
                    },
                    RightChild = new BinaryTree<int>.TreeNode(8, new BinaryTree<int>.TreeNode(4)
                    {
                        RightChild = new BinaryTree<int>.TreeNode(7)
                    }, new BinaryTree<int>.TreeNode(2)
                    {
                        LeftChild = new BinaryTree<int>.TreeNode(1)
                    })
                }
            };

            Logger.Log("PreOrder1:");
            tree.PreOrder1();
            Logger.Log("PreOrder2:");
            tree.PreOrder2();
            Logger.Log("PreOrder3");
            tree.PreOrder3();

            Logger.Log("InOrder1:");
            tree.InOrder1();
            Logger.Log("InOrder2:");
            tree.InOrder2();
            Logger.Log("InOrder3:");
            tree.InOrder3();

            Logger.Log("PostOrder1:");
            tree.PostOrder1();
            Logger.Log("PostOrder2:");
            tree.PostOrder2();
            Logger.Log("PostOrder3:");
            tree.PostOrder3();
        }
    }
}
