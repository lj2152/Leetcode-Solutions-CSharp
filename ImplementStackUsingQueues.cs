//https://leetcode.com/problems/implement-stack-using-queues/


public class MyStack {

       Queue<int> queue = new Queue<int>();

        /** Initialize your data structure here. */
        public MyStack()
        {

        }
        // Push element x onto stack.
        public void Push(int x)
        {
            queue.Enqueue(x);
            for (int i = 0; i < queue.Count - 1; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
                
        }

        // Removes the element on top of the stack.
        public int Pop()
        {
            return queue.Dequeue();
        }

        // Get the top element.
        public int Top()
        {
            return queue.Peek();
        }

        // Return whether the stack is empty.
        public bool Empty()
        {
            return queue.Count == 0;
        }
}