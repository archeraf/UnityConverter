using UnityConverter.Application.Interface;
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

        public double Convert(double value, string fromUnit, string toUnit)
        {

            if (fromUnit.GetType() != toUnit.GetType())
            {
                throw new ArgumentException("Unity must be the same.");
            }

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

                var result = _unitConverter.Convert(value, fromUnit, toUnit);
            }
            catch (Exception ex)
            {

                throw new Exception("Error while converting: " + ex.Message);
            }

            return value;
        }
    }
}
