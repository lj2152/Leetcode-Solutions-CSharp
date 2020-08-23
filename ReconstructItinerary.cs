//https://leetcode.com/problems/reconstruct-itinerary/


  public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var finalList = new List<string>();
            if (tickets == null || tickets.Count() == 0)
            {
                return finalList;
            }
            var ticketsDictionary = new Dictionary<string,List<string>>();

            for (int i = 0; i < tickets.Count(); i++)
            {
                var currentAirport = tickets[i][0];
                var connectingAirport = tickets[i][1];

                if (!ticketsDictionary.ContainsKey(currentAirport))
                {
                    ticketsDictionary.Add(currentAirport, new List<string>() { connectingAirport });
                }
                else
                {
                    ticketsDictionary[currentAirport].Add(connectingAirport);
                }
            }
            foreach(List<string> connectingAirportsList in ticketsDictionary.Values)
            {
                connectingAirportsList.Sort();
            }

            var airportsStack = new Stack<string>();
            airportsStack.Push("JFK");

            while(airportsStack.Count != 0)
            {
                while (ticketsDictionary.ContainsKey(airportsStack.Peek()) && ticketsDictionary[airportsStack.Peek()].Count() != 0)
                {
                    var firstConnectingAirport = ticketsDictionary[airportsStack.Peek()][0];
                    ticketsDictionary[airportsStack.Peek()].Remove(firstConnectingAirport);
                    airportsStack.Push(firstConnectingAirport);
                }

                finalList.Insert(0, airportsStack.Pop());
            }
           
            
            return finalList;
        }
		