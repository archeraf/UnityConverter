using UnityConverter.Domain.Enum;

namespace UnityConverter.Model.Entities
{
    public class ConversionRequest
    {
        public double Value { get; set; }
        public Enum FromUnit { get; set; }
        public Enum ToUnit { get; set; }
        public double Result { get; set; }


        public ConversionRequest(float value, Enum fromUnit, Enum toUnit)
        {
            Value = value;
            FromUnit = fromUnit;
            ToUnit = toUnit;
        }

    }
}
