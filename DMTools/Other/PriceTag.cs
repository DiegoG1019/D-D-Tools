using DiegoG.DnDTDesktop.Properties;
using DiegoG.Utilities;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDTDesktop.Other
{
    [Serializable]
    public struct PriceTag
    {
        public int NumericalValue;

        public void Add(int v) => NumericalValue += v;

        public void Sub(int v) => NumericalValue -= v;
        public PriceTag(int price) : this() => NumericalValue = price; 

        ///And finally, here's the reason I made this in the first place
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public string Value
        {
            get => $"{NumericalValue}{Resources.Currency}";
            set => NumericalValue = int.Parse(value.Split(new string[] { Resources.Currency }, StringSplitOptions.RemoveEmptyEntries)[1]);
        }
    }
}
