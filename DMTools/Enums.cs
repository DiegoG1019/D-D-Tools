namespace DnDTDesktop
{
    public enum Stats
    {
        strength, constitution, dexterity, wisdom, intelligence, charisma
    } //Is it possible to dynamically initialize an enum? Maybe I just need a new object type

    public enum Other
    {
        speed, initiative
    }

    public enum SavingThrows
    {
        fortitude, reflexes, will
    }

    public enum Schools
    {
        abjuration, divination, conjuration, enchantment, evocation, illusion, necromancy, transmutation
    } //Perhaps all of these should be a configurations option?

    public enum Sizes
    {
        Fine, Diminutive, Tiny, Small, Medium, Large, Huge, Gargantuan, Colossal
    }

}
