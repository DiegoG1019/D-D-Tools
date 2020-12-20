using DiegoG.DnDTools.Base.Items.Info;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.Measures;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DiegoG.DnDTools.Base.Items
{
    public class Liquid : IItem
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string Name { get => NameField; set { NameField = value; NotifyPropertyChanged(); } }
        private string NameField;
        public string Description { get => DescriptionField; set { DescriptionField = value; NotifyPropertyChanged(); } }
        private string DescriptionField;
        public NoteList Notes { get => NotesField; set { NotesField = value; NotifyPropertyChanged(); } }
        private NoteList NotesField = new();

        /// <summary>
        /// Value of current amount
        /// </summary>
        public PriceTag Value
        {
            get => new((int)(LiterValue.NumericalValue * Amount.Liter));
            set
            {
                LiterValue = new((int)(Amount.NotZero ? value.NumericalValue / Amount.Liter : throw new InvalidOperationException("Can't assign a current amount value to no amount")));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Value of 1Lt
        /// </summary>
        public PriceTag LiterValue { get => LiterValueField; set { LiterValueField = value; NotifyPropertyChanged(); } }
        private PriceTag LiterValueField;
        public ObservableCollection<Effect> Effects
        {
            get => EffectsField;
            set
            {
                Effects.CollectionChanged -= Effects_CollectionChanged;
                EffectsField = value;
                Effects.CollectionChanged += Effects_CollectionChanged;
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<Effect> EffectsField = new ObservableCollection<Effect>();
        /// <summary>
        /// Defaults to 0, ignorable
        /// </summary>
        public Density Density { get => DensityField; set { DensityField = value; NotifyPropertyChanged(); } }
        private Density DensityField = new(0);
        public Volume Amount { get => AmountField; set { AmountField = value; NotifyPropertyChanged(); } }
        private Volume AmountField;
        public Liquid() { }
        public Liquid(NameDesc nameDesc) : this()
        {
            Name = nameDesc.Name;
            Description = nameDesc.Description;
            Notes = nameDesc.Notes;
            Effects.CollectionChanged += Effects_CollectionChanged;
        }

        private void Effects_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            => NotifyPropertyChanged(nameof(EffectsField));
    }
}
