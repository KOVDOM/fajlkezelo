using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fajlkezelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string path=Directory.GetCurrentDirectory();
            richTextbox.Selection.Text = path;
            string[] konyvtarak=Directory.GetDirectories(path);
            foreach (var item in konyvtarak)
            {
                string[] darabok = item.Split('\\');
                listBox.Items.Add(darabok[darabok.Length - 1] + "\n");
            }
            string[] fajlok = Directory.GetFiles(path);
            foreach (var item in fajlok)
            {
                string[] darabok = item.Split('\\');
                listBox.Items.Add(darabok[darabok.Length - 1] + "\n");
            }
        }

        private void visszaGomb_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            string ujpath = path.Remove(path.LastIndexOf('\\'),path.Length-path.LastIndexOf('\\'));
            richTextbox.Selection.Text = ujpath;
            listBox.Items.Clear();
            Directory.SetCurrentDirectory(ujpath);
            string[] konyvtarak = Directory.GetDirectories(ujpath);
            foreach (var item in konyvtarak)
            {
                string[] darabok = item.Split('\\');
                listBox.Items.Add(darabok[darabok.Length - 1] + "\n");
            }
            string[] fajlok = Directory.GetFiles(ujpath);
            foreach (var item in fajlok)
            {
                string[] darabok = item.Split('\\');
                listBox.Items.Add(darabok[darabok.Length - 1] + "\n");
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        //    string path = Directory.GetCurrentDirectory();
        //    var ertek = listBox.SelectedItem;
        //    //MessageBox.Show(ertek.ToString());
        //    string ujpath = path + "\\" + ertek;
        //    //MessageBox.Show(ujpath);
        //    try
        //    {
        //        StreamReader sr = new StreamReader($"{ujpath}");
        //        while (!sr.EndOfStream)
        //        {
        //            richTextbox2.Selection.Text = sr.ReadLine();
        //        }
        //        sr.Close();
        //    }
        //    catch (Exception)
        //    {
        //        richTextbox2.Selection.Text = "Nem található";
        //    }
        }

        private void richTextbox2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            var ertek = listBox.SelectedItem;
            //MessageBox.Show(ertek.ToString());
            string ujpath = path + "\\" + ertek;
            //MessageBox.Show(ujpath);
            try
            {
                StreamReader sr = new StreamReader($"{ujpath}");
                while (!sr.EndOfStream)
                {
                    richTextbox2.Selection.Text = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception)
            {
                richTextbox2.Selection.Text = "Nem található";
            }
        }
    }
}
