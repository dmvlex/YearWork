using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearWork 
{
    public enum Side // Расположение относительно родителя
    {
        Left,
        Right
    }
    internal class TreeNode<T> where T : IComparable
    {
        public T Value { get; set; } // Значение ноды
        public Side? NodeSide { get; set; } //Положение узла относительно родителя

        public TreeNode<T> LeftNode { get; set; } // Левая дочерняя нода
        public TreeNode<T> RightNode { get; set; } // Правая дочерняя нода
        public TreeNode<T> ParentNode { get; set; } //Ссылка на родительскую ноду

        public override string ToString() // Перезапись преобразования ноды в строку. Будет выводиться значение ноды
        {
            return Value.ToString();
        }


        public TreeNode(T value)
        {
            Value = value;

            //определение положения ноды относительно родителя
            if(ParentNode != null)
            {
                if(ParentNode.LeftNode == this)
                {
                    NodeSide = Side.Left;
                }
                else if (ParentNode.RightNode == this)
                {
                    NodeSide = Side.Right;
                }
            }
            else
            {
                NodeSide = null;
            }
        }
    }
}
