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
            XmlReaderSettings settings = new XmlReaderSettings(); //Lis la DB des races et rajoute les différentes races au combo box des races.
            settings.IgnoreWhitespace = true;
            using (XmlReader readerRace = XmlReader.Create("DBRaces.xml", settings))
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
            using (XmlReader readerProfil = XmlReader.Create("DBProfils.xml", settings))
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
            using (XmlReader readerRace = XmlReader.Create("DBRaces.xml", settings))
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
            using (XmlReader readerProfil = XmlReader.Create("DBProfils.xml", settings))
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
                        Equipement.Add(readerProfil.Value);
                        readerProfil.Read();
                        textBoxValeurBouclier.Text = readerProfil.Value;

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
                            innerVoies.MoveToNextAttribute();
                            if (innerVoies.MoveToNextAttribute() == false) break;
                            string nomVoie = innerVoies.Value;

                            innerVoies.ReadToFollowing("rangs");
                            XmlReader innerRangs = readerProfil.ReadSubtree();
                            List<Rang> rangs = new List<Rang>();
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
                                Rang rang = new Rang() { Id = idRang, Description = descriptionRang, Titre = nomRang };
                                rangs.Add(rang);
                            }
                            innerRangs.Close();
                            Voie voie = new Voie() { Nom = nomVoie, Rang1 = rangs[0], Rang2 = rangs[1], Rang3 = rangs[2], Rang4 = rangs[3], Rang5 = rangs[4] };
                            voies.Add(voie);
                        }
                        while (innerVoies.Read());
                        innerVoies.Close();
                        dataGridCompétences.ItemsSource = voies;
                    }
                }
            }
        }
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
        }

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
        }
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
        }
    }
}
