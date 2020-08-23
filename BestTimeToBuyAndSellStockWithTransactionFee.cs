//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/ 

public int MaxProfit(int[] prices, int fee) {
        int cash = 0;
        int holding = -prices[0];
        for (int i = 1; i < prices.Length; i++) {
            holding = Math.Max(holding, cash - prices[i]);
            cash = Math.Max(cash, holding + prices[i] - fee);
        }
        
        return cash;
    }