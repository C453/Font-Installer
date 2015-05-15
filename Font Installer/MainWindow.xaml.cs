using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;

namespace Font_Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        [DllImport("gdi32.dll")]
        static extern int AddFontResource(string file);
        private static readonly List<string> Fonts = new List<string>();

        private uint _errorCount;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_OnDrop(object sender, DragEventArgs e)
        {
	        if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

	        var files = (string[]) e.Data.GetData(DataFormats.FileDrop);

	        foreach(var font in files.Where(i => i.EndsWith(".ttf") || i.EndsWith(".otf") || i.EndsWith(".fnt")))
	        {
		        listBox.Items.Add(System.IO.Path.GetFileName(font));
		        Fonts.Add(font);
	        }
        }

        private void ImportFontsBtn_Click(object sender, RoutedEventArgs e)
        {
	        if (Fonts.Count == 0) return;

            Parallel.ForEach(Fonts, j =>
            {
                try
                {
                    AddFontResource(j);
                }
                catch
                {
                    _errorCount++;
                }
            });

            if (_errorCount > 0)
            {
                MessageBox.Show(string.Format("There were some errors installing fonts. {0} out of {1} fonts have been installed.", Fonts.Count - _errorCount, Fonts.Count));
                return;
            }

            MessageBox.Show("All fonts installed successfully\nTheese fonts will be avaliable until shutdown.");
        }
    }
}