namespace NominaApp.Utils
{
    public abstract class Format
    {
        public string FormatMoney(double money) => $"RD{money.ToString("c")}";
    }
}