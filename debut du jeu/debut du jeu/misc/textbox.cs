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
        Keys[] prevPressedKeys;
        public Rectangle Fenetre;
        string saisie = "";
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
            position_curseur = new Vector2(fenetre.X + 7, fenetre.Y + 7);
        }
        public Vector2 taille_charactere(char c)
        {
            return ressource.ecriture.MeasureString(Convert.ToString(c));
        }
        public void update()
        {
            if (is_shown)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                Keys[] pressedKeys = keyboardState.GetPressedKeys();
                bool shiftPressed;
                shiftPressed = keyboardState.IsKeyDown(Keys.LeftShift) || keyboardState.IsKeyDown(Keys.RightShift);
                try
                {
                    foreach (Keys key in pressedKeys)
                    {
                        if (!prevPressedKeys.Contains(key))
                        {
                            #region no shift
                            if (!shiftPressed)
                            {
                                switch (key)
                                {
                                    case Keys.D1:
                                        saisie += '&';
                                        position_curseur.X += ressource.ecriture.MeasureString("&").X;
                                        break;
                                    case Keys.D2:
                                        saisie += 'é';
                                        position_curseur.X += ressource.ecriture.MeasureString("é").X;
                                        break;
                                    case Keys.D3:
                                        saisie += '"';
                                        position_curseur.X += ressource.ecriture.MeasureString("\"").X;
                                        break;
                                    case Keys.D4:
                                        saisie += '\'';
                                        position_curseur.X += ressource.ecriture.MeasureString("'").X;
                                        break;
                                    case Keys.D5:
                                        saisie += '(';
                                        position_curseur.X += ressource.ecriture.MeasureString("(").X;
                                        break;
                                    case Keys.D6:
                                        saisie += '-';
                                        position_curseur.X += ressource.ecriture.MeasureString("-").X;
                                        break;
                                    case Keys.D7:
                                        saisie += 'è';
                                        position_curseur.X += ressource.ecriture.MeasureString("è").X;
                                        break;
                                    case Keys.D8:
                                        saisie += '_';
                                        position_curseur.X += ressource.ecriture.MeasureString("_").X;
                                        break;
                                    case Keys.D9:
                                        saisie += 'ç';
                                        position_curseur.X += ressource.ecriture.MeasureString("ç").X;
                                        break;
                                    case Keys.D0:
                                        saisie += 'à';
                                        position_curseur.X += ressource.ecriture.MeasureString("à").X;
                                        break;
                                    case Keys.OemQuestion:
                                        saisie += ':';
                                        position_curseur.X += ressource.ecriture.MeasureString(":").X;
                                        break;
                                    case Keys.OemPipe:
                                        saisie += '*';
                                        position_curseur.X += ressource.ecriture.MeasureString("*").X;
                                        break;
                                    case Keys.OemOpenBrackets:
                                        saisie += ')';
                                        position_curseur.X += ressource.ecriture.MeasureString(")").X;
                                        break;
                                    case Keys.OemCloseBrackets:
                                        saisie += '^';
                                        position_curseur.X += ressource.ecriture.MeasureString("$").X;
                                        break;
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
                                    case Keys.Decimal:
                                        saisie += '.';
                                        position_curseur.X += ressource.ecriture.MeasureString(".").X;
                                        break;
                                }
                            }
                            #endregion
                            #region shift
                            else
                                switch (key)
                                {
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
                                    case Keys.OemQuestion:
                                        saisie += '/';
                                        position_curseur.X += ressource.ecriture.MeasureString("/").X;
                                        break;
                                    case Keys.OemPipe:
                                        saisie += 'µ';
                                        position_curseur.X += ressource.ecriture.MeasureString("µ").X;
                                        break;
                                    case Keys.OemOpenBrackets:
                                        saisie += '°';
                                        position_curseur.X += ressource.ecriture.MeasureString("°").X;
                                        break;
                                    case Keys.OemCloseBrackets:
                                        saisie += '¨';
                                        position_curseur.X += ressource.ecriture.MeasureString("£").X;
                                        break;
                                }
                            #endregion
                            #region back
                            if (key == Keys.Back)
                            {
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
                            }
                            #endregion
                            #region espace
                            else
                                if (key == Keys.Space)
                                {
                                    saisie += " ";
                                    position_curseur.X += ressource.ecriture.MeasureString(" ").X;
                                }
                            #endregion
                                else
                                {
                                    string keyString = key.ToString();
                                    if (keyString.Length == 1)
                                    {
                                        char c = keyString[0];
                                        if (!shiftPressed)
                                            c += (char)('a' - 'A');
                                        saisie += "" + c;
                                        position_curseur.X += taille_charactere(c).X;
                                    }
                                }
                        }
                    }
                    #region mise a jour du texte pour eviter le debordement
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
                    #endregion
                }
                catch (ArgumentException e)
                {
                    saisie += e.Message;
                }

                prevPressedKeys = pressedKeys;
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