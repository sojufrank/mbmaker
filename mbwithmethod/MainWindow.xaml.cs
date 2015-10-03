using System;
using System.Collections.Generic;
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

namespace mbwithmethod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Data mainlabel = new Data();
            Data sendlabel = new Data();
            Data mainkeys = new Data();
            Data output = new Data();
            Data finallabel = new Data();
            Data movekeys = new Data();
            Data altandshift = new Data();
                textOut.Text = string.Empty;

                string[] alt = new string[] { textBox.Text.Trim().Replace(" ", ""), textBox1.Text.Trim().Replace(" ", ""),
                    textBox2.Text.Trim().Replace(" ", ""), textBox3.Text.Trim().Replace(" ", ""),
                    textBox4.Text.Trim().Replace(" ", ""), textBox5.Text.Trim().Replace(" ", "") };
            
                string trigger = "<Hotkey %Trigger%>\r\n";
            
            // Textbox checks start here
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                mainlabel.alt = label(alt[0]);
                sendlabel.alt = comma(alt[0]);
            }
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                mainlabel.alt1 = label(alt[1]);
                sendlabel.alt1 = comma(alt[1]);
            }
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                mainlabel.alt2 = label(alt[2]);
                sendlabel.alt2 = comma(alt[2]);
            }
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                mainlabel.alt3 = label(alt[3]);
                sendlabel.alt3 = comma(alt[3]);
            }
            if (!string.IsNullOrWhiteSpace(textBox4.Text))
            {
                mainlabel.alt4 = label(alt[4]);
                sendlabel.alt4 = comma(alt[4]);
            }
            if (!string.IsNullOrWhiteSpace(textBox5.Text))
            {
                mainlabel.alt5 = label(alt[5]);
                sendlabel.alt5 = comma(alt[5]);
            }

            // sendlabel must be created here for it to populate properly
            if (!string.IsNullOrWhiteSpace(textBox.Text) || !string.IsNullOrWhiteSpace(textBox1.Text) ||
                !string.IsNullOrWhiteSpace(textBox2.Text) || !string.IsNullOrWhiteSpace(textBox3.Text) ||
                !string.IsNullOrWhiteSpace(textBox4.Text) || !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                sendlabel.temp = sendlabel.alt + sendlabel.alt1 + sendlabel.alt2 + 
                    sendlabel.alt3 + sendlabel.alt4 + sendlabel.alt5;
                sendlabel.temp = sendlabel.temp.Remove(sendlabel.temp.Length - 2);
                sendlabel.output = "<SendLabel " + sendlabel.temp + ">\r\n";

            }

            //Checkboxes start here
            if ((bool)checkBox.IsChecked)
            {
                movekeys.temp = "<MovementHotKey up, down, left, right>\r\n";
            }
            if ((bool)checkBox1.IsChecked)
            {
                altandshift.temp = "<HotKey LAlt 0-9; LShift 0-9>\r\n";
            }
            if ((bool)checkBox2.IsChecked)
            {
                mainkeys.eifg = " e, i, f, g, h, j, k, l, v, b, n, m,";
            }
            if ((bool)checkBox3.IsChecked)
            {
                mainkeys.fkeys = " f1, f2, f3, f4, f5, f6,";
            }
             if ((bool)checkBox4.IsChecked)
            {
               mainkeys.insdel = " insert, delete, home, end,";
            }

            // Script assembly
            if ((!string.IsNullOrWhiteSpace(textBox.Text) || !string.IsNullOrWhiteSpace(textBox1.Text) ||
                !string.IsNullOrWhiteSpace(textBox2.Text) || !string.IsNullOrWhiteSpace(textBox3.Text) ||
                !string.IsNullOrWhiteSpace(textBox4.Text) || !string.IsNullOrWhiteSpace(textBox5.Text))
                && (bool)checkBox.IsChecked)
            {
                movekeys.output = string.Format("{0}{1}{2}", movekeys.temp, sendlabel.output, trigger) + "\r\n";
            }
            if ((!string.IsNullOrWhiteSpace(textBox.Text) || !string.IsNullOrWhiteSpace(textBox1.Text) ||
                !string.IsNullOrWhiteSpace(textBox2.Text) || !string.IsNullOrWhiteSpace(textBox3.Text) ||
                !string.IsNullOrWhiteSpace(textBox4.Text) || !string.IsNullOrWhiteSpace(textBox5.Text))
                && (bool)checkBox1.IsChecked)
            {
                altandshift.output = string.Format("{0}{1}{2}", altandshift.temp, sendlabel.output, trigger) + "\r\n";
            }
            if (!string.IsNullOrWhiteSpace(textBox.Text) || !string.IsNullOrWhiteSpace(textBox1.Text) ||
                !string.IsNullOrWhiteSpace(textBox2.Text) || !string.IsNullOrWhiteSpace(textBox3.Text) ||
                !string.IsNullOrWhiteSpace(textBox4.Text) || !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                mainkeys.escspace = "<Hotkeys Esc, Space, 0-9,";
                mainkeys.temp = mainkeys.escspace + mainkeys.eifg + mainkeys.fkeys + mainkeys.insdel;
                mainkeys.temp = mainkeys.temp.Remove(mainkeys.temp.Length - 1);
                mainkeys.output = mainkeys.temp + ">\r\n" + sendlabel.output + trigger + "\r\n";
                finallabel.output = mainlabel.alt + mainlabel.alt1 + 
                mainlabel.alt2 + mainlabel.alt3 + mainlabel.alt4 + mainlabel.alt5 + "\r\n";
            }

            output.output = finallabel.output + mainkeys.output + movekeys.output + altandshift.output;

                //print
                textOut.Text = output.output; 
        }
         private static string label(string name)
        {
                return string.Format("<Label {0} Local SendWinm \"Anarchy Online - {0}\">\r\n", name);
         }
        private static string comma(string name)
        {
            return string.Format("{0}, ", name);
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }

    class Data
    {
        public string alt { get; set; }
        public string alt1 { get; set; }
        public string alt2 { get; set; }
        public string alt3 { get; set; }
        public string alt4 { get; set; }
        public string alt5 { get; set; }
        public string eifg { get; set; }
        public string escspace { get; set; }
        public string output { get; set; }
        public string temp { get; set; }
        public string fkeys { get; set; }
        public string insdel { get; set; }
    }

}
