using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewCalcMobile
{
    public partial class App : Application
    {
        public static double Weight { get; set; }
        public static double Quantity { get; set; }
        public static double REF { get; set; }
        public static double CurrentNEW { get; set; }
        public static double TotalNEW { get; set; }
        public static bool isGrain { get; set; }
        public static int numElements { get; set; }

        public App()
        {
            BindingContext = this;
            InitializeComponent();
            InitializeGlobals();
            MainPage = new NavigationPage(new MainPage());
        }

        public static void InitializeGlobals()
        {
            Weight = 0;
            Quantity = 0;
            REF = 0;
            CurrentNEW = 0;
            TotalNEW = 0;
            isGrain = false;
            numElements = 1;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
