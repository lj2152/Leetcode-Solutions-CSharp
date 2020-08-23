//https://leetcode.com/problems/reformat-date/

    public string ReformatDate(string date) {
        
       var splitDate = date.Split(' ');
       var reformatted = new StringBuilder();
        
        var monthDict = new Dictionary<string,string>(){ {"Jan","01"},{"Feb","02"},{"Mar","03"},{"Apr","04"},{"May","05"},{"Jun","06"},{"Jul","07"},{"Aug","08"},{"Sep","09"},{"Oct","10"},{"Nov","11"},{"Dec","12"}};
        
	//year
        var year = splitDate[2];
        reformatted.Append(year);
        reformatted.Append("-");
		
	//month
        var monthString = splitDate[1];
        reformatted.Append(monthDict[monthString]);
        reformatted.Append("-");
        
	//day
        var dayString = splitDate[0];
        var lengthOfDayWithoutSuffix = dayString.Length-2;     
		
	reformatted.Append(lengthOfDayWithoutSuffix < 2 ? "0" : "");
        
        for(int i = 0; i< lengthOfDayWithoutSuffix;i++)
        {
             reformatted.Append(dayString[i]);
        }       
        
        return reformatted.ToString();      
        
    }
