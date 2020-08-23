//https://leetcode.com/problems/valid-parentheses/


  public bool IsValid(string s) {
        
        var matchingBrackets = new Dictionary<char,char>();
        
       matchingBrackets.Add(')','(');
       matchingBrackets.Add('}','{');
       matchingBrackets.Add(']','[');
        
        var openingBrackets = "({[";
        var closingBrackets = "]})";
        
        var stack = new Stack<char>();
        
                
        for(int i = 0; i< s.Length; i++)
        {
            var currChar = s[i];
            
            if(openingBrackets.IndexOf(currChar) != -1)
            {
                stack.Push(currChar);
            }
            else if(closingBrackets.IndexOf(currChar) != -1)
            {
               if(stack.Count == 0)
               {
                   return false;
               }
                
               if(stack.Peek() == matchingBrackets[currChar])
               {
                   stack.Pop();
               }
                else
                {
                    return false;
                }
            }
            
        }        
        
        return stack.Count == 0;
        
    }