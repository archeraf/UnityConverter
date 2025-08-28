namespace UnityConverter.Application.Interface
{
    public interface IConversionService
    {
        public double Convert(double value,int unitType, int fromUnit, int toUnit);
    }
}
