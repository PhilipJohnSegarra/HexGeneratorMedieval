using Microsoft.Maui.Controls;

namespace HexGeneratorMedieval
{
    public partial class MainPage : ContentPage
    {
        string hexColor, red, green, blue;

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            HexColor = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
            witchImage.BackgroundColor = HexColor;
            hexColor = HexColor.ToHex();
            hexLabel.Text = hexColor;
        }

        private async void copy_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexColor);
            await DisplayAlert("Success", $"Text [{hexColor}] Copied to Clipboard", "ok");
        }

        Color HexColor = Color.FromRgb(0, 0, 0);

        private void randomBTN_Clicked(object sender, EventArgs e)
        {
            var rndColor = RandomColor();
            redSlider.Value = Convert.ToInt32(Math.Round(rndColor.Red * 255));
            greenSlider.Value = Convert.ToInt32(Math.Round(rndColor.Green * 255));
            blueSlider.Value = Convert.ToInt32(Math.Round(rndColor.Blue * 255));

        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            HexColor = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
            witchImage.BackgroundColor = HexColor;

            redLabel.Text = "  Red: " + (int)redSlider.Value;
            greenLabel.Text = "  Green: " + (int)(greenSlider.Value);
            blueLabel.Text = "  Blue: " + (int)(blueSlider.Value);

            hexColor = HexColor.ToHex();
            hexLabel.Text = hexColor;
        }

        public MainPage()
        {
            InitializeComponent();
            witchImage.BackgroundColor = HexColor;
        }

        private Color RandomColor()
        {
            var rnd = new Random();
            return Color.FromRgb(rnd.Next(0,256), rnd.Next(0,256), rnd.Next(0,256));
        }
    }

}
