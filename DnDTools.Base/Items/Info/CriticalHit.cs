namespace DiegoG.DnDTools.Base.Items.Info
{
    public record CriticalHit
    {
        public byte Minimum { get; init; }
        public byte Maximum { get; init; }
        public float Multiplier { get; init; }
        public string Value
        {
            get
            {
                if (Maximum != Minimum)
                    return $"{Minimum}-{Maximum}; x{Multiplier}";
                return $"{Minimum}; x{Multiplier}";
            }
        }

        public CriticalHit(CriticalHit other)
        {
            Minimum = other.Minimum;
            Maximum = other.Maximum;
            Multiplier = other.Multiplier;
        }
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
