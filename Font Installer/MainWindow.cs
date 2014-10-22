using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Font_Installer
{
    public partial class MainWindow : Form
    {
        [DllImport("gdi32.dll")]
        static extern int AddFontResource(string file);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseFolderBtn_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            var files = Directory.GetFiles(fbd.SelectedPath);

            MessageBox.Show((files.Count(i => i.EndsWith(".ttf") || i.EndsWith(".otf") || i.EndsWith(".fnt")) + " Fonts Found"));
            var errorCount = 0;

            var fonts = files.Where(i => i.EndsWith(".ttf") || i.EndsWith(".otf") || i.EndsWith(".fnt")).ToList();

            Parallel.ForEach(fonts, j =>
            {
                try
                {
                    AddFontResource(j);
                }
                catch
                {
                    errorCount++;
                }
            });

            if(errorCount > 0)
            {
                MessageBox.Show(string.Format("There were some errors installing fonts. {0} out of {1} fonts have been installed.", fonts.Count - errorCount, fonts.Count));
                return;
            }

            MessageBox.Show(@"All fonts installed successfully
Theese fonts will be avaliable until shutdown.");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            new SoundPlayer(Properties.Resources.OH_GOD_AHHH).PlayLooping();
        }
    }
}
