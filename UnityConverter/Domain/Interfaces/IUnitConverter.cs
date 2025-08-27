using UnityConverter.Domain.Entities;

namespace UnityConverter.Domain.Interfaces
{
    public interface IUnitConverter
    {
        ConversionResult Convert(double value, System.Enum fromUnit, System.Enum toUnit);
    }
}
