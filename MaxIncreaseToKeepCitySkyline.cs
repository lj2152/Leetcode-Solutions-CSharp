//https://leetcode.com/problems/max-increase-to-keep-city-skyline/ 


    public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int len = grid.Length;

            int[] rowArray = new int[len];
            int[] colArray = new int[len];

            for (int row = 0; row < len; row++)
            {
                for (int col = 0; col < len; col++)
                {
                    int currentValue = grid[row][col];
                    rowArray[row] = Math.Max(currentValue, rowArray[row]);
                    colArray[col] = Math.Max(currentValue, colArray[col]);
                }
            }
            int totalSum = 0;
            for (int row = 0; row < len; row++)
            {
                for (int col = 0; col < len; col++)
                {
                    int maxHeightPossible = Math.Min(rowArray[row], colArray[col]);
                    int currentValue = grid[row][col];
                    int valueToIncrease = maxHeightPossible - currentValue;
                    totalSum += valueToIncrease;
                }
            }
                
            return totalSum;
        }