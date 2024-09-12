var billings = new List<decimal> { 1500, 2300, 1200, 1700, 3000, 0, 0, 2000, 0 };

var result = new BillingResult(billings);


Console.WriteLine($"Menor faturamento: {result.Lower}");
Console.WriteLine($"Maior faturamento: {result.Higher}");
Console.WriteLine($"Quantidade de dias com faturamento acima da média: {result.QuantityDaysGreaterAverage}");

public class BillingResult
{
    public decimal Lower { get; set; }
    public decimal Higher { get; set; }
    public int QuantityDaysGreaterAverage { get; set; }

    private List<decimal> Billings = new List<decimal>();

    public BillingResult(List<decimal> billings)
    {
        Billings = billings;

        if (Billings.Count == 0) throw new Exception("Sem dados para calcular");
        CalculateBillings();
    }

    private void CalculateBillings()
    {
        decimal lessBilling = int.MaxValue;
        decimal greaterBilling = int.MinValue;

        decimal sumBillings = 0;
        int quantityBilling = 0;

        for (int i = 0; i < this.Billings.Count; i++)
        {
            decimal billing = this.Billings[i];

            if (billing <= 0) continue;

            sumBillings += billing;
            quantityBilling++;

            if (billing < lessBilling)
                lessBilling = billing;

            if (billing > greaterBilling)
                greaterBilling = billing;
        }

        decimal billingAverage = sumBillings / quantityBilling;
        
        int aboveAverageDays = 0;

        for (int i = 0; i < this.Billings.Count; i++)
        {
            if (this.Billings[i] > billingAverage)
                aboveAverageDays++;
        }

        Lower = lessBilling;
        Higher = greaterBilling;
        QuantityDaysGreaterAverage = aboveAverageDays;
    }
}
