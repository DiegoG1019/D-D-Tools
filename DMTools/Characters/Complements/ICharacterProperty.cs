namespace DiegoG.DnDTDesktop.Characters.Complements
{
    public interface ICharacterProperty
    {
        int BasePoints { get; }
        int Bonus { get; }
        int EffectPoints { get; }
        int BaseTotal { get; }
        int Total { get; }
    }
}
