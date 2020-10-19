using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiegoG.DnDTDesktop.Other;
using System.Collections.Specialized;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using System.Linq;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class HistoryBoard : UserControl
    {
        private IHistoried _hh;
        /// <summary>
        /// Refreshes and updates its own subscriptions when set
        /// </summary>
        public IHistoried HeldHistory
        {
            get => _hh;
            set
            {
                if (ReferenceEquals(_hh, value))
                    return;
                if (_hh != null)
                    HeldHistory.History.CollectionChanged -= History_CollectionChanged;
                _hh = value;
                HeldHistory.History.CollectionChanged += History_CollectionChanged;
                RefreshBoard();
            }
        }

        /// <summary>
        /// Set this to true to enable the object to directly add the value to the history when the button is pressed
        /// </summary>
        public bool AutoAddToHistory { get; set; }
        public bool AutoRefreshValue { get; set; }

        private string TotalValueUnsafe
        {
            get => CurrentValueLabeledTextBox.TextBoxText;
            set => CurrentValueLabeledTextBox.TextBoxText = value;
        }

        public string NumericLabelText
        {
            get => LabeledNumericAddition.LabelText;
            set => LabeledNumericAddition.LabelText = value;
        }
        public string TextBoxLabelText
        {
            get => CurrentValueLabeledTextBox.LabelText;
            set => CurrentValueLabeledTextBox.LabelText = value;
        }

        public string TotalValue
        {
            get => TotalValueUnsafe;
#if !DESIGN
            set => Invoke(_setValue, this, value);
#endif
        }

        private static readonly Dictionary<NotifyCollectionChangedAction, Action<NotifyCollectionChangedEventArgs, HistoryBoard>> ChangedReactions
            = new Dictionary<NotifyCollectionChangedAction, Action<NotifyCollectionChangedEventArgs, HistoryBoard>>()
            {
                {
                    NotifyCollectionChangedAction.Add, (e,obj) =>
                    {
                        foreach(var i in e.NewItems)
                            obj.Items.Add(MainMenu.TextBoxGen(i.ToString()));
                    }
                },
                { NotifyCollectionChangedAction.Remove, (e,obj) => obj.RefreshBoard() },
                { NotifyCollectionChangedAction.Reset, (e,obj) => obj.Items.Clear() },
                { NotifyCollectionChangedAction.Move, (e,obj) => obj.RefreshBoard() },
                { NotifyCollectionChangedAction.Replace, (e,obj) => obj.RefreshBoard() }
            };
        private static readonly Action<HistoryBoard> _refreshBoard
            = new Action<HistoryBoard>(
                 obj =>
                 {
                     obj.Items.Clear();
                     foreach (var item in obj.HeldHistory.History)
                         obj.Items.Add(MainMenu.TextBoxGen(item.ToString()));
                     _refreshValue(obj);
                 }
             );
        private static readonly Action<HistoryBoard> _refreshValue
            = new Action<HistoryBoard>(
                obj =>
                {
                    obj.TotalValueUnsafe = obj.HeldHistory.History.Sum().ToString();
                }
              );
        private static readonly Action<HistoryBoard, int> _setValue
            = new Action<HistoryBoard, int>(
                (obj, i) =>
                {
                    obj.TotalValueUnsafe = i.ToString();
                }
            );

        public HistoryBoard()
        {
            InitializeComponent();
            LabeledNumericAddition.Numeric.KeyUp += Numeric_KeyUp;
            LabeledNumericAddition.CommitButton.Click += CommitButton_Click;
            AttemptedRefreshValue += delegate { };
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            if(AutoAddToHistory)
                HeldHistory.History.Add((int)LabeledNumericAddition.Numeric.Value);
        }

        private void Numeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Enter | Keys.Return))
                CommitButton_Click(sender, e);
        }

        private void History_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Invoke(ChangedReactions[e.Action], e, this);
            RefreshValue();
        }
        public void RefreshBoard() => Invoke(_refreshBoard, this);

        public event Action AttemptedRefreshValue;
        public void RefreshValue()
        {
            if (AutoRefreshValue)
                Invoke(_refreshValue, this);
            AttemptedRefreshValue();
        }

        public TableLayoutControlCollection Items => Board.Controls;
        public string Title
        {
            get => HistoryNameLabel.Text;
            set => HistoryNameLabel.Text = value;
        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LabeledNumericAddition_Load(object sender, EventArgs e)
        {
            LabeledNumericAddition.Numeric.Minimum = int.MinValue;
            LabeledNumericAddition.Numeric.Maximum = int.MaxValue;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
