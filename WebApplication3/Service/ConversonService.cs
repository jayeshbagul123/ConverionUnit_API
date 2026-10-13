namespace WebApplication3.Service
{
    public class ConversonService: IConversionService
    {
        private record Unit(double Factor, double Offset = 0);

        private readonly Dictionary<string, Dictionary<string, Unit>>
            _units = new(StringComparer.OrdinalIgnoreCase)
            {
                ["length"] = new(
                    StringComparer.OrdinalIgnoreCase)
                {
                    ["meter"] = new(1),
                    ["kilometer"] = new(1000),
                    ["centimeter"] = new(0.01),
                    ["millimeter"] = new(0.001),
                    ["mile"] = new(1609.344),
                    ["foot"] = new(0.3048),
                    ["inch"] = new(0.0254)
                },

                ["weight"] = new(
                    StringComparer.OrdinalIgnoreCase)
                {
                    ["kilogram"] = new(1),
                    ["gram"] = new(0.001),
                    ["milligram"] = new(0.000001),
                    ["pound"] = new(0.45359237),
                    ["ounce"] = new(0.028349523125),
                    ["tonne"] = new(1000)
                },

                ["temperature"] = new(
                    StringComparer.OrdinalIgnoreCase)
                {
                    ["kelvin"] = new(1),
                    ["celsius"] = new(1, 273.15),
                    ["fahrenheit"] = new(
                        5.0 / 9.0,
                        273.15 - (32.0 * 5.0 / 9.0))
                }
            };

        public double Convert(
            double value,
            string category,
            string fromUnit,
            string toUnit)
        {
            if (!double.IsFinite(value))
            {
                throw new ArgumentException(
                    "Value must be a finite number.");
            }

            if (!_units.TryGetValue(category, out var categoryUnits))
            {
                throw new ArgumentException(
                    $"Unsupported category: {category}");
            }

            if (!categoryUnits.TryGetValue(fromUnit, out var from))
            {
                throw new ArgumentException(
                    $"Unsupported source unit: {fromUnit}");
            }

            if (!categoryUnits.TryGetValue(toUnit, out var to))
            {
                throw new ArgumentException(
                    $"Unsupported target unit: {toUnit}");
            }

            // Convert source unit to the base unit.
            double baseValue =
                value * from.Factor + from.Offset;

            // Convert the base unit to the target unit.
            double result =
                (baseValue - to.Offset) / to.Factor;

            if (!double.IsFinite(result))
            {
                throw new ArgumentException(
                    "Conversion result is outside the supported range.");
            }

            return result;
        }
    }
}
