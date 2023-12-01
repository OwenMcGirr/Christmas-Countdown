namespace Christmas_Countdown
{
    public partial class MainPage : ContentPage
    {
        private System.Timers.Timer _timer;

        public MainPage()
        {
            InitializeComponent();

            // Start the timer to refresh the bobbles
            _timer = new System.Timers.Timer(100);
            _timer.Elapsed += RefreshBobbles;
            _timer.Start();
        }

        // Function to refresh the bobbles
        private void RefreshBobbles(object sender, System.Timers.ElapsedEventArgs e)
        {
            bobbleView.Invalidate();
        }

    }
}
