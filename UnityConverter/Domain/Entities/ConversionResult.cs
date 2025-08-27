namespace UnityConverter.Domain.Entities
{
    public class ConversionResult
    {
        public double Result { get; set; }
        public System.Enum FromUnit { get; set; }
        public System.Enum ToUnit { get; set; }
    }
}
