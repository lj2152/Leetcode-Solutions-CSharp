//https://leetcode.com/problems/text-justification/ 
	
	public IList<string> FullJustify(string[] words, int maxWidth) {
        
         var resultList = new List<string>();
            int totalNumberofWords = words.Length;
            int currentWordIndex = 0;

            while (currentWordIndex < totalNumberofWords)
            {
                int totalCharsOfCurrentLine = words[currentWordIndex].Length;
                int nextWordIndex = currentWordIndex + 1;

                //loop through until we reach the end of the words list...or see break below...
                while (nextWordIndex < totalNumberofWords)
                {
                    int lengthOfNextWord = words[nextWordIndex].Length;
					
					int lineLengthWithNextWord = totalCharsOfCurrentLine + 1 + lengthOfNextWord;
                    
                    //if we exceed the maxWidth, then break out of this while loop..
                    if (lineLengthWithNextWord > maxWidth)
                    {
                        break;
                    }
					//include the length of the next word into the totalCharsOfCurrentWord + the space.
					else
					{
						totalCharsOfCurrentLine = lineLengthWithNextWord;
					}
                    
                    nextWordIndex++;
                }

                int numberOfGapsBetweenWords = nextWordIndex - currentWordIndex - 1;
                var sb = new StringBuilder();

                //if last word...
                if (nextWordIndex == totalNumberofWords || numberOfGapsBetweenWords == 0)
                {
                    for (int i = currentWordIndex; i < nextWordIndex; i++)
                    {
                        sb.Append(words[i]);
                        sb.Append(' ');
                    }

                    //remove last space...
                   sb.Length--; 
                    while (sb.Length < maxWidth)
                    {
                        sb.Append(' ');
                    }
                }
                else
                {
                    int emptySpacesToBeFilled = maxWidth - totalCharsOfCurrentLine;
                    int equalSpacesThatCanBeFilled = emptySpacesToBeFilled / numberOfGapsBetweenWords; //gives equal number spaces for each gap....
                    int remainingSpacesToBeFilled = emptySpacesToBeFilled % numberOfGapsBetweenWords; //remainder gives us the rest that's left...
                    
                    int lastWordIdxOfCurrentLine = nextWordIndex - 1;

                    for (int i = currentWordIndex; i < lastWordIdxOfCurrentLine; i++)
                    {
                        sb.Append(words[i]);
                        sb.Append(' ');

                        for (int j = 0; j < equalSpacesThatCanBeFilled; j++)
                        {
                            sb.Append(' ');
                        }

                        if(remainingSpacesToBeFilled > 0)
                        {
                            sb.Append(' ');
                            remainingSpacesToBeFilled--;
                        }
                    }

                    sb.Append(words[lastWordIdxOfCurrentLine]);
                }

                resultList.Add(sb.ToString());
                currentWordIndex = nextWordIndex;
            }

            return resultList;
        }