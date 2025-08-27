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
            if (fromUnit is DistanceUnit fromDistance && toUnit is DistanceUnit toDistance)
            {
                return ConvertDistance(value, fromDistance, toDistance);
            }
            else if (fromUnit is WeightUnit fromWeight && toUnit is WeightUnit toWeight)
            {
                return ConvertWeight(value, fromWeight, toWeight);
            }
            else if (fromUnit is TempUnit fromTemp && toUnit is TempUnit toTemp)
            {
                return ConvertTemperature(value, fromTemp, toTemp);
            }
            else
            {
                throw new ArgumentException("Invalid unit types");
            }
        }

        private ConversionResult ConvertTemperature(double value, TempUnit fromTemp, TempUnit toTemp)
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
                {(TempUnit.Celsius, TempUnit.Fahrenheit), v => (v * 9 / 5) + 32 },
                {(TempUnit.Celsius, TempUnit.Kelvin), v => v + 273.15 },
                {(TempUnit.Fahrenheit, TempUnit.Celsius), v => (v - 32) * 5 / 9 },
                {(TempUnit.Fahrenheit, TempUnit.Kelvin), v => (v - 32) * 5 / 9 + 273.15 },
                {(TempUnit.Kelvin, TempUnit.Celsius), v => v - 273.15 },
                {(TempUnit.Kelvin, TempUnit.Fahrenheit), v => (v - 273.15) * 9 / 5 + 32}

            };

            return new ConversionResult
            {
                Result = convert[(fromTemp, toTemp)](value),
                FromUnit = fromTemp,
                ToUnit = toTemp
            };


        }

        private ConversionResult ConvertWeight(double value, WeightUnit fromWeight, WeightUnit toWeight)
        {
            if(fromWeight == toWeight)
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
                { (WeightUnit.Kilogram, WeightUnit.Gram), v => v * 1000 },
                { (WeightUnit.Kilogram, WeightUnit.Pound), v => v * 2.20462 },
                { (WeightUnit.Kilogram, WeightUnit.Ounce), v => v * 35.274 },
                { (WeightUnit.Kilogram, WeightUnit.Ton), v => v / 907.185 },
                { (WeightUnit.Gram, WeightUnit.Kilogram), v => v / 1000 },
                { (WeightUnit.Gram, WeightUnit.Pound), v => v / 453.592 },
                { (WeightUnit.Gram, WeightUnit.Ounce), v => v / 28.3495 },
                { (WeightUnit.Gram, WeightUnit.Ton), v => v / 907185 },
                { (WeightUnit.Pound, WeightUnit.Kilogram), v => v / 2.20462 },
                { (WeightUnit.Pound, WeightUnit.Gram), v => v * 453.592 },
                { (WeightUnit.Pound, WeightUnit.Ounce), v => v * 16 },
                { (WeightUnit.Pound, WeightUnit.Ton), v => v / 2000 },
                { (WeightUnit.Ounce, WeightUnit.Kilogram), v => v / 35.274 },
                { (WeightUnit.Ounce, WeightUnit.Gram), v => v * 28.3495 },
                { (WeightUnit.Ounce, WeightUnit.Pound), v => v / 16},
                { (WeightUnit.Ounce, WeightUnit.Ton), v => v / 32000 },
                { (WeightUnit.Ton, WeightUnit.Kilogram), v => v * 907.185 },
                { (WeightUnit.Ton, WeightUnit.Gram), v => v * 907185 },
                { (WeightUnit.Ton, WeightUnit.Pound), v => v * 2000 },
                { (WeightUnit.Ton, WeightUnit.Ounce), v => v * 32000 }
                };

            return new ConversionResult
            {
                Result = convert[(fromWeight, toWeight)](value),
                FromUnit = fromWeight,
                ToUnit = toWeight
            };
        }

        private ConversionResult ConvertDistance(double value, DistanceUnit fromDistance, DistanceUnit toDistance)
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

                { (DistanceUnit.Meter, DistanceUnit.Kilometer), v => v / 1000 },
                { (DistanceUnit.Meter, DistanceUnit.Centimeter), v => v * 100 },
                { (DistanceUnit.Meter, DistanceUnit.Millimeter), v => v * 1000 },
                { (DistanceUnit.Meter, DistanceUnit.Mile), v => v / 1609.34 },
                { (DistanceUnit.Meter, DistanceUnit.Yard), v => v * 1.09361 },
                { (DistanceUnit.Meter, DistanceUnit.Foot), v => v * 3.28084 },
                { (DistanceUnit.Meter, DistanceUnit.Inch), v => v * 39.3701 },
                { (DistanceUnit.Kilometer, DistanceUnit.Meter), v => v * 1000 },
                { (DistanceUnit.Kilometer, DistanceUnit.Centimeter), v => v * 100000 },
                { (DistanceUnit.Kilometer, DistanceUnit.Millimeter), v => v * 1_000_000 },
                { (DistanceUnit.Kilometer, DistanceUnit.Mile), v => v / 1.60934 },
                { (DistanceUnit.Kilometer, DistanceUnit.Yard), v => v * 1093.61 },
                { (DistanceUnit.Kilometer, DistanceUnit.Foot), v => v * 3280.84 },
                { (DistanceUnit.Kilometer, DistanceUnit.Inch), v => v * 39370.1 },
                { (DistanceUnit.Centimeter, DistanceUnit.Meter), v => v / 100 },
                { (DistanceUnit.Centimeter, DistanceUnit.Kilometer), v => v / 100000 },
                { (DistanceUnit.Centimeter, DistanceUnit.Millimeter), v => v * 10 },
                { (DistanceUnit.Centimeter, DistanceUnit.Mile), v => v / 160934 },
                { (DistanceUnit.Centimeter, DistanceUnit.Yard), v => v / 91.44 },
                { (DistanceUnit.Centimeter, DistanceUnit.Foot), v => v / 30.48 },
                { (DistanceUnit.Centimeter, DistanceUnit.Inch), v => v / 2.54 },
                { (DistanceUnit.Millimeter, DistanceUnit.Meter), v => v / 1000 },
                { (DistanceUnit.Millimeter, DistanceUnit.Kilometer), v => v / 1_000_000 },
                { (DistanceUnit.Millimeter, DistanceUnit.Centimeter), v => v / 10 },
                { (DistanceUnit.Millimeter, DistanceUnit.Mile), v => v / 1_609_340 },
                { (DistanceUnit.Millimeter, DistanceUnit.Yard), v => v / 914.4 },
                { (DistanceUnit.Millimeter, DistanceUnit.Foot), v => v / 304.8 },
                { (DistanceUnit.Millimeter, DistanceUnit.Inch), v => v / 25.4 },
                { (DistanceUnit.Mile, DistanceUnit.Meter), v => v * 1609.34 },
                { (DistanceUnit.Mile, DistanceUnit.Kilometer), v => v * 1.60934 },
                { (DistanceUnit.Mile, DistanceUnit.Centimeter), v => v * 160934 },
                { (DistanceUnit.Mile, DistanceUnit.Millimeter), v => v * 1_609_340 },
                { (DistanceUnit.Mile, DistanceUnit.Yard), v => v * 1760 },
                { (DistanceUnit.Mile, DistanceUnit.Foot), v => v * 5280 },
                { (DistanceUnit.Mile, DistanceUnit.Inch), v => v * 63360 },
                { (DistanceUnit.Yard, DistanceUnit.Meter), v => v / 1.09361 },
                { (DistanceUnit.Yard, DistanceUnit.Kilometer), v => v / 1093.61 },
                { (DistanceUnit.Yard, DistanceUnit.Centimeter), v => v * 91.44 },
                { (DistanceUnit.Yard, DistanceUnit.Millimeter), v => v * 914.4 },
                { (DistanceUnit.Yard, DistanceUnit.Mile), v => v / 1760 },
                { (DistanceUnit.Yard, DistanceUnit.Foot), v => v * 3 },
                { (DistanceUnit.Yard, DistanceUnit.Inch), v => v * 36 },
                { (DistanceUnit.Foot, DistanceUnit.Meter), v => v / 3.28084 },
                {(DistanceUnit.Foot, DistanceUnit.Kilometer), v => v / 3280 }        
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
