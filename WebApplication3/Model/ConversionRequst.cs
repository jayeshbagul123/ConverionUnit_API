namespace WebApplication3.Model
{
    public class ConversionRequst
    {
        public double Value { get; set; }

        public string Category { get; set; } = string.Empty;

        public string FromUnit { get; set; } = string.Empty;

        public string ToUnit { get; set; } = string.Empty;
    }
}
