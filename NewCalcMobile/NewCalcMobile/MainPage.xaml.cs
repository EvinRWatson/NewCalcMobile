using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewCalcMobile
{
    public partial class MainPage : ContentPage
    {
        #region Page Initialization
        public MainPage()
        {
            InitializeComponent();
            WeightEntry.Text = App.Weight.ToString();
            QuantityEntry.Text = App.Quantity.ToString();
            REFEntry.Text = App.REF.ToString();
            CurrentTotalNewLabel.Text = $"Current Total NEW: {App.TotalNEW}";
            ElementNumLabel.Text = $"Element #{App.numElements}";
        }

        private async void ShowTotals(object sender, EventArgs e)
        {
            setTotalNEW();
            await Navigation.PushAsync(new TotalsPage(), true);
        }
        #endregion

        #region Set Global Variables
        void SetWeight(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            App.Weight = setValueFromInput(((Entry)sender).Text);
        }

        void SetQuantity(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            App.Quantity = setValueFromInput(((Entry)sender).Text);
        }

        void SetREF(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            App.REF = setValueFromInput(((Entry)sender).Text);
        }

        void SwitchSetIsGrain(object sender, ToggledEventArgs e)
        {
            bool senderIsGrain = e.Value;
            App.isGrain = senderIsGrain;
        }

        #endregion

        #region Functions
        static void ResetInputVariables()
        {
            App.Weight = 0;
            App.Quantity = 0;
            App.REF = 0;
            App.CurrentNEW = 0;
            App.isGrain = false;
        }


        static void ResetTotalVariables()
        {
            App.numElements = 0;
            App.TotalNEW = 0;
        }

        async void AddElement(object sender, EventArgs e)
        {
            setTotalNEW();
            App.numElements++;
            ResetInputVariables();
            await Navigation.PushAsync(new MainPage(), true);
        }

        static double CalculateNEW()
        {
            App.CurrentNEW = App.Weight * App.Quantity * App.REF;
            if (App.isGrain == true)
                App.CurrentNEW /= 7000;
            return App.CurrentNEW;
        }

        static void setTotalNEW()
        {
            App.TotalNEW += CalculateNEW();
        }

        static double setValueFromInput(String input)
        {
            double output;
            try
            {
                output = double.Parse(input);
            }
            catch
            {
                output = 0;
            }

            return output;
        }

        #endregion
    }
}