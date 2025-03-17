using System;
using System.Collections.Generic;

namespace Code.Common.Collections
{
    public class CircularLinkedList<T>
    {
        public CircularNode<T> First { get; }
        private CircularNode<T> Last { get; }

        public CircularLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var value in collection)
            {
                // Для каждого значения создаём узел
                var newNode = new CircularNode<T>(value);

                if (First == null)
                {
                    // Если пока нет ни одного узла, 
                    // Первый и Последний указывают на один и тот же объект
                    First = newNode;
                    Last = newNode;
                }
                else
                {
                    // Привязываем "конец" к новому узлу и двигаем "конец"
                    Last.Next = newNode;
                    Last = newNode;
                }
            }

            // Если список не пустой, делаем его кольцевым
            if (Last != null)
            {
                Last.Next = First;
            }
        }
    }

    public class CircularNode<T>
    {
        public T Value { get; }
        public CircularNode<T> Next { get; set; }

        public CircularNode(T value)
        {
            Value = value;
        }
    }
}