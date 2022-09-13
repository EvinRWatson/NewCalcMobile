using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace NewCalcMobile
{
    public partial class TotalsPage : ContentPage
    {
        #region Variables
        private static double CbrtTotalNEW { get; set; }
        private static int StandoffWithCover { get; set; }
        private static int StandoffWithoutCover { get; set; }
        private static int StandoffOverpressure { get; set; }
        private static int StandoffLightFrag { get; set; }
        private static int StandoffHeavyFrag { get; set; }
        #endregion

        public TotalsPage()
        {
            InitializeComponent();
            SetTotals();

            NumElementLabel.Text = $"Element #            {App.numElements}";
            TotalNEWLabel.Text = $"Total NEW:           {App.TotalNEW}";
            wCoverLabel.Text = $"With Cover:          {StandoffWithCover}ft";
            woCoverLabel.Text = $"Without Cover:    {StandoffWithoutCover}ft";
            OverPressureLabel.Text = $"Overpressure:     {StandoffOverpressure}ft";
            LightFragLabel.Text = $"Light Frag:           {StandoffLightFrag}ft";
            HeavyFragLabel.Text = $"Heavy Frag:         {StandoffHeavyFrag}ft";
        }

        public void SetTotals()
        {
            if (App.TotalNEW != 0)
            {
                CbrtTotalNEW = CubeRoot(App.TotalNEW);
                StandoffWithCover = ((int)(CbrtTotalNEW * 10)) + 1;
                StandoffWithoutCover = ((int)(CbrtTotalNEW * 15)) + 1;
                StandoffOverpressure = ((int)(CbrtTotalNEW * 20)) + 1;
                StandoffLightFrag = ((int)(CbrtTotalNEW * 300)) + 1;
                StandoffHeavyFrag = ((int)(CbrtTotalNEW * 500)) + 1;
            }
        }

        public double CubeRoot(double input)
        {
            return Math.Pow(input, (1.0 / 3.0));
        }

        async void RestartApp(object sender, EventArgs e)
        {
            ResetTotals();
            App.InitializeGlobals();
            await Navigation.PushAsync(new MainPage(), true);
        }

        public static void ResetTotals()
        {
            CbrtTotalNEW = 0;
            StandoffWithCover = 0;
            StandoffWithoutCover = 0;
            StandoffOverpressure = 0;
            StandoffLightFrag = 0;
            StandoffHeavyFrag = 0;
        }
    }
}