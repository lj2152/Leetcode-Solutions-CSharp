//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/

    public int MaxProfit(int[] prices) {
        
        if(prices.Length == 0)
        {
            return 0;
        }
        int firstBuy = Int32.MinValue;
        int secondBuy = Int32.MinValue;
        int firstSell = 0;
        int secondSell = 0;
        
        for(int tran =0; tran < prices.Length; tran++)
        {
            firstBuy = Math.Max(firstBuy, -prices[tran]);
            firstSell = Math.Max(firstSell, firstBuy + prices[tran] );
            secondBuy = Math.Max(secondBuy, firstSell - prices[tran]);
            secondSell = Math.Max(secondSell,secondBuy + prices[tran]);
        }
        
        return secondSell;
}