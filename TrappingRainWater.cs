//https://leetcode.com/problems/trapping-rain-water/

	public int Trap(int[] heights) 
	{	
		//calculate left Maxes
		var maxes = new int[heights.Length];
		int leftMax = 0;
		for(int i =0; i< heights.Length;i++)
		{
		     int height = heights[i];
		     maxes[i] = leftMax;
		     leftMax =  Math.Max(leftMax,height);			
		}		
		
		//while we're calculating the rightMax, let's calculate the minHeight as well since we have the leftMax from above
		//by doing this now, we avoid having to first calculate the rightMax and then the minHeight "separately in an another loop"
		int rightMax = 0;		
		for(int i =heights.Length-1; i >= 0;i--)
		{
			int height = heights[i];
		  	int minHeight = Math.Min(rightMax,maxes[i]);
			if(height < minHeight)
			{
			    maxes[i] = minHeight - height;
			}
			else
			{
			    maxes[i] = 0;
			}
			rightMax =  Math.Max(rightMax,height);			
		}
		
		int totalwater = 0;
		for(int i  = 0; i < heights.Length; i++)
		{
		    totalwater += maxes[i];
		}		

		return totalwater;
	}
	
