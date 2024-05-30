namespace Leonardo_Andrade_PROYECTOAPUNTES
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.LA00ALLNOTES), typeof(Views.LA00ALLNOTES));
        }
    }
}
