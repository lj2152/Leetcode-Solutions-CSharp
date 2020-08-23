//https://leetcode.com/problems/implement-queue-using-stacks/

public class MyQueue {    
      Stack<int> stack = new Stack<int>();
    
        /** Initialize your data structure here. */
        public MyQueue() {

        }
		
        /** Push element x to the back of queue. */
       public void Push(int x)
        {
            stack.Push(x);
        }
    
        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            return StackReverse(true);
        }
    
        /** Get the front element. */

        public int Peek()
        {
            return StackReverse();
        }
        
    
        /** Returns whether the queue is empty. */
        public bool Empty()
        {
           return stack.Count == 0;
        }
    
        /* Helper Method */
        public int StackReverse(bool pop = false)
        {
            var reversedStack = new Stack<int>();
            foreach(var element in stack)
            {                
                reversedStack.Push(element);
            }
            
           var result = pop? reversedStack.Pop() :  reversedStack.Peek();
            
            stack.Clear();
            foreach(var element in reversedStack)
            {                
                stack.Push(element);
            }
            
            return result;            
        }
}