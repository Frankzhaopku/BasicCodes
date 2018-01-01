using System.Collections.Generic;

namespace BasicCodes
{
    public class BinaryTree<T>
    {
        public TreeNode Root;

        public override string ToString()
        {
            return "BinaryTree";
        }

        public class TreeNode
        {
            public T Value;
            public TreeNode LeftChild;
            public TreeNode RightChild;

            public TreeNode(T val, TreeNode leftNode = null, TreeNode rightNode = null)
            {
                Value = val;
                LeftChild = leftNode;
                RightChild = rightNode;
            }

            public override string ToString()
            {
                return $"{Value}";
            }
        }
    }


    public static class TreeHelper
    {
        public static void PreOrder1<T>(this BinaryTree<T> tree)
        {
            PreOrderRecursive(tree.Root);
        }

        private static void PreOrderRecursive<T>(BinaryTree<T>.TreeNode node)
        {
            if (node == null) return;
            Logger.Log(node);
            PreOrderRecursive(node.LeftChild);
            PreOrderRecursive(node.RightChild);
        }

        public static void PreOrder2<T>(this BinaryTree<T> tree)
        {
            if (tree.Root == null) return;
            var stack = new Stack<BinaryTree<T>.TreeNode>();
            var curNode = tree.Root;
            var maxStackNum = stack.Count;
            var pushCount = 0;
            var popCount = 0;
            while (curNode != null || stack.Count > 0)
            {
                if (curNode != null)
                {
                    Logger.Log(curNode);
                    stack.Push(curNode);
                    pushCount++;
                    curNode = curNode.LeftChild;
                }
                else
                {
                    curNode = stack.Pop().RightChild;
                    popCount++;
                }
                if (stack.Count > maxStackNum) maxStackNum = stack.Count;
            }
            Logger.Log($"Stack max count={maxStackNum}, pushCount={pushCount}, popCount={popCount}");
        }

        public static void PreOrder3<T>(this BinaryTree<T> tree)
        {
            if (tree.Root == null) return;
            var stack = new Stack<BinaryTree<T>.TreeNode>();
            stack.Push(tree.Root);
            var maxStackNum = stack.Count;
            var pushCount = 1;
            var popCount = 0;
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                popCount++;
                Logger.Log(node);
                if (node.RightChild != null)
                {
                    stack.Push(node.RightChild);
                    pushCount++;
                }
                if (node.LeftChild != null)
                {
                    stack.Push(node.LeftChild);
                    pushCount++;
                }
                if (stack.Count > maxStackNum) maxStackNum = stack.Count;
            }
            Logger.Log($"Stack max count={maxStackNum}, pushCount={pushCount}, popCount={popCount}");
        }

        public static void InOrder1<T>(this BinaryTree<T> tree)
        {
            InOrderRecursive(tree.Root);
        }

        private static void InOrderRecursive<T>(BinaryTree<T>.TreeNode node)
        {
            if (node == null) return;
            InOrderRecursive(node.LeftChild);
            Logger.Log(node);
            InOrderRecursive(node.RightChild);
        }

        public static void InOrder2<T>(this BinaryTree<T> tree)
        {
            if (tree.Root == null) return;
            var stack = new Stack<TreeNodeWrap<T>>();
            stack.Push(new TreeNodeWrap<T> {Node = tree.Root, Visited = false});
            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (!node.Visited && node.Node.LeftChild != null)
                {
                    node.Visited = true;
                    stack.Push(new TreeNodeWrap<T> {Node = node.Node.LeftChild, Visited = false});
                }
                else
                {
                    node = stack.Pop();
                    Logger.Log(node.Node);
                    if (node.Node.RightChild != null)
                    {
                        stack.Push(new TreeNodeWrap<T> {Node = node.Node.RightChild, Visited = false});
                    }
                }
            }
        }

        public static void InOrder3<T>(this BinaryTree<T> tree)
        {
            if (tree.Root == null) return;
            var stack = new Stack<BinaryTree<T>.TreeNode>();
            var curNode = tree.Root;
            while (curNode != null || stack.Count > 0)
            {
                if (curNode != null)
                {
                    stack.Push(curNode);
                    curNode = curNode.LeftChild;
                }
                else
                {
                    curNode = stack.Pop();
                    Logger.Log(curNode);
                    curNode = curNode.RightChild;
                }
            }
        }

        public static void PostOrder1<T>(this BinaryTree<T> tree)
        {
            PostOrderRecursive(tree.Root);
        }

        private static void PostOrderRecursive<T>(BinaryTree<T>.TreeNode node)
        {
            if (node == null) return;
            PostOrderRecursive(node.LeftChild);
            PostOrderRecursive(node.RightChild);
            Logger.Log(node);
        }

        public static void PostOrder2()

        public class TreeNodeWrap<T>
        {
            public BinaryTree<T>.TreeNode Node;
            public bool Visited;
        }
    }
}
