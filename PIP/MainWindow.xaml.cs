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
using System.Xml.Linq;
using System.Xml.XPath;
using System.Data;


namespace PIP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Personnage> personnages = new List<Personnage>();
        public MainWindow()
        {
            InitializeComponent();
            List<Personnage> personnages = new List<Personnage>();
            XmlReaderSettings settings = new XmlReaderSettings(); //Lis la DB des races et des profils et rajoute les différentes races et profils au combo box des races et profils
            settings.IgnoreWhitespace = true;
            using (XmlReader readerRace = XmlReader.Create("..\\..\\DBRaces.xml", settings))
            {
                while (readerRace.Read())
                {
                    if (readerRace.Name == "race")
                    {
                        while (readerRace.MoveToNextAttribute())
                            comboBoxRace.Items.Add(readerRace.Value);
                    }
                }
                readerRace.Close();
            }
            using (XmlReader readerProfil = XmlReader.Create("..\\..\\DBProfils.xml", settings))
            {
                while (readerProfil.Read())
                {
                    if (readerProfil.Name == "profil")
                    {
                        while (readerProfil.MoveToNextAttribute())
                            comboBoxProfil.Items.Add(readerProfil.Value);
                    }
                }
                readerProfil.Close();
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
        } //change la photo de profil en ouvrant une fenêtre de fichiers

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
        } //change la photo de profil en ouvrant une fenêtre de fichiers

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
        }  //Si la valeur de force change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
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
        } //Si la valeur de Dextérité change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
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
        } //Si la valeur de Constitution change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
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
        }//Si la valeur de Intelligence change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
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
        }//Si la valeur de Sagesse change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
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
        }//Si la valeur de Charisme change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante

        private void lireNoeud (XmlReader reader)
        {
            TextBox textBox = null; 
            reader.MoveToNextAttribute(); //On va au premier attribut du noeud
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
            reader.Read(); //On avance d'un pas
            int valeur = int.Parse(textBox.Text); //On récupère la valeur de caractéristique
            valeur += int.Parse(reader.Value); //On ajoute la valeur lue dans la database
            textBox.Text = valeur.ToString();
        } //Fonction qui lis un noeud de la database et détermine quelle caractéristique doit être modifiée

        private void comboBoxRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader readerRace = XmlReader.Create("..\\..\\DBRaces.xml", settings))
            {
                while (readerRace.Read()) //On commence à lire la databse
                {
                    readerRace.ReadToFollowing("race"); //On passe directement au premier noeud race
                    readerRace.MoveToNextAttribute(); //On cherche le premier attribut
                    if (readerRace.Value == comboBoxRace.SelectedItem.ToString()) //Si la valeur de l'attribut correspond au combobox, on continue
                    {
                        readerRace.MoveToElement(); //On retourne à la racine du noeud race
                        XmlReader inner = readerRace.ReadSubtree(); //On crée un nouveau reader qui va lire les enfants du noeud race
                        do
                        {
                            inner.ReadToFollowing("char"); //On cherche le prochain noeud char
                            readerRace.MoveToNextAttribute(); //On cherche le premier attribut
                            if (inner.Value == "capacite") //Si on arrive à l'attribut capacité alors
                            {
                                inner.Read(); //On avance d'un pas
                                textBoxCapacRaciales.Text = inner.Value; //On récupère le texte associé
                                inner.Close(); //On ferme le subtree
                                break; //On arrête la boucle while
                            }
                            else lireNoeud(inner); //Sinon on cherche si il y a un autre attribut
                        }
                        while (readerRace.Read()); //La boucle continue tant que on peut lire le fichier
                    }
                }
                readerRace.Close();
            }
        } //Au changement de race, on effectue des modifications sur les caractéristiques

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
        } //On modifie les valeurs de Corps à corps en fonction du mod de force

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
                    if (textBoxValeurArmure != null && textBoxValeurBouclier != null)
                    textBoxTotalDef.Text = (10 + int.Parse(valeurs[i + 4]) + int.Parse(textBoxValeurArmure.Text) + int.Parse(textBoxValeurBouclier.Text)).ToString();
                    break;
                }
            }
        } // On modifie les valeurs de distance et de défense en fonction du mod de dexterité

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
        } //On modifie les valeurs de magie en fonction du mod d'intelligence

        private void comboBoxProfil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> Equipement = new List<string>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader readerProfil = XmlReader.Create("..\\..\\DBProfils.xml", settings))
            {
                int caseSwitch = 1;
                while (readerProfil.Read()) //On commence à lire la databse
                {
                    readerProfil.ReadToFollowing("profil"); //On passe directement au premier noeud profil
                    readerProfil.MoveToNextAttribute();
                    if (readerProfil.Value == comboBoxProfil.SelectedItem.ToString())
                    {
                        readerProfil.ReadToFollowing("DDV");
                        readerProfil.Read();
                        textBoxValeurDDVie.Text = readerProfil.Value;

                        readerProfil.ReadToFollowing("PDV");
                        readerProfil.Read();
                        textBoxValeurPtsVie.Text = readerProfil.Value;

                        readerProfil.ReadToFollowing("armes");
                        XmlReader innerArmes = readerProfil.ReadSubtree();
                        do
                        {
                            chargerArmes(innerArmes, caseSwitch, Equipement);
                            caseSwitch++;
                        }
                        while (innerArmes.Read());
                        innerArmes.Close();

                        readerProfil.ReadToFollowing("bouclier");
                        readerProfil.MoveToNextAttribute();
                        if(readerProfil.Value != "")
                        {
                            Equipement.Add(readerProfil.Value);
                            readerProfil.Read();
                            textBoxValeurBouclier.Text = readerProfil.Value;
                        }

                        readerProfil.ReadToFollowing("armure");
                        readerProfil.MoveToNextAttribute();
                        Equipement.Add(readerProfil.Value);
                        readerProfil.Read();
                        textBoxValeurArmure.Text = readerProfil.Value;

                        readerProfil.ReadToFollowing("voies");
                        XmlReader innerVoies = readerProfil.ReadSubtree();
                        List<Voie> voies = new List<Voie>();
                        do
                        {
                            innerVoies.ReadToFollowing("voie");
                            if (innerVoies.MoveToNextAttribute() == false) break;
                            string nomVoie = innerVoies.Value;

                            innerVoies.ReadToFollowing("rangs");
                            XmlReader innerRangs = readerProfil.ReadSubtree();
                            List<string> rangs = new List<string>();
                            while (innerRangs.Read())
                            {
                                innerRangs.ReadToFollowing("rang");
                                innerRangs.MoveToNextAttribute();
                                if (innerRangs.Value == "") break;
                                int idRang = int.Parse(innerRangs.Value);
                                innerRangs.MoveToNextAttribute();
                                string nomRang = innerRangs.Value;
                                innerRangs.Read();
                                string descriptionRang = innerRangs.Value;
                                rangs.Add(descriptionRang);
                            }
                            innerRangs.Close();
                            Voie voie = new Voie() { Nom = nomVoie, Rang1 = rangs[0], Rang2 = rangs[1], Rang3 = rangs[2], Rang4 = rangs[3], Rang5 = rangs[4] };
                            voies.Add(voie);
                        }
                        while (innerVoies.Read());
                        innerVoies.Close();
                        dataGridCompétences.ItemsSource = voies;
                        string liste = "";
                        foreach (string equipement in Equipement)
                        {
                            if (equipement !="")
                            liste += (equipement+", ");
                        }
                        textBoxEquipement.Text = liste;
                    }
                }
            }
        } //Au changement de profil, on effectue des modifications sur les armes, l'équipement, la défence et les compétences

        private void chargerArmes (XmlReader reader, int caseSwitch, List<string> Equipement)
        {
            reader.ReadToFollowing("arme");
            reader.MoveToNextAttribute();
            switch (caseSwitch)
            {
                case 1:
                    textBoxArme1.Text = reader.Value;
                    Equipement.Add(reader.Value);
                    reader.ReadToFollowing("attaque");
                    reader.Read();
                    textBoxAttaque1.Text = reader.Value;
                    reader.ReadToFollowing("dommages");
                    reader.Read();
                    textBoxDM1.Text = reader.Value;
                    reader.ReadToFollowing("special");
                    reader.Read();
                    textBoxSpecial1.Text = reader.Value;
                    break;
                case 2:
                    textBoxArme2.Text = reader.Value;
                    Equipement.Add(reader.Value);
                    reader.ReadToFollowing("attaque");
                    reader.Read();
                    textBoxAttaque2.Text = reader.Value;
                    reader.ReadToFollowing("dommages");
                    reader.Read();
                    textBoxDM2.Text = reader.Value;
                    reader.ReadToFollowing("special");
                    reader.Read();
                    textBoxSpecial2.Text = reader.Value;
                    break;
                case 3:
                    textBoxArme3.Text = reader.Value;
                    Equipement.Add(reader.Value);
                    reader.ReadToFollowing("attaque");
                    reader.Read();
                    textBoxAttaque3.Text = reader.Value;
                    reader.ReadToFollowing("dommages");
                    reader.Read();
                    textBoxDM3.Text = reader.Value;
                    reader.ReadToFollowing("special");
                    reader.Read();
                    textBoxSpecial3.Text = reader.Value;
                    break;
            }
        }//Fonction de factorisation pour charger les armes dans la BDD profils

        private void textBoxValeurArmure_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxValeurArmure != null && textBoxValeurBouclier != null)
            {
                int i = 0;
                bool result = int.TryParse(textBoxValeurArmure.Text, out i);
                if (result == true)
                {
                    textBoxTotalDef.Text = (10 + int.Parse(textBoxModDex.Text) + int.Parse(textBoxValeurArmure.Text) + int.Parse(textBoxValeurBouclier.Text)).ToString();
                }
            }   
        }//Change la valeur totale d'armure si la valeur d'armure change

        private void textBoxValeurBouclier_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxValeurArmure != null && textBoxValeurBouclier != null)
            {
                int i = 0;
                bool result = int.TryParse(textBoxValeurBouclier.Text, out i);
                if (result == true)
                {
                    textBoxTotalDef.Text = (10 + int.Parse(textBoxModDex.Text) + int.Parse(textBoxValeurArmure.Text) + int.Parse(textBoxValeurBouclier.Text)).ToString();
                }
            }
        }//Change la valeur totale d'armure si la valeur de bouclier change

        private void textBoxNiveau_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxNiveau.Text.Equals("") || textBoxNiveau.Text.Equals("0")) return;
            if (textBoxValeurCAC != null && textBoxValeurDistance != null && textBoxValeurMagique != null && textBoxModDex != null && textBoxModFor != null && textBoxModInt != null)
            {
                int i = 1;
                bool result = int.TryParse(textBoxNiveau.Text, out i);
                if (result == true)
                {

                    i = int.Parse(textBoxNiveau.Text) - 1;
                    if((int.Parse(textBoxModFor.Text) + i) <0) textBoxValeurCAC.Text = (int.Parse(textBoxModFor.Text) + i).ToString();
                    else textBoxValeurCAC.Text = "+" + (int.Parse(textBoxModFor.Text) + i).ToString();
                    if((int.Parse(textBoxModDex.Text) + i) < 0) textBoxValeurDistance.Text = (int.Parse(textBoxModDex.Text) + i).ToString();
                    else textBoxValeurDistance.Text = "+" + (int.Parse(textBoxModDex.Text) + i).ToString();
                    if((int.Parse(textBoxModInt.Text) + i) < 0) textBoxValeurMagique.Text = (int.Parse(textBoxModInt.Text) + i).ToString();
                    else textBoxValeurMagique.Text = "+" + (int.Parse(textBoxModInt.Text) + i).ToString();
                }
            }
        }//Si le niveau change on effectue des changements sur les valeurs de combat

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Personnage lePerso = dataGridPerso.SelectedItem as Personnage;
            XDocument doc = XDocument.Load("..\\..\\DataBase.xml");
            foreach (XElement element in doc.Descendants("joueur"))
            {
                if (lePerso != null && element.Descendants("nom").First().Value == lePerso.Nom)
                {
                    personnages.Remove(personnages.Find(x => x.Nom.Contains(lePerso.Nom)));
                    lePerso.Nom = persoTextBox.Text;
                    element.Descendants("nom").First().Value = lePerso.Nom;
                    lePerso.Race = comboBoxRace.Text;
                    lePerso.Profil = comboBoxProfil.Text;
                    lePerso.Niveau = textBoxNiveau.Text;
                    lePerso.Portrait = imagePerso.Source.ToString();
                    IEnumerable<XElement> elements = element.Descendants("nom").First().ElementsAfterSelf();
                    XElement element_ = new XElement("vide");
                    for (int i= 0; i< 8; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                element_ = elements.ElementAt(i);
                                element_.Value = lePerso.Race;
                                break;
                            case 1:
                                element_ = elements.ElementAt(i);
                                element_.Value = lePerso.Profil;
                                break;
                            case 2:
                                element_ = elements.ElementAt(i);
                                element_.Value = lePerso.Niveau;
                                break;
                            case 3:
                                element_ = elements.ElementAt(i);
                                element_.Value = textBoxSexe.Text;
                                break;
                            case 4:
                                element_ = elements.ElementAt(i);
                                element_.Value = textBoxAge.Text;
                                break;
                            case 5:
                                element_ = elements.ElementAt(i);
                                element_.Value = textBoxTaille.Text;
                                break;
                            case 6:
                                element_ = elements.ElementAt(i);
                                element_.Value = textBoxPoids.Text;
                                break;
                            case 7:
                                element_ = elements.ElementAt(i);
                                element_.Value = lePerso.Portrait;
                                break;
                        }
                    }
                    element.Descendants("char").First().Value = textBoxValeurFor.Text;
                    elements = element.Descendants("char").First().ElementsAfterSelf();
                    elements.ElementAt(0).Value = textBoxValeurDex.Text;
                    elements.ElementAt(1).Value = textBoxValeurCon.Text;
                    elements.ElementAt(2).Value = textBoxValeurInt.Text;
                    elements.ElementAt(3).Value = textBoxValeurSag.Text;
                    elements.ElementAt(4).Value = textBoxValeurCha.Text;
                    elements.ElementAt(5).Value = textBoxValeurDDVie.Text;
                    elements.ElementAt(6).Value = textBoxValeurPtsVie.Text;
                    elements.ElementAt(7).Value = textBoxCapacRaciales.Text;
                    elements.ElementAt(8).Value = textBoxLangues.Text;
                    element.Descendants("bouclier").First().Value = textBoxValeurBouclier.Text;
                    element.Descendants("armure").First().Value = textBoxValeurArmure.Text;
                    elements = element.Descendants("armes");
                    int j = 0;
                    foreach (XElement _element in elements.DescendantsAndSelf("arme"))
                    {
                        if (j == 0)
                        {
                            _element.FirstAttribute.Value = textBoxArme1.Text;
                            _element.Descendants("attaque").First().Value = textBoxAttaque1.Text;
                            _element.Descendants("dommages").First().Value = textBoxDM1.Text;
                            _element.Descendants("special").First().Value = textBoxSpecial1.Text;
                        }
                        if (j == 1)
                        {   _element.FirstAttribute.Value = textBoxArme2.Text;
                            _element.Descendants("attaque").First().Value = textBoxAttaque2.Text;
                            _element.Descendants("dommages").First().Value = textBoxDM2.Text;
                            _element.Descendants("special").First().Value = textBoxSpecial2.Text;
                        }
                        if (j == 2)
                        {
                            _element.FirstAttribute.Value = textBoxArme3.Text;
                            _element.Descendants("attaque").First().Value = textBoxAttaque3.Text;
                            _element.Descendants("dommages").First().Value = textBoxDM3.Text;
                            _element.Descendants("special").First().Value = textBoxSpecial3.Text;
                        }
                        j++;
                    }
                    element.Descendants("equipement").First().Value = textBoxEquipement.Text;
                    personnages.Add(lePerso);
                }
            }
            doc.Save("..\\..\\DataBase.xml");
            dataGridPerso.Items.Refresh();
        }

        private void dataGridPerso_Initialized(object sender, EventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader readerPerso = XmlReader.Create("..\\..\\DataBase.xml", settings))
            {
                while (readerPerso.Read())
                {
                    readerPerso.ReadToFollowing("nom");
                    readerPerso.Read();
                    if (readerPerso.Value == "") break;
                    string nom = readerPerso.Value;
                    readerPerso.ReadToFollowing("race");
                    readerPerso.Read();
                    string race = readerPerso.Value;
                    readerPerso.ReadToFollowing("profil");
                    readerPerso.Read();
                    string profil = readerPerso.Value;
                    readerPerso.ReadToFollowing("niveau");
                    readerPerso.Read();
                    string niveau = readerPerso.Value;
                    readerPerso.ReadToFollowing("portrait");
                    readerPerso.Read();
                    string portrait = readerPerso.Value;
                    Personnage personnage = new Personnage() { Nom = nom, Niveau = niveau, Profil = profil, Race = race, Portrait = portrait };
                    personnages.Add(personnage);
                }
                readerPerso.Close();
            }
            dataGridPerso.ItemsSource = personnages;
        }//à l'initialisation charge les données sur les persos dans la BDD personnages et les affichages dans le datagridperso

        private void dataGridPerso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Personnage lePerso = dataGridPerso.SelectedItem as Personnage;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = false;
            using (XmlReader readerPerso = XmlReader.Create("..\\..\\DataBase.xml", settings))
            {
                while (readerPerso.Read())
                {
                    readerPerso.ReadToFollowing("nom");
                    readerPerso.Read();
                    if (lePerso != null && readerPerso.Value == lePerso.Nom)
                    {
                        persoTextBox.Text = lePerso.Nom;
                        comboBoxProfil.SelectedItem = lePerso.Profil;
                        comboBoxRace.SelectedItem = lePerso.Race;
                        textBoxNiveau.Text = lePerso.Niveau;
                        Uri fileUri = new Uri(lePerso.Portrait);
                        imagePerso.Source = new BitmapImage(fileUri);
                        ecrireValeur(textBoxSexe, "sexe", readerPerso);
                        ecrireValeur(textBoxAge, "age", readerPerso);
                        ecrireValeur(textBoxTaille, "taille", readerPerso);
                        ecrireValeur(textBoxPoids, "poids", readerPerso);
                        readerPerso.ReadToFollowing("caractéristiques");
                        ecrireValeur(textBoxValeurFor, "char", readerPerso);
                        ecrireValeur(textBoxValeurDex, "char", readerPerso);
                        ecrireValeur(textBoxValeurCon, "char", readerPerso);
                        ecrireValeur(textBoxValeurInt, "char", readerPerso);
                        ecrireValeur(textBoxValeurSag, "char", readerPerso);
                        ecrireValeur(textBoxValeurCha, "char", readerPerso);
                        ecrireValeur(textBoxValeurDDVie, "char", readerPerso);
                        ecrireValeur(textBoxValeurPtsVie, "char", readerPerso);
                        ecrireValeur(textBoxCapacRaciales, "char", readerPerso);
                        ecrireValeur(textBoxLangues, "char", readerPerso);
                        readerPerso.ReadToFollowing("defense");
                        ecrireValeur(textBoxValeurBouclier, "bouclier", readerPerso);
                        ecrireValeur(textBoxValeurArmure, "armure", readerPerso);
                        readerPerso.ReadToFollowing("arme");
                        readerPerso.MoveToNextAttribute();
                        textBoxArme1.Text = readerPerso.Value;
                        ecrireValeur(textBoxAttaque1, "attaque", readerPerso);
                        ecrireValeur(textBoxDM1, "dommages", readerPerso);
                        ecrireValeur(textBoxSpecial1, "special", readerPerso);
                        readerPerso.ReadToFollowing("arme");
                        readerPerso.MoveToNextAttribute();
                        textBoxArme2.Text = readerPerso.Value;
                        ecrireValeur(textBoxAttaque2, "attaque", readerPerso);
                        ecrireValeur(textBoxDM2, "dommages", readerPerso);
                        ecrireValeur(textBoxSpecial2, "special", readerPerso);
                        readerPerso.ReadToFollowing("arme");
                        readerPerso.MoveToNextAttribute();
                        textBoxArme3.Text = readerPerso.Value;
                        ecrireValeur(textBoxAttaque3, "attaque", readerPerso);
                        ecrireValeur(textBoxDM3, "dommages", readerPerso);
                        ecrireValeur(textBoxSpecial3, "special", readerPerso);
                        readerPerso.ReadToFollowing("equipement");
                        readerPerso.Read();
                        textBoxEquipement.Text = readerPerso.Value;
                        //ecrireValeur(textBoxEquipement, "equipement", readerPerso);
                        readerPerso.Close();
                    }
                }
            }
        }//au changement de selection charge les infos sur le perso en question

        private void ecrireValeur(TextBox textBoxCible, string cible, XmlReader reader)
        {
            if (reader.NodeType != XmlNodeType.EndElement) reader.Read();
            reader.ReadToNextSibling(cible);
            if (reader.IsEmptyElement)
                textBoxCible.Text = "";
            else
            {
                reader.Read();
                textBoxCible.Text = reader.Value;
            }
        }//fonction de factorisation pour écrire une valeur récupérée dans la BDD dans une textBox choisie
        private void recupValeur(TextBox textBoxCible, string cible, XmlReader reader, XmlWriter writer)
        {
            if (reader.NodeType != XmlNodeType.EndElement) reader.Read();
            reader.ReadToNextSibling(cible);
            if (textBoxCible.Text == "")
                writer.WriteValue("");
            else
            {
                reader.Read();
                writer.WriteValue(textBoxCible.Text);
            }
        }

        private void boutonCreerPerso_Click(object sender, RoutedEventArgs e)
        {
            XDocument doc = XDocument.Load("..\\..\\DataBase.xml");
            XElement racine = new XElement("joueur", new XElement("identité", new XElement("nom", persoTextBox.Text),
                       new XElement("race", comboBoxRace.Text),
                       new XElement("profil", comboBoxProfil.Text),
                       new XElement("niveau", textBoxNiveau.Text),
                       new XElement("sexe", textBoxSexe.Text),
                       new XElement("age", textBoxAge.Text),
                       new XElement("taille", textBoxTaille.Text),
                       new XElement("poids", textBoxPoids.Text),
                       new XElement("portrait", imagePerso.Source.ToString())
                       ),
                       new XElement("caractéristiques", new XElement("char", new XAttribute("nom", "FOR"), textBoxValeurFor.Text),
                       new XElement("char", new XAttribute("nom", "DEX"), textBoxValeurDex.Text),
                       new XElement("char", new XAttribute("nom", "CON"), textBoxValeurCon.Text),
                       new XElement("char", new XAttribute("nom", "INT"), textBoxValeurInt.Text),
                       new XElement("char", new XAttribute("nom", "SAG"), textBoxValeurSag.Text),
                       new XElement("char", new XAttribute("nom", "CHA"), textBoxValeurCha.Text),
                       new XElement("char", new XAttribute("nom", "DDV"), textBoxValeurDDVie.Text),
                       new XElement("char", new XAttribute("nom", "PDV"), textBoxValeurPtsVie.Text),
                       new XElement("char", new XAttribute("nom", "capacite"), textBoxCapacRaciales.Text),
                       new XElement("char", new XAttribute("nom", "langues"), textBoxLangues.Text)
                       ),
                       new XElement("defense", new XElement("bouclier", textBoxValeurBouclier.Text),
                       new XElement("armure", textBoxValeurArmure.Text)
                       ),
                       new XElement("armes", new XElement("arme", new XAttribute("nom", textBoxArme1.Text), new XElement("attaque", textBoxAttaque1.Text),
                       new XElement("dommages", textBoxDM1.Text),
                       new XElement("special", textBoxSpecial1.Text)
                       ),
                       new XElement("arme", new XAttribute("nom", textBoxArme2.Text), new XElement("attaque", textBoxAttaque1.Text),
                       new XElement("dommages", textBoxDM2.Text),
                       new XElement("special", textBoxSpecial2.Text)
                       ), 
                       new XElement("arme", new XAttribute("nom", textBoxArme3.Text), new XElement("attaque", textBoxAttaque3.Text),
                       new XElement("dommages", textBoxDM3.Text),
                       new XElement("special", textBoxSpecial3.Text)
                       ),
                       new XElement("equipement", textBoxEquipement.Text)
                       )
                       //new XElement("voies", new XElement("voie", new XAttribute("id", "="+1), new XAttribute("nom", "="+"")  on saute ça pour le moment
                       );

            doc.Element("personnages").Add(racine);
            doc.Save("..\\..\\DataBase.xml");
            dataGridPerso_Initialized(sender, e);
        }

        private void dataGridPersoCtrl_Initialized(object sender, EventArgs e)
        {
            dataGridPersoCtrl.ItemsSource = personnages;
        }

        private void buttonParcourirCtrl_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "jpeg";
            openFile.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                Uri fileUri = new Uri(openFile.FileName);
                imageCarte.Source = new BitmapImage(fileUri);
            }
        } //change la photo de profil en ouvrant une fenêtre de fichiers
    }
}
