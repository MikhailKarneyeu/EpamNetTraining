using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GenericBinaryTree
{
    public class TreeNode<T> where T:IComparable<T>, IXmlSerializable
    {
        public TreeNode()
        { 
        }
        public TreeNode(T value, TreeNode<T> parent)
        {
            Value = value;
            Parent = parent;
        }

        [XmlElement(IsNullable = true)]
        public TreeNode<T> Left { get; set; }
        [XmlElement(IsNullable = true)]
        public TreeNode<T> Right { get; set; }
        [XmlIgnore]
        public TreeNode<T> Parent { get; set; }
        public T Value { get; set; }

        internal TreeNode<T> Balance()
        {
            TreeNode<T> head = null;
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceFactor < 0)
                {
                    
                    var result = LeftRightRotation();
                    if (result != null)
                        head = result;
                }

                else
                {
                    var result = LeftRotation();
                    if (result != null)
                        head = result;
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceFactor > 0)
                {
                    var result = RightLeftRotation();
                    if (result != null)
                        head = result;
                }
                else
                {
                    var result = RightRotation();
                    if (result != null)
                        head = result;
                }
            }
            return head;
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

        private TreeNode<T> LeftRotation()
        {
            TreeNode<T> newRoot = Right;
            TreeNode<T> head = ReplaceRoot(newRoot);
            Right = newRoot.Left;
            newRoot.Left = this;
            return head;
        }

        private TreeNode<T> RightRotation()
        {
            TreeNode<T> newRoot = Left;
            TreeNode<T> head = ReplaceRoot(newRoot);
            Left = newRoot.Right;
            newRoot.Right = this;
            return head;
        }

        private TreeNode<T> LeftRightRotation()
        {
            TreeNode<T> head = null;
            var result = Right.RightRotation();
            if (result != null)
                head = result;
            result = LeftRotation();
            if (result != null)
                head = result;
            return head;
        }

        private TreeNode<T> RightLeftRotation()
        {
            TreeNode<T> head = null;
            var result = Left.LeftRotation();
            if (result != null)
                head = result;
            result = RightRotation();
            if (result != null)
                head = result;
            return head;
        }

        private TreeNode<T> ReplaceRoot(TreeNode<T> newRoot)
        {
            TreeNode<T> head = null;
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
                head = newRoot;
            }

            newRoot.Parent = this.Parent;
            this.Parent = newRoot;
            return head;
        }
    }
}
