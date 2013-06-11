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

        bool is_shown;

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
        }

        public void update()
        {
            oldkeyboard = keyboard;
            keyboard = Keyboard.GetState();
            timer++;
            if (is_shown)
                if (keyboard.GetPressedKeys().Length != 0 && timer > 7)
                {
                    switch (keyboard.GetPressedKeys().First())
                    {
                        case Keys.Enter :
                            saisie += '\n';
                            break;
                        case Keys.NumPad0:
                            saisie += '0';
                            break;
                        case Keys.NumPad1:
                            saisie += '1';
                            break;
                        case Keys.NumPad2:
                            saisie += '2';
                            break;
                        case Keys.NumPad3:
                            saisie += '3';
                            break;
                        case Keys.NumPad4:
                            saisie += '4';
                            break;
                        case Keys.NumPad5:
                            saisie += '5';
                            break;
                        case Keys.NumPad6:
                            saisie += '6';
                            break;
                        case Keys.NumPad7:
                            saisie += '7';
                            break;
                        case Keys.NumPad8:
                            saisie += '8';
                            break;
                        case Keys.NumPad9:
                            saisie += '9';
                            break;
                        case Keys.D1:
                            saisie += '1';
                            break;
                        case Keys.D2:
                            saisie += '2';
                            break;
                        case Keys.D3:
                            saisie += '3';
                            break;
                        case Keys.D4:
                            saisie += '4';
                            break;
                        case Keys.D5:
                            saisie += '5';
                            break;
                        case Keys.D6:
                            saisie += '6';
                            break;
                        case Keys.D7:
                            saisie += '7';
                            break;
                        case Keys.D8:
                            saisie += '8';
                            break;
                        case Keys.D9:
                            saisie += '9';
                            break;
                        case Keys.D0:
                            saisie += '0';
                            break;
                        case Keys.Decimal:
                            saisie += '.';
                            break;
                        case Keys.LeftShift:
                            if (keyboard.GetPressedKeys() == new Keys[]{Keys.LeftShift, Keys.A})
                                saisie += 'A';
                            break;
                        case Keys.A:
                            saisie += 'a';
                            break;
                        case Keys.Z:
                            saisie += 'z';
                            break;
                        case Keys.E:
                            saisie += 'e';
                            break;
                        case Keys.R:
                            saisie += 'r';
                            break;
                        case Keys.T:
                            saisie += 't';
                            break;
                        case Keys.Y:
                            saisie += 'y';
                            break;
                        case Keys.U:
                            saisie += 'u';
                            break;
                        case Keys.I:
                            saisie += 'i';
                            break;
                        case Keys.O:
                            saisie += 'o';
                            break;
                        case Keys.P:
                            saisie += 'p';
                            break;
                        case Keys.Q:
                            saisie += 'q';
                            break;
                        case Keys.S:
                            saisie += 's';
                            break;
                        case Keys.D:
                            saisie += 'd';
                            break;
                        case Keys.F:
                            saisie += 'f';
                            break;
                        case Keys.G:
                            saisie += 'g';
                            break;
                        case Keys.H:
                            saisie += 'h';
                            break;
                        case Keys.J:
                            saisie += 'j';
                            break;
                        case Keys.K:
                            saisie += 'k';
                            break;
                        case Keys.L:
                            saisie += 'l';
                            break;
                        case Keys.M:
                            saisie += 'm';
                            break;
                        case Keys.W:
                            saisie += 'w';
                            break;
                        case Keys.X:
                            saisie += 'x';
                            break;
                        case Keys.C:
                            saisie += 'c';
                            break;
                        case Keys.V:
                            saisie += 'v';
                            break;
                        case Keys.B:
                            saisie += 'b';
                            break;
                        case Keys.N:
                            saisie += 'n';
                            break;
                        case Keys.Space:
                            saisie += ' ';
                            break;
                        case Keys.Back:
                            if (saisie.Length != 0)
                                saisie = saisie.Remove(saisie.Length - 1);
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
                                break;
                            }
                            else
                                if (i == 1)
                                {
                                    string S1 = "";
                                    for (int j = 0; j < saisie.Length - 3; j++)
                                        S1 += saisie[j];
                                    string S2 = "";
                                    for (int j = saisie.Length - 3; j < saisie.Length; j++)
                                        S2 += saisie[j];
                                    saisie = S1 + "\n" + S2;
                                    break;
                                }

                    if (ressource.ecriture.MeasureString(saisie).Y > Fenetre.Height)
                        Fenetre.Height += ressource.ecriture.LineSpacing*2;
                   
                    timer = 0;
                }

            if (keyboard.IsKeyDown(Keys.F1) && oldkeyboard.IsKeyUp(Keys.F1))
                is_shown = !is_shown;
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
            }

        }
    }
}