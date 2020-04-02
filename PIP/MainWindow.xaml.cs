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
using System.Windows.Media.Animation;


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

        private void modifValeurMod(TextBox textBoxValeur, TextBox textBoxMod)
        {
            string[] valeurs = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
            for (int i = 0; i < 20; i++)
            {
                if (textBoxValeur.Text != valeurs[i])
                {
                    textBoxMod.Text = "ERR.";
                    break;
                }
            }
            if (textBoxValeur.Text == "1" || textBoxValeur.Text == "2" || textBoxValeur.Text == "3")
            {
                textBoxMod.Text = "-4";
            }
            if (textBoxValeur.Text == "4" || textBoxValeur.Text == "5")
            {
                textBoxMod.Text = "-3";
            }
            if (textBoxValeur.Text == "6" || textBoxValeur.Text == "7")
            {
                textBoxMod.Text = "-2";
            }
            if (textBoxValeur.Text == "8" || textBoxValeur.Text == "9")
            {
                textBoxMod.Text = "-1";
            }
            if (textBoxValeur.Text == "10" || textBoxValeur.Text == "11")
            {
                textBoxMod.Text = "0";
            }
            if (textBoxValeur.Text == "12" || textBoxValeur.Text == "13")
            {
                textBoxMod.Text = "+1";
            }
            if (textBoxValeur.Text == "14" || textBoxValeur.Text == "15")
            {
                textBoxMod.Text = "+2";
            }
            if (textBoxValeur.Text == "16" || textBoxValeur.Text == "17")
            {
                textBoxMod.Text = "+3";
            }
            if (textBoxValeur.Text == "18" || textBoxValeur.Text == "19")
            {
                textBoxMod.Text = "+4";
            }
            if (textBoxValeur.Text == "20" || textBoxValeur.Text == "21")
            {
                textBoxMod.Text = "+5";
            }
        }

        private void textBoxValeurFor_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurFor, textBoxModFor);
        }  //Si la valeur de force change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurDex_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurDex, textBoxModDex);
            textBoxValeurInit.Text = textBoxValeurDex.Text;
        } //Si la valeur de Dextérité change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurCon_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurCon, textBoxModCon);
        } //Si la valeur de Constitution change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurInt_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurInt, textBoxModInt);
        }//Si la valeur de Intelligence change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurSag_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurSag, textBoxModSag);
        }//Si la valeur de Sagesse change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurCha_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurCha, textBoxModCha);
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
                    elements.ElementAt(7).Value = textBoxValeurPtsVieActuel.Text;
                    elements.ElementAt(8).Value = textBoxCapacRaciales.Text;
                    elements.ElementAt(9).Value = textBoxLangues.Text;
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
                    readerPerso.ReadToFollowing("caractéristiques");
                    readerPerso.ReadToDescendant("char");
                    do
                    {
                        readerPerso.ReadToFollowing("char");
                        readerPerso.MoveToFirstAttribute();
                    }
                    while (readerPerso.Value != "PDV actuel");
                    readerPerso.Read();
                    string pdv = readerPerso.Value;
                    Personnage personnage = new Personnage() { Nom = nom, Niveau = niveau, Profil = profil, Race = race, Portrait = portrait, PDV = pdv };
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
                        textBoxValeurPtsVieActuel.Text = lePerso.PDV;
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
                        readerPerso.ReadToFollowing("char");
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
                       new XElement("char", new XAttribute("nom", "PDV actuel"), textBoxValeurPtsVie.Text),
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
        private void textBoxValeurForCtrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurForCtrl, textBoxModForCtrl);
        }  //Si la valeur de force change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurDexCtrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurDexCtrl, textBoxModDexCtrl);
            textBoxValeurInitCtrl.Text = textBoxValeurDexCtrl.Text;
        } //Si la valeur de Dextérité change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurConCtrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurConCtrl, textBoxModConCtrl);
        } //Si la valeur de Constitution change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurIntCtrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurIntCtrl, textBoxModIntCtrl);
        }//Si la valeur de Intelligence change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurSagCtrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurSagCtrl, textBoxModSagCtrl);
        }//Si la valeur de Sagesse change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante
        private void textBoxValeurChaCtrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            modifValeurMod(textBoxValeurChaCtrl, textBoxModChaCtrl);
        }//Si la valeur de Charisme change, alors on vérifie si celle-ci est correcte (entre 1 et 21) et si oui on modifie la valeur de la boite Mod correspondante

        private void dataGridPersoCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Personnage lePerso = dataGridPersoCtrl.SelectedItem as Personnage;
            dataGridPerso.SelectedItem = lePerso;
            textBoxValeurForCtrl.Text = textBoxValeurFor.Text;
            textBoxValeurDexCtrl.Text = textBoxValeurDex.Text;
            textBoxValeurConCtrl.Text = textBoxValeurCon.Text;
            textBoxValeurIntCtrl.Text = textBoxValeurInt.Text;
            textBoxValeurSagCtrl.Text = textBoxValeurSag.Text;
            textBoxValeurChaCtrl.Text = textBoxValeurCha.Text;
            textBoxTotalDefCtrl.Text = textBoxTotalDef.Text;
            textBoxValeurPtsVieCtrl.Text = textBoxValeurPtsVie.Text;
            textBoxValeurPtsVieActuelCtrl.Text = textBoxValeurPtsVieActuel.Text;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            Personnage lePerso = dataGridPersoCtrl.SelectedItem as Personnage;
            if (dataGridPersoCtrl.SelectedItem == lePerso && lePerso != null)
            {
                var bitmap = new BitmapImage(new Uri(lePerso.Portrait));
                var image = new Image { Source = bitmap };
                image.Height = 50;
                image.Width = 50; 
                image.Stretch = Stretch.Fill; 
                Canvas.SetLeft(image, 0);
                Canvas.SetTop(image, 0);
                canvas.Children.Add(image);
                comboBoxPerso1.Items.Add(lePerso.Nom);
                comboBoxPerso2.Items.Add(lePerso.Nom);
            }
            else MessageBox.Show("Sélectionnez d'abord un personnage dans la liste de droite", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private Image draggedImage;
        private Point mousePosition;

        private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = e.Source as Image;

            if (image != null && canvas.CaptureMouse())
            {
                mousePosition = e.GetPosition(canvas);
                draggedImage = image;
                Panel.SetZIndex(draggedImage, 1); // en cas de plusieurs images
            }
        }

        private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedImage != null)
            {
                canvas.ReleaseMouseCapture();
                Panel.SetZIndex(draggedImage, 0);
                draggedImage = null;
            }
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (draggedImage != null)
            {
                var position = e.GetPosition(canvas);
                var offset = position - mousePosition;
                mousePosition = position;

                double canvasTop = 470;
                double canvasLeft = 746;

                double newLeft = Canvas.GetLeft(draggedImage) + offset.X;
                double newTop = Canvas.GetTop(draggedImage) + offset.Y;

                if (newLeft < 0)
                    newLeft = 0;
                else if (newLeft + draggedImage.ActualWidth > canvasLeft)
                    newLeft = canvasLeft - draggedImage.ActualWidth;

                if (newTop < 0)
                    newTop = 0;
                else if (newTop + draggedImage.ActualHeight > canvasTop)
                    newTop = canvasTop - draggedImage.ActualHeight;

                Canvas.SetLeft(draggedImage, newLeft);
                Canvas.SetTop(draggedImage, newTop);
            }
        }

        private void comboBoxPerso1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Personnage lePerso = null;
            foreach (Personnage perso in personnages)
            {
                if (comboBoxPerso1.SelectedItem.ToString() == perso.Nom) lePerso = perso;
            }
            dataGridPersoCtrl.SelectedItem = lePerso;
            var bitmap = new BitmapImage(new Uri(lePerso.Portrait));
            imagePerso1.Source = bitmap;
        }

        private void comboBoxPerso2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Personnage lePerso = null;
            foreach (Personnage perso in personnages)
            {
                if (comboBoxPerso2.SelectedItem.ToString() == perso.Nom) lePerso = perso;
            }
            dataGridPersoCtrl.SelectedItem = lePerso;
            textBoxValeurDéfense.Text = textBoxTotalDef.Text;
            var bitmap = new BitmapImage(new Uri(lePerso.Portrait));
            imagePerso2.Source = bitmap;
        }

        private void textBoxValeurPtsVieActuelCtrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            Personnage lePerso = dataGridPerso.SelectedItem as Personnage;
            XDocument doc = XDocument.Load("..\\..\\DataBase.xml");
            foreach (XElement element in doc.Descendants("joueur"))
            {
                if (lePerso != null && element.Descendants("nom").First().Value == lePerso.Nom)
                {
                    foreach (XElement element2 in element.Descendants("char"))
                    {
                        if (element2.FirstAttribute.Value == "PDV actuel")
                        {
                            element2.Value = textBoxValeurPtsVieActuelCtrl.Text;
                            lePerso.PDV = textBoxValeurPtsVieActuelCtrl.Text;
                            break;
                        }
                    }
                    break;
                }
            }
            doc.Save("..\\..\\DataBase.xml");
        }

        private void buttonResoudreCombat_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPerso1.SelectedItem == null)
            {
                MessageBox.Show("Sélectionnez d'abord un personnage dans liste \"Attaquant\"", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(comboBoxPerso2.SelectedItem == null)
            {
                MessageBox.Show("Sélectionnez d'abord un personnage dans liste \"Défenseur\"", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(textBoxValeurAttaque.Text == "")
            {
                MessageBox.Show("Remplissez d'abord la case \"Valeur d'attaque\"", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(textBoxValeurDegats.Text == "")
            {
                MessageBox.Show("Remplissez d'abord la case \"Dégats portés\"", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(int.Parse(textBoxValeurAttaque.Text) < int.Parse(textBoxValeurDéfense.Text))
            {
                textBoxLogCombat.Text += "\nLa valeur d'armure de " + comboBoxPerso2.SelectedItem.ToString() + " est supérieure à la valeur d'attaque de " + comboBoxPerso1.SelectedItem.ToString() + ", les dégats n'ont pas été appliqués.";
            }
            if (int.Parse(textBoxValeurAttaque.Text) >= int.Parse(textBoxValeurDéfense.Text))
            {
                Personnage lePerso = null;
                foreach (Personnage perso in personnages)
                {
                    if (comboBoxPerso2.SelectedItem.ToString() == perso.Nom)
                    {
                        lePerso = perso;
                        break;
                    }
                }
                if (int.Parse(lePerso.PDV) - int.Parse(textBoxValeurDegats.Text) > 0)
                {
                    textBoxLogCombat.Text += "\n" + comboBoxPerso2.SelectedItem.ToString() + " a subi " + textBoxValeurDegats.Text + " points de dégats, ses points de vie sont maintenant de " + (int.Parse(lePerso.PDV) - int.Parse(textBoxValeurDegats.Text)) + ".";
                    lePerso.PDV = (int.Parse(lePerso.PDV) - int.Parse(textBoxValeurDegats.Text)).ToString();
                    dataGridPersoCtrl.SelectedItem = lePerso;
                    textBoxValeurPtsVieActuelCtrl.Text = lePerso.PDV;
                }
                else
                {
                    textBoxLogCombat.Text += "\n" + comboBoxPerso2.SelectedItem.ToString() + " a subi " + textBoxValeurDegats.Text + " points de dégats. " + comboBoxPerso2.SelectedItem.ToString() + " est mort.";
                    lePerso.PDV = "0";
                    dataGridPersoCtrl.SelectedItem = lePerso;
                    textBoxValeurPtsVieActuelCtrl.Text = lePerso.PDV;
                }
            }
        }
    }
}
