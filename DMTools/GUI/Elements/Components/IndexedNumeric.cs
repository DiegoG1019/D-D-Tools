using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements.Components
{
    public class IndexedNumeric : NumericUpDown, IDisposable
    {
        public new void Dispose()
        {
            HeldList = null;
            base.Dispose();
        }
        public new void Dispose(bool disposing)
        {
            HeldList = null;
            base.Dispose(disposing);
        }
        public int Index { get; set; }
        public IList<int> HeldList { get; set; }
        public new int Value
        {
            get => (int)base.Value;
            set => base.Value = value;
        }
        public IndexedNumeric()
        {
            ValueChanged += IndexedNumeric_ValueChanged;
            Maximum = int.MaxValue;
            Minimum = int.MinValue;
        }
        private void IndexedNumeric_ValueChanged(object sender, EventArgs e) => HeldList[Index] = Value;
    }
}