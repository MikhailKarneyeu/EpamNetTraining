using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GenericBinaryTree
{
    /// <summary>
    /// Class to store and operate binary tree.
    /// </summary>
    /// <typeparam name="T">Type of stored object.</typeparam>
    public class BinaryTree<T> where T : IComparable<T>, IXmlSerializable
    {
        /// <summary>
        /// Head node of a tree.
        /// </summary>
        public TreeNode<T> Head { get; set; }

        /// <summary>
        /// Node count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BinaryTree()
        {
        }

        /// <summary>
        /// Object adding operation.
        /// </summary>
        /// <param name="value">Object to store in node.</param>
        public void Add(T value)
        {  
            if (Head == null)
            {
                Head = new TreeNode<T>(value, null);
            }
            else
            {
                AddNode(Head, value);
            }
            Count++;
        }

        private void AddNode(TreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode<T>(value, node);
                }
                else
                {
                    AddNode(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode<T>(value, node);
                }
                else
                {         
                    AddNode(node.Right, value);
                }
            }
            Head = node.Balance(Head);
        }
        /// <summary>
        /// Operation to check if object contains in tree.
        /// </summary>
        /// <param name="value">Object to check.</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        private TreeNode<T> Find(T value)
        {

            TreeNode<T> current = Head;
            while (current != null)
            {
                int result = current.Value.CompareTo(value);
                if (result > 0)
                {
                    current = current.Left;
                }
                else if (result < 0)
                {        
                    current = current.Right;
                }
                else
                {   
                    break;
                }
            }
            return current;
        }

        /// <summary>
        /// Node with object removing operation.
        /// </summary>
        /// <param name="value">Object to remove.</param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            TreeNode<T> current;
            current = Find(value);
            if (current == null)
            {
                return false;
            }
            TreeNode<T> treeToBalance = current.Parent;
            Count--;                                      
            if (current.Right == null)
            {
                if (current.Parent == null)
                {
                    Head = current.Left;

                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = current.Parent.Value.CompareTo(current.Value);

                    if (result > 0)
                    {
                        current.Parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        current.Parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (current.Parent == null)
                {
                    Head = current.Right;

                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = current.Parent.Value.CompareTo(current.Value);
                    if (result > 0)
                    {
                        current.Parent.Left = current.Right;
                    }

                    else if (result < 0)
                    {
                        current.Parent.Right = current.Right;
                    }
                }
            }
            else
            {
                TreeNode<T> leftmost = current.Right.Left;
                while (leftmost.Left != null)
                {
                    leftmost = leftmost.Left;
                }
                leftmost.Parent.Left = leftmost.Right;    
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (current.Parent == null)
                {
                    Head = leftmost;

                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = current.Parent.Value.CompareTo(current.Value);

                    if (result > 0)
                    {
                        current.Parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        current.Parent.Right = leftmost;
                    }
                }
            }
            if (treeToBalance != null)
            {
                Head = treeToBalance.Balance(Head);
            }
            else
            {
                if (Head != null)
                {
                    Head = Head.Balance(Head);
                }
            }
            return true;

        }

        /// <summary>
        /// Tree clearing opearation.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Geting object in list.
        /// </summary>
        /// <returns>List of stored objects.</returns>
        public List<T> ToList()
        {
            List<T> list = new List<T>();
            if (Head != null)
            {
                Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
                TreeNode<T> current = Head;
                bool goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    if(!list.Contains(current.Value))
                        list.Add(current.Value);
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Saving to xml file operation.
        /// </summary>
        /// <param name="filePath">Path to file to save.</param>
        public void SaveToXmlFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BinaryTree<T>));
            using StreamWriter writer = new StreamWriter(filePath);
            serializer.Serialize(writer, this);
        }

        /// <summary>
        /// Reading tree from xml file opearion.
        /// </summary>
        /// <param name="filePath">Path to xml file.</param>
        public void ReadFromXmlFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BinaryTree<T>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                var tree = serializer.Deserialize(reader);
                Head = ((BinaryTree<T>)tree).Head;
                Count = ((BinaryTree<T>)tree).Count;
            }
            AfterReadParentRestore();
        }

        private void AfterReadParentRestore()
        {
            if (Head != null)
            {
                Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
                TreeNode<T> current = Head;
                bool goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current.Left.Parent = current;
                            current = current.Left;
                        }
                    }
                    if (current.Right != null)
                    {
                        current.Right.Parent = current;
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
                Head = Head.Balance(Head);
            }
        }
    }
}
