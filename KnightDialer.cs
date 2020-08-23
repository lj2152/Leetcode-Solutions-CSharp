//https://leetcode.com/problems/knight-dialer/


  public int KnightDialer(int N) {
  
			// 0 1 2 3 4 5 6 7 8 9
  
  
           //all possible "from" paths for each digit (index)...
            var fromPath = new int[][] { new int[]{ 4, 6 }, new int[] { 6, 8 }, new int[] { 7, 9 }, new int[] { 4, 8 },
                                new int[]{ 3, 9, 0 }, new int[]{ }, new int[]{ 1, 7, 0 }, new int[]{ 2, 6 }, new int[]{ 1, 3 }, new int[]{ 2, 4 } };
            
			//this has to be long instead of int due to this number being this large
			long MOD = 1000000007;

            var steps = N + 1; //include step 0 so N+1
            var possibleNumbers = 10; //0 through 9 in the keypad

            //row will have all the steps
            //col will have all possible numbers

            var rowCol = new long[steps, possibleNumbers]; //this already initializes everything to 0

            //initialize step 1 (row 1) to have 1's for all columns
            for (int col = 0; col < possibleNumbers; col++)
            {
                rowCol[1, col] = 1;
            }

            //fill the rest...
            for (int row = 2; row < steps; row++)
            {
                for (int col = 0; col < possibleNumbers; col++)
                {
                    var possibleFromPaths = fromPath[col];
                    foreach (var path in possibleFromPaths)
                    {
                        rowCol[row, col] += rowCol[row - 1, path];
                    }
                    rowCol[row, col] %= MOD;
                }               
            }
            long totalSum = 0;
            for (int col = 0; col < possibleNumbers; col++)
            {
                totalSum += rowCol[N,col];
            }

            totalSum = totalSum % MOD;
		
            return (int)totalSum;
    }