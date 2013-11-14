//You are given a tree of N nodes represented as a set of N-1 pairs
//of nodes (parent node, child node), each in the range (0..N-1).
//Write a program to read the tree and find:
//a) the root node
//b) all leaf nodes
//c) all middle nodes
//d)* the longest path in the tree
//e)* all paths in the tree with given sum S of their nodes
//f)* all subtrees with given sum S of their nodes


using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1TreeManipulation
{
    class TreeManipulation
    {
        static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("nodes", "The tree has no root.");
        }

        static List<Node<int>> FindLeaf(Node<int>[] nodes)
        {
            List<Node<int>> leaves = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leaves.Add(node);
                }
            }

            if (leaves.Count == 0)
            {
                throw new ArgumentException("The tree has no leaves.");
            }

            return leaves;
        }

        private static List<Node<int>> FindMiddleNode(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static int TreeHeight(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, TreeHeight(node));
            }

                return maxPath + 1;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[n];

            //Creating new empty tree
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            //Initializing the tree
            for (int i = 1; i <= n - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                int parentID = int.Parse(edgeParts[0]);
                int childID = int.Parse(edgeParts[1]);

                nodes[parentID].Children.Add(nodes[childID]);
                nodes[childID].HasParent = true;
            }

            //Task A - find the root of the tree
            var root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            //Task B - find all leaves
            var leaves = FindLeaf(nodes);
            Console.WriteLine("The leaves it the tree are:");
            foreach (var leaf in leaves)
            {
                Console.Write("{0} ", leaf.Value);
            }

            //Task C - find all middle nodes
            var middleNodes = FindMiddleNode(nodes);
            Console.WriteLine("The leaves it the tree are:");
            foreach (var node in middleNodes)
            {
                Console.Write("{0} ", node.Value);
            }

            //Task D - find the longest path from the root(height oh the tree)
            //and longest path
            var treeheight = TreeHeight(FindRoot(nodes));
            Console.WriteLine("The height of the tree is: {0}", treeheight);

            //Task E - find all paths in the tree with given sum S of their nodes
            Console.Write("Enter the sum you want to check if it exists S= ");
            //int s = int.Parse(Console.ReadLine());


        }
    }
}
