using UnityConverter.Application.Interface;
using UnityConverter.Domain.Entities;
using UnityConverter.Domain.Enum;
using UnityConverter.Domain.Interfaces;

namespace UnityConverter.Application.Service
{
    public class ConversionService : IConversionService
    {
        private readonly IUnitConverter _unitConverter;

        public ConversionService(IUnitConverter unitConverter)
        {
            _unitConverter = unitConverter;
        }

        public double Convert(double value,int unitType, int fromUnit, int toUnit)
        {
            var result = new ConversionResult();

            if (fromUnit == toUnit)
            {
                return value;
            }

            if (value <= 0)
            {
                throw new ArgumentException("Value must be higher then 0.");
            }

            try
            {
                switch (unitType)
                {
                    case 0://Distance
                        return _unitConverter.Convert(value, (Units.Distance)fromUnit, (Units.Distance)toUnit).Result;
                    case 1://Weight
                        return _unitConverter.Convert(value, (Units.Weight)fromUnit, (Units.Weight)toUnit).Result;
                    case 2://Temperature
                        return _unitConverter.Convert(value, (Units.Temperature)fromUnit, (Units.Temperature)toUnit).Result;
                    case 3://Volume
                        return _unitConverter.Convert(value, (Units.Volume)fromUnit, (Units.Volume)toUnit).Result;
                    default:
                        throw new ArgumentException("Invalid unit type");
                }               
                 
            }
            catch (Exception ex)
            {

                throw new Exception("Error while converting: " + ex.Message);
            }
        }
    }
}
