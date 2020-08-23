//https://leetcode.com/problems/3sum/

//Solution 1 ->  O(N ^3)

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        List<IList<int>> list = new List<IList<int>>();
        int targetSum = 0;
        for(int i =0; i< nums.Length-2; i++)
        {
            if(i > 0 && nums[i] == nums[i-1])
            {
                continue;
            }
            int firstNum = nums[i];
            for(int j = i+1; j< nums.Length-1;j++)
            {
                 if(j > i+1 && nums[j] == nums[j-1])
                {
                    continue;
                }
                int secondNum = nums[j];
                for(int k=j+1;k < nums.Length;k++)
                {
                    if(k > j+1 && nums[k] == nums[k-1])
                    {
                        continue;
                    }
                    int thirdNum = nums[k];
                    if(firstNum + secondNum +thirdNum == targetSum)
                    {
                        
                        list.Add(new List<int>(){firstNum,secondNum,thirdNum});
                    }
                }
            }
            
        }
        
        return list;
    }
}

//Solution 2 ->  O(N ^2)

public class Solution {
	public IList < IList < int >> ThreeSum(int[] array) {

		Array.Sort(array);
		var triplets = new List < IList < int >> ();

		for (int i = 0; i < array.Length - 2; i++) {
			if (array[i] > 0) break;

			if (i > 0 && array[i] == array[i - 1]) {
				continue;
			}
			int left = i + 1;
			int right = array.Length - 1;
			int target = 0 - array[i];
			while (left < right) {
				int currentSum = array[left] + array[right];
				if (currentSum < target) {
					left++;
				}
				else if (currentSum > target) {
					right--;
				}
				else {
					var newTriplet = new List < int > {array[i], array[left],array[right]};
					triplets.Add(newTriplet);
					
					while (left < right && array[left] == array[left + 1]) {
						left++;
					}					
					while (left < right && array[right] == array[right - 1]) {
						right--;
					}					
					left++;
					right--;
				}

			}

		}

		return triplets;
	}
}
