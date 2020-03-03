using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;


namespace PIP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            XmlTextReader reader = new XmlTextReader("DBRaces.xml");
            while (reader.Read())
            {
                if (reader.Name == "race")
                {
                    while (reader.MoveToNextAttribute()) // Read the attributes.
                        comboBoxRace.Items.Add(reader.Value);
                }
            }
         }

        private void buttonParcourir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "jpeg";
            openFile.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                Uri fileUri = new Uri(openFile.FileName);
                imagePerso.Source = new BitmapImage(fileUri);
            }
        }

        private void buttonParcourirCreature_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "jpeg";
            openFile.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                Uri fileUri = new Uri(openFile.FileName);
                imageCreature.Source = new BitmapImage(fileUri);
            }
        }

        private void textBoxValeurFor_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
            for (int i = 0; i < 20; i++)
            {
                if (textBoxValeurFor.Text != valeurs[i])
                {
                    textBoxModFor.Text = "ERR.";
                    break;
                }
            }
            if (textBoxValeurFor.Text == "1" || textBoxValeurFor.Text == "2" || textBoxValeurFor.Text == "3")
            {
                textBoxModFor.Text = "-4";
            }
            if (textBoxValeurFor.Text == "4" || textBoxValeurFor.Text == "5")
            {
                textBoxModFor.Text = "-3";
            }
            if (textBoxValeurFor.Text == "6" || textBoxValeurFor.Text == "7")
            {
                textBoxModFor.Text = "-2";
            }
            if (textBoxValeurFor.Text == "8" || textBoxValeurFor.Text == "9")
            {
                textBoxModFor.Text = "-1";
            }
            if (textBoxValeurFor.Text == "10" || textBoxValeurFor.Text == "11")
            {
                textBoxModFor.Text = "0";
            }
            if (textBoxValeurFor.Text == "12" || textBoxValeurFor.Text == "13")
            {
                textBoxModFor.Text = "+1";
            }
            if (textBoxValeurFor.Text == "14" || textBoxValeurFor.Text == "15")
            {
                textBoxModFor.Text = "+2";
            }
            if (textBoxValeurFor.Text == "16" || textBoxValeurFor.Text == "17")
            {
                textBoxModFor.Text = "+3";
            }
            if (textBoxValeurFor.Text == "18" || textBoxValeurFor.Text == "19")
            {
                textBoxModFor.Text = "+4";
            }
            if (textBoxValeurFor.Text == "20" || textBoxValeurFor.Text == "21")
            {
                textBoxModFor.Text = "+5";
            }
        }
        private void textBoxValeurDex_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
            for (int i = 0; i < 20; i++)
            {
                if (textBoxValeurDex.Text != valeurs[i])
                {
                    textBoxModDex.Text = "ERR.";
                    break;
                }
            }
            if (textBoxValeurDex.Text == "1" || textBoxValeurDex.Text == "2" || textBoxValeurDex.Text == "3")
            {
                textBoxModDex.Text = "-4";
            }
            if (textBoxValeurDex.Text == "4" || textBoxValeurDex.Text == "5")
            {
                textBoxModDex.Text = "-3";
            }
            if (textBoxValeurDex.Text == "6" || textBoxValeurDex.Text == "7")
            {
                textBoxModDex.Text = "-2";
            }
            if (textBoxValeurDex.Text == "8" || textBoxValeurDex.Text == "9")
            {
                textBoxModDex.Text = "-1";
            }
            if (textBoxValeurDex.Text == "10" || textBoxValeurDex.Text == "11")
            {
                textBoxModDex.Text = "0";
            }
            if (textBoxValeurDex.Text == "12" || textBoxValeurDex.Text == "13")
            {
                textBoxModDex.Text = "+1";
            }
            if (textBoxValeurDex.Text == "14" || textBoxValeurDex.Text == "15")
            {
                textBoxModDex.Text = "+2";
            }
            if (textBoxValeurDex.Text == "16" || textBoxValeurDex.Text == "17")
            {
                textBoxModDex.Text = "+3";
            }
            if (textBoxValeurDex.Text == "18" || textBoxValeurDex.Text == "19")
            {
                textBoxModDex.Text = "+4";
            }
            if (textBoxValeurDex.Text == "20" || textBoxValeurDex.Text == "21")
            {
                textBoxModDex.Text = "+5";
            }
            textBoxValeurInit.Text = textBoxValeurDex.Text;
        }
        private void textBoxValeurCon_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
            for (int i = 0; i < 20; i++)
            {
                if (textBoxValeurCon.Text != valeurs[i])
                {
                    textBoxModCon.Text = "ERR.";
                    break;
                }
            }
            if (textBoxValeurCon.Text == "1" || textBoxValeurCon.Text == "2" || textBoxValeurCon.Text == "3")
            {
                textBoxModCon.Text = "-4";
            }
            if (textBoxValeurCon.Text == "4" || textBoxValeurCon.Text == "5")
            {
                textBoxModCon.Text = "-3";
            }
            if (textBoxValeurCon.Text == "6" || textBoxValeurCon.Text == "7")
            {
                textBoxModCon.Text = "-2";
            }
            if (textBoxValeurCon.Text == "8" || textBoxValeurCon.Text == "9")
            {
                textBoxModCon.Text = "-1";
            }
            if (textBoxValeurCon.Text == "10" || textBoxValeurCon.Text == "11")
            {
                textBoxModCon.Text = "0";
            }
            if (textBoxValeurCon.Text == "12" || textBoxValeurCon.Text == "13")
            {
                textBoxModCon.Text = "+1";
            }
            if (textBoxValeurCon.Text == "14" || textBoxValeurCon.Text == "15")
            {
                textBoxModCon.Text = "+2";
            }
            if (textBoxValeurCon.Text == "16" || textBoxValeurCon.Text == "17")
            {
                textBoxModCon.Text = "+3";
            }
            if (textBoxValeurCon.Text == "18" || textBoxValeurCon.Text == "19")
            {
                textBoxModCon.Text = "+4";
            }
            if (textBoxValeurCon.Text == "20" || textBoxValeurCon.Text == "21")
            {
                textBoxModCon.Text = "+5";
            }
        }
        private void textBoxValeurInt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
            for (int i = 0; i < 20; i++)
            {
                if (textBoxValeurInt.Text != valeurs[i])
                {
                    textBoxModInt.Text = "ERR.";
                    break;
                }
            }
            if (textBoxValeurInt.Text == "1" || textBoxValeurInt.Text == "2" || textBoxValeurInt.Text == "3")
            {
                textBoxModInt.Text = "-4";
            }
            if (textBoxValeurInt.Text == "4" || textBoxValeurInt.Text == "5")
            {
                textBoxModInt.Text = "-3";
            }
            if (textBoxValeurInt.Text == "6" || textBoxValeurInt.Text == "7")
            {
                textBoxModInt.Text = "-2";
            }
            if (textBoxValeurInt.Text == "8" || textBoxValeurInt.Text == "9")
            {
                textBoxModInt.Text = "-1";
            }
            if (textBoxValeurInt.Text == "10" || textBoxValeurInt.Text == "11")
            {
                textBoxModInt.Text = "0";
            }
            if (textBoxValeurInt.Text == "12" || textBoxValeurInt.Text == "13")
            {
                textBoxModInt.Text = "+1";
            }
            if (textBoxValeurInt.Text == "14" || textBoxValeurInt.Text == "15")
            {
                textBoxModInt.Text = "+2";
            }
            if (textBoxValeurInt.Text == "16" || textBoxValeurInt.Text == "17")
            {
                textBoxModInt.Text = "+3";
            }
            if (textBoxValeurInt.Text == "18" || textBoxValeurInt.Text == "19")
            {
                textBoxModInt.Text = "+4";
            }
            if (textBoxValeurInt.Text == "20" || textBoxValeurInt.Text == "21")
            {
                textBoxModInt.Text = "+5";
            }
        }
        private void textBoxValeurSag_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
            for (int i = 0; i < 20; i++)
            {
                if (textBoxValeurSag.Text != valeurs[i])
                {
                    textBoxModSag.Text = "ERR.";
                    break;
                }
            }
            if (textBoxValeurSag.Text == "1" || textBoxValeurSag.Text == "2" || textBoxValeurSag.Text == "3")
            {
                textBoxModSag.Text = "-4";
            }
            if (textBoxValeurSag.Text == "4" || textBoxValeurSag.Text == "5")
            {
                textBoxModSag.Text = "-3";
            }
            if (textBoxValeurSag.Text == "6" || textBoxValeurSag.Text == "7")
            {
                textBoxModSag.Text = "-2";
            }
            if (textBoxValeurSag.Text == "8" || textBoxValeurSag.Text == "9")
            {
                textBoxModSag.Text = "-1";
            }
            if (textBoxValeurSag.Text == "10" || textBoxValeurSag.Text == "11")
            {
                textBoxModSag.Text = "0";
            }
            if (textBoxValeurSag.Text == "12" || textBoxValeurSag.Text == "13")
            {
                textBoxModSag.Text = "+1";
            }
            if (textBoxValeurSag.Text == "14" || textBoxValeurSag.Text == "15")
            {
                textBoxModSag.Text = "+2";
            }
            if (textBoxValeurSag.Text == "16" || textBoxValeurSag.Text == "17")
            {
                textBoxModSag.Text = "+3";
            }
            if (textBoxValeurSag.Text == "18" || textBoxValeurSag.Text == "19")
            {
                textBoxModSag.Text = "+4";
            }
            if (textBoxValeurSag.Text == "20" || textBoxValeurSag.Text == "21")
            {
                textBoxModSag.Text = "+5";
            }
        }
        private void textBoxValeurCha_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
            for (int i = 0; i < 20; i++)
            {
                if (textBoxValeurCha.Text != valeurs[i])
                {
                    textBoxModCha.Text = "ERR.";
                    break;
                }
            }
            if (textBoxValeurCha.Text == "1" || textBoxValeurCha.Text == "2" || textBoxValeurCha.Text == "3")
            {
                textBoxModCha.Text = "-4";
            }
            if (textBoxValeurCha.Text == "4" || textBoxValeurCha.Text == "5")
            {
                textBoxModCha.Text = "-3";
            }
            if (textBoxValeurCha.Text == "6" || textBoxValeurCha.Text == "7")
            {
                textBoxModCha.Text = "-2";
            }
            if (textBoxValeurCha.Text == "8" || textBoxValeurCha.Text == "9")
            {
                textBoxModCha.Text = "-1";
            }
            if (textBoxValeurCha.Text == "10" || textBoxValeurCha.Text == "11")
            {
                textBoxModCha.Text = "0";
            }
            if (textBoxValeurCha.Text == "12" || textBoxValeurCha.Text == "13")
            {
                textBoxModCha.Text = "+1";
            }
            if (textBoxValeurCha.Text == "14" || textBoxValeurCha.Text == "15")
            {
                textBoxModCha.Text = "+2";
            }
            if (textBoxValeurCha.Text == "16" || textBoxValeurCha.Text == "17")
            {
                textBoxModCha.Text = "+3";
            }
            if (textBoxValeurCha.Text == "18" || textBoxValeurCha.Text == "19")
            {
                textBoxModCha.Text = "+4";
            }
            if (textBoxValeurCha.Text == "20" || textBoxValeurCha.Text == "21")
            {
                textBoxModCha.Text = "+5";
            }
        }
        private void lireNoeud (XmlReader reader)
        {
            TextBox textBox = null;
            reader.MoveToNextAttribute();
            if (reader.Value == "FOR")
            {
                textBox = textBoxValeurFor;
            }
            if (reader.Value == "DEX")
            {
                textBox = textBoxValeurDex;
            }
            if (reader.Value == "CON")
            {
                textBox = textBoxValeurCon;
            }
            if (reader.Value == "INT")
            {
                textBox = textBoxValeurInt;
            }
            if (reader.Value == "SAG")
            {
                textBox = textBoxValeurSag;
            }
            if (reader.Value == "CHA")
            {
                textBox = textBoxValeurCha;
            }
            reader.Read();
            int valeur = int.Parse(textBox.Text);
            valeur += int.Parse(reader.Value);
            textBox.Text = valeur.ToString();
        }
        private void comboBoxRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create("DBRaces.xml", settings))
            {

                while (reader.Read())
                {
                    reader.ReadToFollowing("race");
                    reader.MoveToNextAttribute();
                    if (reader.Value == comboBoxRace.SelectedItem.ToString())
                    {
                        reader.MoveToElement();
                        XmlReader inner = reader.ReadSubtree();
                        do
                        {
                            inner.MoveToElement();
                            inner.ReadToFollowing("char");
                            reader.MoveToNextAttribute();
                            if (inner.Value == "capacite")
                            {
                                inner.Read();
                                textBoxCapacRaciales.Text = inner.Value;
                                inner.Close();
                                break;
                            }
                            else lireNoeud(inner);
                        }
                        while (reader.Read());
                    }
                }
            }
        }

        private void textBoxModFor_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "-4", "-3", "-2", "-1", "0", "+1", "+2", "+3", "+4", "+5"};
            for (int i = -4; i < 6; i++)
            {
                if (textBoxModFor.Text != valeurs[i + 4])
                {
                    textBoxValeurCAC.Text = "ERR.";
                }
                if (textBoxModFor.Text == valeurs[i + 4])
                {
                    textBoxValeurCAC.Text = valeurs[i + 4];
                    break;
                }
            }
        }

        private void textBoxModDex_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "-4", "-3", "-2", "-1", "0", "+1", "+2", "+3", "+4", "+5" };
            for (int i = -4; i < 6; i++)
            {
                if (textBoxModDex.Text != valeurs[i + 4])
                {
                    textBoxValeurDistance.Text = "ERR.";
                }
                if (textBoxModDex.Text == valeurs[i + 4])
                {
                    textBoxValeurDistance.Text = valeurs[i + 4];
                    break;
                }
            }
        }

        private void textBoxModInt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] valeurs = new string[] { "-4", "-3", "-2", "-1", "0", "+1", "+2", "+3", "+4", "+5" };
            for (int i = -4; i < 6; i++)
            {
                if (textBoxModInt.Text != valeurs[i + 4])
                {
                    textBoxValeurMagique.Text = "ERR.";
                }
                if (textBoxModInt.Text == valeurs[i + 4])
                {
                    textBoxValeurMagique.Text = valeurs[i + 4];
                    break;
                }
            }
        }
    }
}
