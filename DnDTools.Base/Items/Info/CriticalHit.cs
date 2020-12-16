namespace DiegoG.DnDTools.Base.Items.Info
{
    public class CriticalHit
    {
        public byte Minimum { get; set; }
        public byte Maximum { get; set; }
        public float Multiplier { get; set; }
        public string Value
        {
            get
            {
                if (Maximum != Minimum)
                {
                    return $"{Minimum}-{Maximum}; x{Multiplier}";
                }
                return $"{Minimum}; x{Multiplier}";
            }
        }

        public CriticalHit(CriticalHit other) :
            this(other.Minimum, other.Multiplier, other.Maximum)
        { }
        public CriticalHit() :
            this(20, 2, 20)
        { }
        public CriticalHit(byte Min, float Mult, byte Max)
        {
            Minimum = Min;
            Maximum = Max;
            Multiplier = Mult;
        }
    }
}
