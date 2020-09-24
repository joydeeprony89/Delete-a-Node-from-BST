using System;
using System.Collections.Generic;

namespace Delete_a_Node_from_BST
{
    class Program
    {
        class Node
        {
            public int val;
            public Node left, right;
            public Node(int val)
            {
                this.val = val;
                left = right = null;
            }
        }
        static void Main(string[] args)
        {
            Node root = new Node(12);
            root.left = new Node(5);
            root.right = new Node(15);

            root.left.left = new Node(3);
            root.left.left.left = new Node(1);
            root.left.right = new Node(7);
            root.left.right.right = new Node(9);
            root.left.right.right.left = new Node(8);
            root.left.right.right.right = new Node(11);

            root.right.left = new Node(13);
            root.right.left.right = new Node(14);
            root.right.right = new Node(17);
            root.right.right.right = new Node(20);
            root.right.right.right.left = new Node(18);
            Console.WriteLine("BST Level Order is");
            LevelOrder(root);
            Console.WriteLine("Enter the node you want to delete!");
            var input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Performing Delete");
            Node node =  Delete(root, input);
            Console.WriteLine("After delete Level Order is");
            LevelOrder(node);
        }

        static Node Delete(Node root, int val)
        {
            if (root == null) return root;
            // check left / right subtree based on the val which we want to delete
            if (val < root.val) root.left = Delete(root.left, val);
            else if (val > root.val) root.right = Delete(root.right, val);
            // here we have found the val
            else
            {
                // when we have found the val there are 3 scenarios
                // val node does not have left and right
                // left Node
                if (root.left == null && root.right == null) root = null;
                // val node does not have left
                else if (root.left == null) root = root.right;
                // val node does not have right
                else if (root.right == null) root = root.left;
                // val node has both left and right
                else
                {
                    // find the minimum from right subtree
                    // make the minimum node as root
                    // recursively delete the found node from right subtree
                    Node temp = FindMin(root.right);
                    root.val = temp.val;
                    root.right = Delete(root.right, temp.val);
                }
                return root;
            }
            return root;
        }

        static Node FindMin(Node root)
        {
            while (root.left != null) root = root.left;
            return root;
        }

        static void LevelOrder(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while(q.Count > 0)
            {
                Node node = q.Dequeue();
                Console.WriteLine(node?.val);

                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
        }
    }
}
