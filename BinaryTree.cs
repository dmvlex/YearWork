using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearWork
{
    internal class BinaryTree<T> where T : IComparable
    {
        public TreeNode<T> RootNode { get; set; } //корневая нода

        //перегрузка, для добавления ноды просто с помощью значения
        public TreeNode<T> Add(T Data)
        {
            return Add(new TreeNode<T>(Data));
        }
        // Публичный метод, для вывода дерева.
        public void PrintTree()
        {
            PrintTree(RootNode);
        } 


        //добавление нового узла в бинарное дерево (приватный просто, потому что инкапсуляцию соблюдать нужно, я ведь не быдло)
        private TreeNode<T> Add(TreeNode<T> node, TreeNode<T> currentNode = null)
        {
            if (RootNode == null) //если корневая нода не назначена, то добавляемый узел становится корневым
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode; //Проверка на то, не является ли нынешняя нода корневой
            node.ParentNode = currentNode;
            int result = node.Value.CompareTo(currentNode.Value); //результат сравнения значений предыдущей ноды и нынешней

            /*Дальнейший код может тебя напугать, но тут все не так страшно, как кажется.
              Дальше идет просто распределение нод по ветвям*/

            return (result == 0  // Значения совпадают? 
            ? currentNode // да, значение узла остается прежним
                : result < 0 //нет, а новое значение меньше текущего? 
                    ? currentNode.LeftNode == null //да,значение меньше, а левая ветка пустая?
                        ? (currentNode.LeftNode = node) //да пустая,вставляем в левую ветку дерева
                        : Add(node, currentNode.LeftNode)// нет,тут есть значение. Уходим в рекурсию и переходим на следующий уровень этой ветки.
                    : currentNode.RightNode == null // нет, знаечние НЕ МЕНЬШЕ. А правая ветка пустая?
                        ? (currentNode.RightNode = node) //да, ветка пустая. вставляем в правую ветку дерева
                        : Add(node, currentNode.RightNode)); //нет, ветка не пустая. Уходим в рекурсию и переходим на следующий уровень ветки
        }

        //реализация вывода. (Тоже приватная и доступ через отдельный паблик метод, потому что инкапсуляция наше все!)

        private void PrintTree(TreeNode<T> startNode, string indent = " ", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null // сторона не определена? 
                    ? "Root" //Да, сторона не определена, значит узел корневой.
                    : side == Side.Left //Нет, сторона определена. А она левая?
                        ? "L" : "R";// Если да - то обозначить "L", иначе - "R"
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Value}"); //вывод ветки
                indent += new string(' ', 3); // добавляем отступ

                //рекурсивный вызов для левой и правой ветки
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }


        }

    }
}
