using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GenericBinaryTree
{
    /// <summary>
    /// Binary tree node class.
    /// </summary>
    /// <typeparam name="T">Type of stored object.</typeparam>
    public class TreeNode<T> where T:IComparable<T>, IXmlSerializable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TreeNode()
        { 
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="value">Stored object.</param>
        /// <param name="parent">Parent node.</param>
        public TreeNode(T value, TreeNode<T> parent)
        {
            Value = value;
            Parent = parent;
        }

        /// <summary>
        /// Left child node.
        /// </summary>
        [XmlElement(IsNullable = true)]
        public TreeNode<T> Left { get; set; }

        /// <summary>
        /// Right child node.
        /// </summary>
        [XmlElement(IsNullable = true)]
        public TreeNode<T> Right { get; set; }

        /// <summary>
        /// Parent node.
        /// </summary>
        [XmlIgnore]
        public TreeNode<T> Parent { get; set; }

        /// <summary>
        /// Stored object.
        /// </summary>
        public T Value { get; set; }

        internal TreeNode<T> Balance(TreeNode<T> treeHead)
        {
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceFactor < 0)
                {

                    treeHead = LeftRightRotation(treeHead);
                }

                else
                {
                    treeHead = LeftRotation(treeHead);
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceFactor > 0)
                {
                    treeHead = RightLeftRotation(treeHead);
                }
                else
                {
                    treeHead = RightRotation(treeHead);
                }
            }
            return treeHead;
        }
        private int MaxChildHeight(TreeNode<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }
            return 0;
        }

        private int LeftHeight
        {
            get
            {
                return MaxChildHeight(Left);
            }
        }

        private int RightHeight
        {
            get
            {
                return MaxChildHeight(Right);
            }
        }

        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                {
                    return TreeState.LeftHeavy;
                }

                if (RightHeight - LeftHeight > 1)
                {
                    return TreeState.RightHeavy;
                }

                return TreeState.Balanced;
            }
        }

        private int BalanceFactor
        {
            get
            {
                return RightHeight - LeftHeight;
            }
        }

        private TreeNode<T> LeftRotation(TreeNode<T> treeHead)
        {
            TreeNode<T> newRoot = Right;
            treeHead = ReplaceRoot(newRoot, treeHead);
            Right = newRoot.Left;
            newRoot.Left = this;
            return treeHead;
        }

        private TreeNode<T> RightRotation(TreeNode<T> treeHead)
        {
            TreeNode<T> newRoot = Left;
            treeHead = ReplaceRoot(newRoot, treeHead);
            Left = newRoot.Right;
            newRoot.Right = this;
            return treeHead;
        }

        private TreeNode<T> LeftRightRotation(TreeNode<T> treeHead)
        {
            treeHead = Right.RightRotation(treeHead);
            treeHead = LeftRotation(treeHead);
            return treeHead;
        }

        private TreeNode<T> RightLeftRotation(TreeNode<T> treeHead)
        {
            treeHead = Left.LeftRotation(treeHead);
            treeHead = RightRotation(treeHead);
            return treeHead;
        }

        private TreeNode<T> ReplaceRoot(TreeNode<T> newRoot, TreeNode<T> treeHead)
        {
            if (this.Parent != null)
            {
                if (this.Parent.Left == this)
                {
                    this.Parent.Left = newRoot;
                }
                else if (this.Parent.Right == this)
                {
                    this.Parent.Right = newRoot;
                }
            }
            else
            {
                treeHead = newRoot;
            }

            newRoot.Parent = this.Parent;
            this.Parent = newRoot;
            return treeHead;
        }
    }
}
