namespace DiegoG.DnDTDesktop.Characters.Complements
{
    public interface ICharacterProperty
    {
        int BasePoints { get; }
        int Bonus { get; }
        int EffectPoints { get; }
        int Total { get; }
    }
}
