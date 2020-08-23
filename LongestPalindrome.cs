//https://leetcode.com/problems/longest-palindromic-substring/

//Solution 1 -> O(N^3)

public string LongestPalindrome(string s) {
	if (IsPalindrome(s)) {
		return s;
	}
	for (int i = s.Length - 1; i > 1; i--) {
		for (int k = 0; k <= s.Length - i; k++) {
			string possiblePalindrome = s.Substring(k, i);

			if (IsPalindrome(possiblePalindrome)) {
				return possiblePalindrome;
			}
		}
	}
	return string.IsNullOrEmpty(s) ? s: s.First().ToString();
}

public bool IsPalindrome(string str) {
	int leftIdx = 0;
	int rightIdx = str.Length - 1;

	while (leftIdx < rightIdx) {
		if (str[leftIdx] != str[rightIdx]) {
			return false;
		}
		leftIdx++;
		rightIdx--;

	}
	return true;

}
	



//Solution -> O(N^2)


public string LongestPalindrome(string str) {	
	if (string.IsNullOrWhiteSpace(str))
	{
		return "";
	}
	
	int[] currentLongest = new int[] {0,1};
	
	for (int i = 1; i < str.Length; i++) {
		int[] oddPalindrome = getStartEndIdxOfLongestPalindrome(str, i - 1, i + 1);
		int[] evenPalindrome = getStartEndIdxOfLongestPalindrome(str, i - 1, i);

		int lengthOfOddPalindrome = oddPalindrome[1] - oddPalindrome[0];
		int lengthOfEvenPalindrome = evenPalindrome[1] - evenPalindrome[0];

		int[] newLongest = lengthOfOddPalindrome > lengthOfEvenPalindrome ? oddPalindrome: evenPalindrome;

		int lengthofNewPalindrome = newLongest[1] - newLongest[0];
		int lengthofCurrentPalindrome = currentLongest[1] - currentLongest[0];

		if (lengthofNewPalindrome > lengthofCurrentPalindrome) {
			currentLongest = newLongest;
		}
	}

	string longestPalindrome = str.Substring(currentLongest[0], currentLongest[1] - currentLongest[0]);

	return longestPalindrome;
}

public int[] getStartEndIdxOfLongestPalindrome(string str, int leftIdx, int rightIdx) {
	while (leftIdx >= 0 && rightIdx < str.Length && str[leftIdx] == str[rightIdx]) {
		leftIdx--;
		rightIdx++;
	}
	return new int[] {
		leftIdx + 1,
		rightIdx
	};
}


