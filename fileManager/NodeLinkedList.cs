using System;
using System.Collections.Generic;
using System.Text;

namespace fileManager
{
    class NodeLinkedList
    {
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        public void AddNode(string value)
        {
            Node node = new Node { Value = value };
            if (this.GetCount() == 0)
            {
                StartNode = node;
            }
            else if (this.GetCount() == 1)
            {
                EndNode = node;
                StartNode.NextNode = EndNode;
                EndNode.PrevNode = StartNode;
            }
            else
            {
                Node currentNode = StartNode;
                while (true)
                {
                    if (currentNode.NextNode == null)
                    {
                        EndNode = node;
                        currentNode.NextNode = EndNode;
                        EndNode.PrevNode = currentNode.PrevNode.NextNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.NextNode;
                    }
                }
            }
        }
        private int GetCount()
        {
            int count = 0;
            Node currentNode = StartNode;
            while (true)
            {
                if (currentNode == null)
                {
                    break;
                }
                else if (currentNode.NextNode == null)
                {
                    count++;
                    break;
                }
                else
                {
                    count++;
                    currentNode = currentNode.NextNode;
                }
            }
            return count;
        }
        public NodeLinkedList GetCurrentList(NodeLinkedList drives, NodeLinkedList directories)
        {
            var currentList = new NodeLinkedList();
            currentList.StartNode.Value = drives.StartNode.Value;
            var currentNode = directories.StartNode;
            int count = directories.GetCount();
            for(int i = 0; i < count; i++)
            {
                currentList.AddNode(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            return currentList;
        }

        public void Display()
        {
            Node currentNode = StartNode;
            int count = this.GetCount();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{currentNode.Value}");
                currentNode = currentNode.NextNode;
            }
        }
    }
}
