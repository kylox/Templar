using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Templar
{
    public class textbox
    {
        public Rectangle Fenetre;
        string saisie = "";
        KeyboardState keyboard;
        KeyboardState oldkeyboard;
        int timer;
        Vector2 position_curseur;
        bool is_shown;
        char remove;

        public bool Is_shown
        {
            get { return is_shown; }
            set { is_shown = value; }
        }

        public string Saisie
        {
            get { return saisie; }
            set { saisie = value; }
        }

        public textbox(Rectangle fenetre)
        {
            Fenetre = fenetre;
            is_shown = false;
            timer = 0;
            position_curseur = new Vector2(fenetre.X + 7, fenetre.Y + 7);
        }
        public Vector2 taille_charactere(char c)
        {
            return ressource.ecriture.MeasureString(Convert.ToString(c));
        }
        public void update()
        {
            oldkeyboard = keyboard;
            keyboard = Keyboard.GetState();
            timer++;
            if (is_shown)
                if (keyboard.GetPressedKeys().Length != 0 && timer > 6)
                {
                    switch (keyboard.GetPressedKeys().First())
                    {
                        case Keys.Enter:
                            saisie += '\n';
                            position_curseur.Y += ressource.ecriture.LineSpacing;
                            position_curseur.X = Fenetre.X + 7;
                            break;
                        case Keys.NumPad0:
                            saisie += '0';
                            position_curseur.X += ressource.ecriture.MeasureString("0").X;
                            break;
                        case Keys.NumPad1:
                            saisie += '1';
                            position_curseur.X += ressource.ecriture.MeasureString("1").X;
                            break;
                        case Keys.NumPad2:
                            saisie += '2';
                            position_curseur.X += ressource.ecriture.MeasureString("2").X;
                            break;
                        case Keys.NumPad3:
                            saisie += '3';
                            position_curseur.X += ressource.ecriture.MeasureString("3").X;
                            break;
                        case Keys.NumPad4:
                            saisie += '4';
                            position_curseur.X += ressource.ecriture.MeasureString("4").X;
                            break;
                        case Keys.NumPad5:
                            saisie += '5';
                            position_curseur.X += ressource.ecriture.MeasureString("5").X;
                            break;
                        case Keys.NumPad6:
                            saisie += '6';
                            position_curseur.X += ressource.ecriture.MeasureString("6").X;
                            break;
                        case Keys.NumPad7:
                            saisie += '7';
                            position_curseur.X += ressource.ecriture.MeasureString("7").X;
                            break;
                        case Keys.NumPad8:
                            saisie += '8';
                            position_curseur.X += ressource.ecriture.MeasureString("8").X;
                            break;
                        case Keys.NumPad9:
                            saisie += '9';
                            position_curseur.X += ressource.ecriture.MeasureString("9").X;
                            break;
                        case Keys.D1:
                            saisie += '1';
                            position_curseur.X += ressource.ecriture.MeasureString("1").X;
                            break;
                        case Keys.D2:
                            saisie += '2';
                            position_curseur.X += ressource.ecriture.MeasureString("2").X;
                            break;
                        case Keys.D3:
                            saisie += '3';
                            position_curseur.X += ressource.ecriture.MeasureString("3").X;
                            break;
                        case Keys.D4:
                            saisie += '4';
                            position_curseur.X += ressource.ecriture.MeasureString("4").X;
                            break;
                        case Keys.D5:
                            saisie += '5';
                            position_curseur.X += ressource.ecriture.MeasureString("5").X;
                            break;
                        case Keys.D6:
                            saisie += '6';
                            position_curseur.X += ressource.ecriture.MeasureString("6").X;
                            break;
                        case Keys.D7:
                            saisie += '7';
                            position_curseur.X += ressource.ecriture.MeasureString("7").X;
                            break;
                        case Keys.D8:
                            saisie += '8';
                            position_curseur.X += ressource.ecriture.MeasureString("8").X;
                            break;
                        case Keys.D9:
                            saisie += '9';
                            position_curseur.X += ressource.ecriture.MeasureString("9").X;
                            break;
                        case Keys.D0:
                            saisie += '0';
                            position_curseur.X += ressource.ecriture.MeasureString("0").X;
                            break;
                        case Keys.Decimal:
                            saisie += '.';
                            position_curseur.X += ressource.ecriture.MeasureString(".").X;
                            break;
                        case Keys.LeftShift:
                            if (keyboard.GetPressedKeys() == new Keys[] { Keys.LeftShift, Keys.A })
                                saisie += 'A';
                            break;
                        case Keys.A:
                            saisie += 'a';
                            position_curseur.X += ressource.ecriture.MeasureString("a").X;
                            break;
                        case Keys.Z:
                            saisie += 'z';
                            position_curseur.X += ressource.ecriture.MeasureString("z").X;
                            break;
                        case Keys.E:
                            saisie += 'e';
                            position_curseur.X += ressource.ecriture.MeasureString("e").X;
                            break;
                        case Keys.R:
                            saisie += 'r';
                            position_curseur.X += ressource.ecriture.MeasureString("r").X;
                            break;
                        case Keys.T:
                            saisie += 't';
                            position_curseur.X += ressource.ecriture.MeasureString("t").X;
                            break;
                        case Keys.Y:
                            saisie += 'y';
                            position_curseur.X += ressource.ecriture.MeasureString("y").X;
                            break;
                        case Keys.U:
                            saisie += 'u';
                            position_curseur.X += ressource.ecriture.MeasureString("u").X;
                            break;
                        case Keys.I:
                            saisie += 'i';
                            position_curseur.X += ressource.ecriture.MeasureString("i").X;
                            break;
                        case Keys.O:
                            saisie += 'o';
                            position_curseur.X += ressource.ecriture.MeasureString("o").X;
                            break;
                        case Keys.P:
                            saisie += 'p';
                            position_curseur.X += ressource.ecriture.MeasureString("p").X;
                            break;
                        case Keys.Q:
                            saisie += 'q';
                            position_curseur.X += ressource.ecriture.MeasureString("q").X;
                            break;
                        case Keys.S:
                            saisie += 's';
                            position_curseur.X += ressource.ecriture.MeasureString("s").X;
                            break;
                        case Keys.D:
                            saisie += 'd';
                            position_curseur.X += ressource.ecriture.MeasureString("d").X;
                            break;
                        case Keys.F:
                            saisie += 'f';
                            position_curseur.X += ressource.ecriture.MeasureString("f").X;
                            break;
                        case Keys.G:
                            saisie += 'g';
                            position_curseur.X += ressource.ecriture.MeasureString("g").X;
                            break;
                        case Keys.H:
                            saisie += 'h';
                            position_curseur.X += ressource.ecriture.MeasureString("h").X;
                            break;
                        case Keys.J:
                            saisie += 'j';
                            position_curseur.X += ressource.ecriture.MeasureString("j").X;
                            break;
                        case Keys.K:
                            saisie += 'k';
                            position_curseur.X += ressource.ecriture.MeasureString("k").X;
                            break;
                        case Keys.L:
                            saisie += 'l';
                            position_curseur.X += ressource.ecriture.MeasureString("l").X;
                            break;
                        case Keys.M:
                            saisie += 'm';
                            position_curseur.X += ressource.ecriture.MeasureString("m").X;
                            break;
                        case Keys.W:
                            saisie += 'w';
                            position_curseur.X += ressource.ecriture.MeasureString("w").X;
                            break;
                        case Keys.X:
                            saisie += 'x';
                            position_curseur.X += ressource.ecriture.MeasureString("x").X;
                            break;
                        case Keys.C:
                            saisie += 'c';
                            position_curseur.X += ressource.ecriture.MeasureString("c").X;
                            break;
                        case Keys.V:
                            saisie += 'v';
                            position_curseur.X += ressource.ecriture.MeasureString("v").X;
                            break;
                        case Keys.B:
                            saisie += 'b';
                            position_curseur.X += ressource.ecriture.MeasureString("b").X;
                            break;
                        case Keys.N:
                            saisie += 'n';
                            position_curseur.X += ressource.ecriture.MeasureString("n").X;
                            break;
                        case Keys.Space:
                            saisie += ' ';
                            position_curseur.X += ressource.ecriture.MeasureString(" ").X;
                            break;
                        case Keys.Back:
                            if (saisie.Length != 0)
                            {
                                remove = saisie.Last();
                                saisie = saisie.Remove(saisie.Length - 1);
                                if (position_curseur.X <= Fenetre.X + 7)
                                    if (remove == '\n')
                                        if (saisie.Length == 0)
                                            position_curseur = new Vector2(Fenetre.X + 7, Fenetre.Y + 7);
                                        else
                                            if (saisie.Last() == '\n')
                                            {
                                                position_curseur.Y -= ressource.ecriture.LineSpacing;
                                                position_curseur.X = Fenetre.X + 7;
                                            }
                                            else
                                            {
                                                position_curseur.Y -= ressource.ecriture.LineSpacing;
                                                position_curseur.X = Fenetre.X + 6 + ressource.ecriture.MeasureString(saisie).X;
                                            }
                                    else
                                    {
                                        position_curseur.Y -= ressource.ecriture.LineSpacing;
                                        position_curseur.X = Fenetre.X + 7 + ressource.ecriture.MeasureString(saisie).X;
                                    }
                                else
                                    position_curseur.X -= taille_charactere(remove).X;
                            }
                            break;
                    }
                    if (ressource.ecriture.MeasureString(saisie).X > Fenetre.Width)
                        for (int i = saisie.Length - 1; i > 0; i--)
                            if (saisie[i] == ' ')
                            {
                                string S1 = "";
                                for (int j = 0; j < i + 1; j++)
                                    S1 += saisie[j];
                                string S2 = "";
                                for (int j = i + 1; j < saisie.Length; j++)
                                    S2 += saisie[j];
                                saisie = S1 + "\n" + S2;
                                position_curseur.X = Fenetre.X + 7 + ressource.ecriture.MeasureString(S2).X;
                                position_curseur.Y += ressource.ecriture.LineSpacing;
                                break;
                            }
                            else
                                if (i == 1)
                                {
                                    string S1 = "";
                                    for (int j = 0; j < saisie.Length - 2; j++)
                                        S1 += saisie[j];
                                    string S2 = "";
                                    for (int j = saisie.Length - 2; j < saisie.Length; j++)
                                        S2 += saisie[j];
                                    saisie = S1 + "\n" + S2;
                                    position_curseur.X = Fenetre.X + 7 + ressource.ecriture.MeasureString(S2).X;
                                    position_curseur.Y += ressource.ecriture.LineSpacing;
                                    break;
                                }

                    if (ressource.ecriture.MeasureString(saisie).Y > Fenetre.Height)
                        Fenetre.Height += ressource.ecriture.LineSpacing * 2;

                    timer = 0;
                }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            Color couleurfenetre = Color.Black;
            couleurfenetre.A = 100;
            if (is_shown == true)
            {
                spritebatch.Draw(ressource.pixel, new Rectangle(Fenetre.X - 3, Fenetre.Y - 3, 3, Fenetre.Height + 3), Color.Gray);
                spritebatch.Draw(ressource.pixel, new Rectangle(Fenetre.X - 3, Fenetre.Y - 3, Fenetre.Width + 6, 3), Color.Gray);
                spritebatch.Draw(ressource.pixel, new Rectangle(Fenetre.X - 3, Fenetre.Height + Fenetre.Y, Fenetre.Width + 3, 3), Color.Gray);
                spritebatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width + Fenetre.X, Fenetre.Y, 3, Fenetre.Height + 3), Color.Gray);
                spritebatch.Draw(ressource.pixel, Fenetre, couleurfenetre);
                spritebatch.DrawString(ressource.ecriture, saisie, new Vector2(Fenetre.X + 5, Fenetre.Y + 5), Color.White);
                spritebatch.Draw(ressource.pixel, new Rectangle((int)position_curseur.X, (int)position_curseur.Y, 2, ressource.ecriture.LineSpacing), Color.White);
            }
        }
    }
}