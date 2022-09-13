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
            string senderWeight = ((Entry)sender).Text;
            if (senderWeight == null || senderWeight == "")
                senderWeight = 0.ToString();
            else
                App.Weight = double.Parse(senderWeight);
        }

        void SetQuantity(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        { 
            string senderQuantity = ((Entry)sender).Text;
            if (senderQuantity == null || senderQuantity == "")
                senderQuantity = 0.ToString();
            else
                App.Quantity = double.Parse(senderQuantity);
        }

        void SetREF(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            string senderREF = ((Entry)sender).Text;
            if (senderREF == null || senderREF == "")
                senderREF = 0.ToString();
            else
                App.REF = double.Parse(senderREF);
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
        #endregion
    }
}