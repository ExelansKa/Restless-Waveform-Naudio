using System.Drawing;

namespace Restless.WaveForm
{
    /// <summary>
    /// Represents settings for <see cref="BarRenderer"/>
    /// </summary>
    /// <remarks>
    /// This class extends <see cref="Settings"/> to provide a set of default values
    /// that work decently with <see cref="BarRenderer"/>. You can still modify to customize the render result.
    /// </remarks>
    public class BarSettings : Settings
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BarSettings"/> class.
        /// </summary>
        public BarSettings()
        {
            DisplayName = "Standard Bar";
            Height = 128;
            PrimaryLineColor = Color.Black;
            SecondaryLineColor = Color.Red;
            LineThickness = 4;
            CenterLineColor = Color.DarkSlateGray;
            CenterLineThickness = 1;
            ZoomX = 5;
        }

        /// <summary>
        /// Private constructor for fat style
        /// </summary>
        /// <param name="displayName"></param>
        private BarSettings(string displayName)
        {
            DisplayName = displayName;
            Height = 172;
            LineThickness = 7;
            CenterLineThickness = 0;
            ZoomX = 8;
            ScaleZoomX = false;
        }

        /// <summary>
        /// Returns an instance of the <see cref="BarSettings"/> using a default set of gray colors.
        /// </summary>
        /// <returns>An instance of <see cref="BarSettings"/></returns>
        public static BarSettings CreateFatGray()
        {
            return new BarSettings("Fat Bar (Gray)")
            {
                PrimaryLineColor = Color.FromArgb(52, 52, 52),
                SecondaryLineColor = Color.FromArgb(154, 154, 154),
            };
        }

        /// <summary>
        /// Returns an instance of the <see cref="BarSettings"/> using a default set of orange colors.
        /// </summary>
        /// <returns>An instance of <see cref="BarSettings"/></returns>
        public static BarSettings CreateFatOrange()
        {
            return new BarSettings("Fat Bar (Orange)")
            {
                PrimaryLineColor = Color.FromArgb(255, 76, 0),
                SecondaryLineColor = Color.FromArgb(255, 171, 141),
            };
        }
        #endregion

        /************************************************************************/

        #region Protected methods
        /// <summary>
        /// Returns an adjusted line thickness in response to a changed zoom x.
        /// </summary>
        /// <param name="actualZoomX">The actual zoom x</param>
        /// <param name="actualLineThickness">The cuurent actual line thickness</param>
        /// <returns>A new line thickness value.</returns>
        protected override int GetActualLineThickness(int actualZoomX, int actualLineThickness)
        {
            return actualZoomX - 1;
        }
        #endregion
    }
}