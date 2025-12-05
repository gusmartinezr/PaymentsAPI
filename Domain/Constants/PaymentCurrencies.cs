namespace Domain.Constants;

public static class PaymentCurrencies
{
    public const string Boliviano = "BOB";
    public const string UsDollar = "USD";

    public const string CodeBoliviano = "0";
    public const string CodeUsDollar = "1";

    public static readonly HashSet<string> Allowed = new(StringComparer.OrdinalIgnoreCase)
    {
        Boliviano,
        UsDollar,
        CodeBoliviano,
        CodeUsDollar
    };
}