namespace WebApplication3.Service
{
    public interface IConversionService
    {
        double Convert(
             double value,
             string category,
             string fromUnit,
             string toUnit);
    }
}
