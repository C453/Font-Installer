﻿using System;
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
            this.Topmost = true;
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void ListBox_OnDrop(object sender, DragEventArgs e)
        {
            label.Visibility = Visibility.Hidden;
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
                MessageBox.Show($"There were some errors installing fonts. {Fonts.Count - _errorCount} out of {Fonts.Count} fonts have been installed.");
                return;
            }

            MessageBox.Show("All fonts installed successfully\nTheese fonts will be avaliable until shutdown.");
        }
    }
}