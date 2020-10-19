﻿using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.GUI.Elements.Components;
using DiegoG.DnDTDesktop.Other;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class BigHealthCard : CharacterUserControl
    {
        public Health HeldHealth => HeldCharacter.Health;
        public IHistoried NonLethalHistory => NonLethalDamageHistory.HeldHistory;
        public IHistoried LethalHistory => LethalDamageHistory.HeldHistory;
        public BigHealthCard()
        {
            InitializeComponent();
            NonLethalDamageHistory.LabeledNumericAddition.CommitButtonClicked += NonLethalHistoryCommitButton_Click;
            LethalDamageHistory.LabeledNumericAddition.CommitButtonClicked += LethalHistoryCommitButton_Click;
        }

        private void LethalHistoryCommitButton_Click(object sender, LabeledNumericBoxEventArgs e) => HeldHealth.LethalDamage.Damage += e.HeldValue;
        private void NonLethalHistoryCommitButton_Click(object sender, LabeledNumericBoxEventArgs e) => HeldHealth.NonlethalDamage.Damage += e.HeldValue;
        protected override void CharacterUserControl_HeldCharacterChanged()
        {
            NonLethalDamageHistory.HeldHistory = HeldHealth.NonlethalDamage;
            LethalDamageHistory.HeldHistory = HeldHealth.LethalDamage;
            NonLethalHPTextBox.TextBoxText = HeldHealth.NonLethalHP.ToString();
            RemainingHPTextBox.TextBoxText = HeldHealth.RemainingHP.ToString();
            BaseHealthTextBox.TextBoxText = HeldHealth.BaseHP.ToString();
            EffectHealthTextBox.TextBoxText = HeldHealth.EffectHP.ToString();
            TouchACTextBox.TextBoxText = HeldCharacter.ArmorClass.TouchAC.ToString();
            UnawareACTextBox.TextBoxText = HeldCharacter.ArmorClass.UnawareAC.ToString();
            ACTextBox.TextBoxText = HeldCharacter.ArmorClass.AC.ToString();
            StatusTextBox.TextBoxText = Convert.ToString(HeldHealth.State);
        }

        public void RefreshAllBoards()
        {
            NonLethalDamageHistory.RefreshBoard();
            LethalDamageHistory.RefreshBoard();
        }

        private void BigHealthCard_Load(object sender, EventArgs e)
        {

        }

        private void LethalDamageHistory_Load(object sender, EventArgs e)
        {

        }

        private void NonLethalDamageHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
