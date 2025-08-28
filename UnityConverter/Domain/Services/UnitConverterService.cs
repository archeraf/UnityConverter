using UnityConverter.Domain.Entities;
using UnityConverter.Domain.Enum;
using UnityConverter.Domain.Interfaces;

namespace UnityConverter.Domain.Services
{
    public class UnitConverterService : IUnitConverter
    {
        public ConversionResult Convert(double value, System.Enum fromUnit, System.Enum toUnit)
        {
            if (fromUnit.GetType() != toUnit.GetType())
            {
                throw new ArgumentException("FromUnit and ToUnit must be of the same type.");
            }
            if (fromUnit is Units.Distance fromDistance && toUnit is Units.Distance toDistance)
            {
                return ConvertDistance(value, fromDistance, toDistance);
            }
            else if (fromUnit is Units.Weight fromWeight && toUnit is Units.Weight toWeight)
            {
                return ConvertWeight(value, fromWeight, toWeight);
            }
            else if (fromUnit is Units.Temperature fromTemp && toUnit is Units.Temperature toTemp)
            {
                return ConvertTemperature(value, fromTemp, toTemp);
            }
            else
            {
                throw new ArgumentException("Invalid unit types");
            }
        }

        private ConversionResult ConvertTemperature(double value, Units.Temperature fromTemp, Units.Temperature toTemp)
        {
            if (fromTemp == toTemp)
            {
                return new ConversionResult
                {
                    Result = value,
                    FromUnit = fromTemp,
                    ToUnit = toTemp
                };
            }

            var convert = new Dictionary<(System.Enum, System.Enum), Func<double, double>>
            {
                {(Units.Temperature.Celsius, Units.Temperature.Fahrenheit), v => (v * 9 / 5) + 32 },
                {(Units.Temperature.Celsius, Units.Temperature.Kelvin), v => v + 273.15 },
                {(Units.Temperature.Fahrenheit, Units.Temperature.Celsius), v => (v - 32) * 5 / 9 },
                {(Units.Temperature.Fahrenheit, Units.Temperature.Kelvin), v => (v - 32) * 5 / 9 + 273.15 },
                {(Units.Temperature.Kelvin, Units.Temperature.Celsius), v => v - 273.15 },
                {(Units.Temperature.Kelvin, Units.Temperature.Fahrenheit), v => (v - 273.15) * 9 / 5 + 32}

            };

            return new ConversionResult
            {
                Result = convert[(fromTemp, toTemp)](value),
                FromUnit = fromTemp,
                ToUnit = toTemp
            };


        }

        private ConversionResult ConvertWeight(double value, Units.Weight fromWeight, Units.Weight toWeight)
        {
            if (fromWeight == toWeight)
            {
                return new ConversionResult
                {
                    Result = value,
                    FromUnit = fromWeight,
                    ToUnit = toWeight
                };
            }

            var convert = new Dictionary<(System.Enum, System.Enum), Func<double, double>>
            {
                { (Units.Weight.Kilogram, Units.Weight.Gram), v => v * 1000 },
                { (Units.Weight.Kilogram, Units.Weight.Pound), v => v * 2.20462 },
                { (Units.Weight.Kilogram, Units.Weight.Ounce), v => v * 35.274 },
                { (Units.Weight.Kilogram, Units.Weight.Ton), v => v / 907.185 },
                { (Units.Weight.Gram, Units.Weight.Kilogram), v => v / 1000 },
                { (Units.Weight.Gram, Units.Weight.Pound), v => v / 453.592 },
                { (Units.Weight.Gram, Units.Weight.Ounce), v => v / 28.3495 },
                { (Units.Weight.Gram, Units.Weight.Ton), v => v / 907185 },
                { (Units.Weight.Pound, Units.Weight.Kilogram), v => v / 2.20462 },
                { (Units.Weight.Pound, Units.Weight.Gram), v => v * 453.592 },
                { (Units.Weight.Pound, Units.Weight.Ounce), v => v * 16 },
                { (Units.Weight.Pound, Units.Weight.Ton), v => v / 2000 },
                { (Units.Weight.Ounce, Units.Weight.Kilogram), v => v / 35.274 },
                { (Units.Weight.Ounce, Units.Weight.Gram), v => v * 28.3495 },
                { (Units.Weight.Ounce, Units.Weight.Pound), v => v / 16},
                { (Units.Weight.Ounce, Units.Weight.Ton), v => v / 32000 },
                { (Units.Weight.Ton, Units.Weight.Kilogram), v => v * 907.185 },
                { (Units.Weight.Ton, Units.Weight.Gram), v => v * 907185 },
                { (Units.Weight.Ton, Units.Weight.Pound), v => v * 2000 },
                { (Units.Weight.Ton, Units.Weight.Ounce), v => v * 32000 }

            };

            return new ConversionResult
            {
                Result = convert[(fromWeight, toWeight)](value),
                FromUnit = fromWeight,
                ToUnit = toWeight
            };
        }

        private ConversionResult ConvertDistance(double value, Units.Distance fromDistance, Units.Distance toDistance)
        {
            if (fromDistance == toDistance)
            {
                return new ConversionResult
                {
                    Result = value,
                    FromUnit = fromDistance,
                    ToUnit = toDistance
                };
            }

            var convert = new Dictionary<(System.Enum, System.Enum), Func<double, double>>
            {

                { (Units.Distance.Meter, Units.Distance.Kilometer), v => v / 1000 },
                { (Units.Distance.Meter, Units.Distance.Centimeter), v => v * 100 },
                { (Units.Distance.Meter, Units.Distance.Millimeter), v => v * 1000 },
                { (Units.Distance.Meter, Units.Distance.Mile), v => v / 1609.34 },
                { (Units.Distance.Meter, Units.Distance.Yard), v => v * 1.09361 },
                { (Units.Distance.Meter, Units.Distance.Foot), v => v * 3.28084 },
                { (Units.Distance.Meter, Units.Distance.Inch), v => v * 39.3701 },
                { (Units.Distance.Kilometer, Units.Distance.Meter), v => v * 1000 },
                { (Units.Distance.Kilometer, Units.Distance.Centimeter), v => v * 100000 },
                { (Units.Distance.Kilometer, Units.Distance.Millimeter), v => v * 1_000_000 },
                { (Units.Distance.Kilometer, Units.Distance.Mile), v => v / 1.60934 },
                { (Units.Distance.Kilometer, Units.Distance.Yard), v => v * 1093.61 },
                { (Units.Distance.Kilometer, Units.Distance.Foot), v => v * 3280.84 },
                { (Units.Distance.Kilometer, Units.Distance.Inch), v => v * 39370.1 },
                { (Units.Distance.Centimeter, Units.Distance.Meter), v => v / 100 },
                { (Units.Distance.Centimeter, Units.Distance.Kilometer), v => v / 100000 },
                { (Units.Distance.Centimeter, Units.Distance.Millimeter), v => v * 10 },
                { (Units.Distance.Centimeter, Units.Distance.Mile), v => v / 160934 },
                { (Units.Distance.Centimeter, Units.Distance.Yard), v => v / 91.44 },
                { (Units.Distance.Centimeter, Units.Distance.Foot), v => v / 30.48 },
                { (Units.Distance.Centimeter, Units.Distance.Inch), v => v / 2.54 },
                { (Units.Distance.Millimeter, Units.Distance.Meter), v => v / 1000 },
                { (Units.Distance.Millimeter, Units.Distance.Kilometer), v => v / 1_000_000 },
                { (Units.Distance.Millimeter, Units.Distance.Centimeter), v => v / 10 },
                { (Units.Distance.Millimeter, Units.Distance.Mile), v => v / 1_609_340 },
                { (Units.Distance.Millimeter, Units.Distance.Yard), v => v / 914.4 },
                { (Units.Distance.Millimeter, Units.Distance.Foot), v => v / 304.8 },
                { (Units.Distance.Millimeter, Units.Distance.Inch), v => v / 25.4 },
                { (Units.Distance.Mile, Units.Distance.Meter), v => v * 1609.34 },
                { (Units.Distance.Mile, Units.Distance.Kilometer), v => v * 1.60934 },
                { (Units.Distance.Mile, Units.Distance.Centimeter), v => v * 160934 },
                { (Units.Distance.Mile, Units.Distance.Millimeter), v => v * 1_609_340 },
                { (Units.Distance.Mile, Units.Distance.Yard), v => v * 1760 },
                { (Units.Distance.Mile, Units.Distance.Foot), v => v * 5280 },
                { (Units.Distance.Mile, Units.Distance.Inch), v => v * 63360 },
                { (Units.Distance.Yard, Units.Distance.Meter), v => v / 1.09361 },
                { (Units.Distance.Yard, Units.Distance.Kilometer), v => v / 1093.61 },
                { (Units.Distance.Yard, Units.Distance.Centimeter), v => v * 91.44 },
                { (Units.Distance.Yard, Units.Distance.Millimeter), v => v * 914.4 },
                { (Units.Distance.Yard, Units.Distance.Mile), v => v / 1760 },
                { (Units.Distance.Yard, Units.Distance.Foot), v => v * 3 },
                { (Units.Distance.Yard, Units.Distance.Inch), v => v * 36 },
                { (Units.Distance.Foot, Units.Distance.Meter), v => v / 3.28084 },
                {(Units.Distance.Foot, Units.Distance.Kilometer), v => v / 3280 }
            };

            return new ConversionResult
            {
                Result = convert[(fromDistance, toDistance)](value),
                FromUnit = fromDistance,
                ToUnit = toDistance
            };
        }
    }
}
