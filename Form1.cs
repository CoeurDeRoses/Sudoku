using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IntialiserGrille();
        }

        /* Tout d'abord il faut remplir la grille
         * Chaque case sera initaliser à l'aide d'un code de génération de nombre aléatoire
         * Un code pour laisser certaines cases vides aléatoirement sera aussi fait
         * 
         * Dans un sudoku le chiffre doit être identique a sa ligne, sa colonne et sa région
         * Un tableau pour chaque ligne sera fait, de chaque colonne et de chaque région
         * 9+9+9 27 tableaux.
         */

        TextBox[][] Trois;
        // Un seul super tableau sera nécessaire
        // pour les vérifications dans la boucle
        private void IntialiserGrille()
        {
            /**** Lignes ***/
            TextBox[] Ligne1 = { textBox1, textBox2, textBox3,
                                textBox18,textBox17,textBox16,
                                textBox27,textBox26,textBox25};

            TextBox[] Ligne2 = { textBox4, textBox5, textBox6,
                                textBox15,textBox14,textBox13,
                                textBox24,textBox23,textBox22};

            TextBox[] Ligne3 = { textBox9, textBox8, textBox7,
                                textBox12,textBox11,textBox10,
                                textBox21,textBox20,textBox19};

            TextBox[] Ligne4 = { textBox54, textBox53, textBox52,
                                textBox45,textBox44,textBox43,
                                textBox36,textBox35,textBox34};

            TextBox[] Ligne5 = { textBox51, textBox50, textBox49,
                                textBox42,textBox41,textBox40,
                                textBox33,textBox32,textBox31};

            TextBox[] Ligne6 = { textBox48, textBox47, textBox46,
                                textBox39,textBox38,textBox37,
                                textBox30,textBox29,textBox28};

            TextBox[] Ligne7 = { textBox81, textBox80, textBox79,
                                textBox72,textBox71,textBox70,
                                textBox63,textBox62,textBox61};

            TextBox[] Ligne8 = { textBox78, textBox77, textBox76,
                                textBox69,textBox68,textBox67,
                                textBox60,textBox59,textBox58};

            TextBox[] Ligne9 = { textBox75, textBox74, textBox73,
                                textBox66,textBox65,textBox64,
                                textBox57,textBox56,textBox55};

            /**** Colonnes ***/

            TextBox[] Colonne1 = { textBox1, textBox4, textBox9,
                                textBox54,textBox51,textBox48,
                                textBox81,textBox78,textBox75};

            TextBox[] Colonne2 = { textBox2, textBox5, textBox8,
                                textBox53,textBox50,textBox47,
                                textBox80,textBox77,textBox74};

            TextBox[] Colonne3 = { textBox3, textBox6, textBox7,
                                textBox52,textBox49,textBox46,
                                textBox79,textBox76,textBox73};

            TextBox[] Colonne4 = { textBox18, textBox15, textBox12,
                                textBox45,textBox42,textBox39,
                                textBox72,textBox69,textBox66};

            TextBox[] Colonne5 = { textBox17, textBox14, textBox11,
                                textBox44,textBox41,textBox38,
                                textBox71,textBox68,textBox65};

            TextBox[] Colonn6 = { textBox16, textBox13, textBox10,
                                textBox43,textBox40,textBox37,
                                textBox70,textBox67,textBox64};

            TextBox[] Colonne7 = { textBox27, textBox24, textBox21,
                                textBox36,textBox33,textBox30,
                                textBox63,textBox60,textBox57};

            TextBox[] Colonne8 = { textBox26, textBox23, textBox20,
                                textBox35,textBox32,textBox29,
                                textBox62,textBox59,textBox56};

            TextBox[] Colonne9 = { textBox25, textBox22, textBox19,
                                textBox34,textBox31,textBox28,
                                textBox61,textBox58,textBox55};

            /*** Les régions ****/

            TextBox[] Region1 = { textBox1, textBox2, textBox3,
                                textBox4,textBox5,textBox6,
                                textBox7,textBox8,textBox9};

            TextBox[] Region2 = { textBox10, textBox11, textBox12,
                                textBox13,textBox14,textBox15,
                                textBox16,textBox17,textBox18};

            TextBox[] Region3 = { textBox19, textBox20, textBox21,
                                textBox22,textBox23,textBox24,
                                textBox25,textBox26,textBox27};

            TextBox[] Region4 = { textBox28, textBox29, textBox30,
                                textBox31,textBox32,textBox33,
                                textBox34,textBox35,textBox36};

            TextBox[] Region5 = { textBox37, textBox38, textBox39,
                                textBox40,textBox41,textBox42,
                                textBox43,textBox44,textBox45};

            TextBox[] Region6 = { textBox46, textBox47, textBox48,
                                textBox49,textBox50,textBox51,
                                textBox52,textBox53,textBox54};

            TextBox[] Region7 = { textBox55, textBox56, textBox57,
                                textBox58,textBox59,textBox60,
                                textBox61,textBox62,textBox63};

            TextBox[] Region8 = { textBox64, textBox65, textBox66,
                                textBox67,textBox68,textBox69,
                                textBox70,textBox71,textBox72};

            TextBox[] Region9 = { textBox73, textBox74, textBox75,
                                textBox76,textBox77,textBox78,
                                textBox79,textBox80,textBox81};

            // Ensuite on regroupe tout les tableaux ensembles.

            TextBox[][] TroisCopie = { Ligne1,Ligne2,Ligne3,Ligne4,Ligne5,Ligne6,Ligne7,Ligne8,Ligne9
                                      ,Colonne1,Colonne2,Colonne3,Colonne4,Colonne5,Colonn6,Colonne7,Colonne8,Colonne9
                                      ,Region1,Region2,Region3,Region4,Region5,Region6,Region7,Region8,Region9};


            Trois = TroisCopie;
            /*
             * Dans la boucle pour déterminer si un chiffre est unique à une colonne, une ligne et une région
             * Il suffit tout simplement de vérifier si il n'est pas présent deux fois dans le même tableau
             * Pour l'instant ici on se contente de génerer des nombres pour initaliser le tableau
             */

            Random aleatoire = new Random();
            /*
             * Le Sudoku ne se joue qu'avec 9 chiffres mais pour le moment
             * je n'exclue pas le zero, je m'explique à la suite
             */
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Trois[i][j].Text = aleatoire.Next(1, 9).ToString();
                }
            }

            // A ce stade toutes les cases sont remplies avec des doublons
            /* Pour préparer une grille on va d'abord ignorer les doublons
             * Pour y laisser un blanc à la place, cela intentionellement et de manière aléatoire aussi
             * pour permettre à l'utilisateur de jouer... oui je me base sur ces probabilités de doublons
             * pour avoir du vide dans la grille de cette manière :P XD PTDR MDR LOOOL
             */
            // la variable suivante sera nécessaire pour trouver les doublons

            int nombreDeFois = 0;
            for (int a = 0; a < 27; a++)// On parcours chaque tableau
            {
                for (int j = 1; j < 10; j++)// A chaque tour un chiffre est testé
                {
                    for (int i = 0; i < 9; i++)// On test pour savoir si le même chiffre est présent plusieurs fois
                                               // Sur le même tableau
                    {
                        if (Trois[a][i].Text == j.ToString())
                        {
                            nombreDeFois += 1;
                        }

                        if (Trois[a][i].Text == j.ToString() && nombreDeFois > 1)
                        {

                            Trois[a][i].Text = "";
                        }
                    }
                    nombreDeFois = 0;
                }
            }
        }

        //Nouvelle Grille
        private void button2_Click(object sender, EventArgs e)
        {
            IntialiserGrille();
        }

        // Cette fonction va nous permettre de voir si les entrée sont différents des chiffres
        private bool ChiffresONLY()
        {
            bool chiffreOnly = true;
            // on fera un test de conversion de la châine
            try
            {
                int nb = 0;
                foreach (TextBox[] tableau in Trois)
                {
                    foreach (TextBox unText in tableau)
                    {
                        nb = Convert.ToInt16(unText.Text);// On remets les cases au noir
                    }
                }
            }

            catch(Exception)
            {
                chiffreOnly = false;
                
            }
            return chiffreOnly;
        }
    

        //Bouton Valider
        private void button1_Click(object sender, EventArgs e)
        {

            bool aucuneChaineVide = true;
            bool erreur = false;
            //Ce boolean va faire en sorte d'indiquer si ou ou non la grille est bonne

            //On parcours le tableau pour vérifiez si nous avons une entrée
            // Tant qu'on rencontre une chaine vide, le code de vérification ne sera pas executer
            // Si toutes les cases sont remplis on active le bouton Valider
            
                    foreach(TextBox[] Tableau in Trois )
                    {
                        foreach(TextBox unTexte in Tableau)
                        {
                            if(unTexte.Text == "" && !ChiffresONLY())
                            {
                                aucuneChaineVide = false;
                            }
                        }
                    }

                       if(aucuneChaineVide== false)
                    {
                        label1.Text = "Remplissez toutes les cases avant de valider";
                    }

             if(!ChiffresONLY() && aucuneChaineVide)// et aucuneChaineVideSinon vrai sinon le code s'applique aussi 
                // Même quand la grille est incomplète
            {
                MessageBox.Show("Ne mettez que des chiffres dans la grille");
            }
            

            if (aucuneChaineVide == true && ChiffresONLY())
                    {
                        int nombreDeFois = 0;
                        for (int a = 0; a < 27; a++)// On parcours chaque tableau
                        {
                            for (int j = 1; j < 10; j++)// A chaque tour un chiffre est testé
                            {
                                for (int i = 0; i < 9; i++)// On test pour savoir si le même chiffre est présent plusieurs fois
                                                           // Sur le même tableau
                                {
                                    if (Trois[a][i].Text == j.ToString())
                                    {
                                        nombreDeFois += 1;
                                    }

                                    if (Trois[a][i].Text == j.ToString() && nombreDeFois > 1)
                                    {

                                        Trois[a][i].ForeColor = Color.Red;
                                        erreur = true;
                                    }
                                }
                                nombreDeFois = 0;
                            }

                        }


                        if(erreur==true)
                        {
                            button1.Visible = false;// Le bouton validation disaparait
                            button3.Visible = true;// On affiche le bouton verif terminée

                            label1.Text = "Votre grille est mauvaise. Reverifiez minutieusement.";
                            label3.Text = "Si vous avez finis votre correction cliquez sur Verification terminée" +
                                "pour enlever le rouge. le bouton valider reviendra";
                        }

                        else
                        {
                            label1.Text = "Votre grille est bonne";
                        }
                    }

            
        }

        //Verification terminée
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button1.Visible = true; // Le bouton valide redevient visible
            foreach(TextBox [] tableau in Trois)
            {
                foreach(TextBox unText in tableau)
                {
                    unText.ForeColor = Color.Black; // On remets les cases au noir
                }
            }
        }
    }
    
}
