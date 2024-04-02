using System;

public class MoneyConverter
{
    public static string ConvertToText(int money)
    {
        float result = money;

        if (money >= 1_000 && money < 1_000_000)
        {
            return $"{Math.Round(result / 1_000, 1)}K";
        }
        else if (money >= 1_000_000 && money < 1_000_000_000)
        {
            return $"{Math.Round(result / 1_000_000, 2)}M";
        }
        else if (money >= 1_000_000_000)
        {
            return $"{Math.Round(result / 1_000_000_000, 3)}B";
        }

        return result.ToString();
    }
}
