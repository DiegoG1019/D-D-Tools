using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.Measures;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Base
{
    public class ItemLang : ISettings
    {
        public ulong Version => 0;
        public WeaponsAndArmorLang WeaponsAndArmor { get; set; } = new();
        public class WeaponsAndArmorLang
        {
            public string ArmorText { get; set; } = "Armor";
            public string WeaponText { get; set; } = "Weapon";
            public string MeleeWeaponText { get; set; } = "Melee Weapon";
            public string RangedWeaponText { get; set; } = "Ranged Weapon";
            public string AmmunitionText { get; set; } = "Ammunition";
            public string ItemText { get; set; } = "Item";
            public NameDesc LeatherArmor { get; set; } = new("Leather Armor", "A normal, well-made leather armor, offering a good amount of protection for relatively free movement.");
            public NameDesc CrossbowBolt { get; set; } = new("Crossbow Bolts", "A common, well-made bolt used for crossbows");
            public NameDesc ThrowingKnife { get; set; } = new("Throwing Knife", "A common, well-made small knife made for throwing");
            public NameDesc SpikedGauntlet { get; set; } = new("Spiked Gauntlet", "A metal gauntlet, fitted with metal spikes to pierce your enemies", new() { "Your opponent cannot disarm you of the gauntlet", "An attack with this gauntlet is considered an armed attack", "Price and Weight are for a single gauntlet, not a pair", "Despite being labeled as a Two Handed weapon, the user can hold other things with their hands, but as with other armored gauntlets, receives a -2 to dexterity checks that are not attacks" });
            public NameDesc Club { get; set; } = new("Club", "A simple club made of wood. Good for smashing things.");

        }

        //Feats & Abilities
        public FeatsAndAbilitiesLang FeatsAndAbilities { get; set; } = new();
        public class FeatsAndAbilitiesLang
        {
            public NameDesc WeaponFinesse { get; set; } = new("Weapon Finesse", "With a light weapon, rapier, whip, or spiked chain made for a creature of your size category, you may use your Dexterity modifier instead of your Strength modifier on attack rolls. If you carry a shield, its armor check penalty applies to your attack rolls.");
            public NameDesc EfficientStrike { get; set; } = new("Efficient Strike", "Able to stack Sneak Attack to Critical Hits");
        }

        public ItemsLang Items { get; set; } = new();
        public class ItemsLang
        {
            public NameDesc Caltrops { get; set; } = new(
                "Bag of Caltrops",
                "A four-pronged iron spike crafted so that one prong faces up no matter how the caltrop comes to rest. Scatter them around in the hope of damaging or slowing down an incoming, ground borne enemy",
                new()
                {
                    "One 2-pound bag of caltrops covers an area 5 feet square",
                    "Each time a creature moves into an area covered by caltrops or spends a round fighting in such an area, it might step on one",
                    "The caltrops make an attack roll (base attack bonus +0) against the creature, ignoring the creature's shield, armor and deflection bonuses",
                    "Light footwear (such as foot wrappings) grant a +1 bonus to AC",
                    "Common footwear (such as travel boots) grant a +2 bonus to AC",
                    "Heavy duty footwear (such as armor or very thick boots grant a +4 bonus to AC",
                    "Caltrops deal 1 point of damage if the creature stepped on one (attack roll succesful), as well as wounds and reduces the creature's speed by half for 24 hours",
                    "Healing the creature requires a DC15 Heal check, or 1 point of magical curing (per caltrop)",
                    "Charging or running cannot be done after stepping on a caltrop, and stops when stepping on one",
                    "If a creature that has stepped on a caltrop insists on running or charging, its speed will be reduced by 2/3 (Down to 20 if 30) and will receive 1 point of damage for every 5' ran",
                    "Any creature moving at half speed can pick its way through a bed of caltrops with no trouble",
                    "Caltrops may not be effective against unusual opponents"
                }
            );
            public NameDesc Water { get; set; } = new("Water", "Plain Water");
            public NameDesc Candle { get; set; } = new("Candle", "Dimly illuminates a 5-foot radius and burns for 1 hour", new() { "May be used to light things on fire, but it could kill the candle's fire just as easily" });
            public NameDesc Crowbar { get; set; } = new("Crowbar", "Grants a +3 Circumstance bonus on Strength checks for relevant purposes. Also an effective metal club.");
            public NameDesc FlintSteel { get; set; } = new("Flint & Steel", "A tool for making sparks, with the purpose of lighting flammable things", new() { "Lightning a torch with this takes a Full Round Action, lightning any other flammable object or surface takes at least that long" });
            public NameDesc GrapplingHook { get; set; } = new("Grappling Hook", "Throw it to an object that can be hooked somehow, in order to climb the secured rope", new() { "Throwing a grappling hook successfully requires a Use Rope check (DC 10, +2 per 10 feet of distance thrown)." });
            public NameDesc Hammer { get; set; } = new("Hammer", "A tool for striking hard things");
            public NameDesc BlackInk { get; set; } = new("Black Ink", "Leaves a hard to remove stain on basically anything it comes to contact with. Good for writing stuff");
            public NameDesc ColoredInk { get; set; } = new("{Color} Ink", "Leaves a hard to remove, {Color} stain on basically anything it comes to contact with. Good for coloring paper, as well as writing on it");
            public NameDesc ClayJug { get; set; } = new("Clay Jug", "A basic ceramic jug fitted with a stopper, holds 1 Gallon of Liquid");
            public NameDesc CommonLamp { get; set; } = new("Lantern, Common", $"Clearly illuminates a {new Length(30, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} radius and provides shadowy illumination in a {new Length(30, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} radius. It burns for 6 hours on a pint of oil");
            public NameDesc BullseyeLantern { get; set; } = new("Lantern, Bullseye", $"Clearly illuminates a {new Length(60, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} cone and shadowy illumination in a {new Length(120, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} cone. It burns for 6 hours on a pint of oil");
            public NameDesc HoodedLantern { get; set; } = new("Lantern, Hooded", $"Clearly illuminates a {new Length(30, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} radius and provides shadowy illumination in a {new Length(60, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} radius. It burns for 6 hours on a pint of oil");
            public NameDesc Lock { get; set; } = new("Lock, {0}", "A Lock used for securing doors, chests, and related. This lock requires a Open Lock Skill Check of DC {0}");
            public NameDesc Oil { get; set; } = new("Oil", "A very flammable liquid used for lanterns and torches.", new() { $"You can use a flask of oil as a splash weaponm using the same rules as for Alchemist's fire, except that it takes a full round action to prepare a flask with a fuse. Once it is thrown, there is a 50% chance of the flask igniting succesfully.", "You can pour a pint of oil on the ground to cover an area {new Length(5, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} square, provided that the surface is smooth. If lit, the oil burns for 2 rounds and deals 1d3 points of fire damage to each creature in the area." });
            public NameDesc RamPortable { get; set; } = new("Ram, Portable", "This iron-shod wooden beam gives you a +2 circumstance bonus on Strength checks made to break open a door and it allows a second person to help you without having to roll, increasing your bonus by 2");
            public NameDesc RopeHempen { get; set; } = new("Rope, Hempen", "This rope has 2 hit points and can be burst with a DC 23 Strength check");
            public NameDesc RopeSilk { get; set; } = new("Rope, Silk", "This rope has 4 hit points and can be burst with a DC 24 Strength check. It is so supple that it provides a +2 circumstance bonus on Use Rope checks");
            public NameDesc Spyglass { get; set; } = new("Spyglass", "Objects viewed through a spyglass are magnified to twice their size");
            public NameDesc Torch { get; set; } = new("Torch", $"A torch burns for 1 hour, clearly illuminating a {new Length(20, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} radius and providing shadowy illumination out to a {new Length(40, Length.Units.Foot).ToString(Settings<DnDSettings>.Current.PreferredLengthUnit)} radius.");
            public NameDesc Vial { get; set; } = new("Vial", "A vial holds 1 ounce of liquid. The stoppered container usually is no more than 1 inch wide and 3 inches high");
        }
    }
}
