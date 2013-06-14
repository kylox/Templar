using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace Templar
{
    //classe principale de tout les menus 
    public class menugenerale : Microsoft.Xna.Framework.DrawableGameComponent
    {
        string[] menuItems;
        int selectedIndex;
        Rectangle[] list_button;

        KeyboardState keyboardState;
        KeyboardState oldkeyboardState;
        MouseState mouse;
        Color normal = Color.White;
        Color selec = Color.Red;

        //MouseEvent mouse;

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Vector2 position;

        float width = 0f;
        float height = 0f;

        public int SelectedIndex//donne le bouton a cliqué
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;

                if (selectedIndex < 0)
                    selectedIndex = 0;

                if (selectedIndex >= menuItems.Length)
                    selectedIndex = menuItems.Length - 1;
            }
        }
        public menugenerale(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, string[] menuItems)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.menuItems = menuItems;
            list_button = new Rectangle[menuItems.Length + 1];
            measureMenu();
            place_rectangle();
        }
        private void measureMenu() //taille du menu
        {
            height = 0;
            width = 0;
            foreach (string item in menuItems)
            {
                Vector2 size = spriteFont.MeasureString(item);
                if (size.X > width)
                    width = size.X;
                height += spriteFont.LineSpacing + 5;
            }
            position = new Vector2((Game.Window.ClientBounds.Width - width) / 6,
                 (Game.Window.ClientBounds.Height - height) / 6);
        }
        private void place_rectangle()
        {
            Vector2 location = position;
            int i = 0;
            foreach (string item in menuItems) // dessine tout les options du menu comprise dans le menu item 
            {
                list_button[i] = new Rectangle((int)location.X, (int)location.Y, item.Length * 14, 20);
                location.Y += spriteFont.LineSpacing + 5;
                i++;
            }
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        private bool checkKey(Keys theKey) //verifie les etats du clavier
        {
            return keyboardState.IsKeyUp(theKey)
                && oldkeyboardState.IsKeyDown(theKey);
        }
        public override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouse = Mouse.GetState();
            for (int i = 0; i < list_button.Length; i++)
                if (new Rectangle(mouse.X, mouse.Y, 1, 1).Intersects(list_button[i]))
                    selectedIndex = i;
            if (checkKey(Keys.Down))
            {
                selectedIndex++; // incremente la selection de 1 en 1
                if (selectedIndex == menuItems.Length)
                    selectedIndex = 0;//reviens a zero lorsque la selection arrive au maximum 
            }
            if (checkKey(Keys.Up))
            {
                selectedIndex--; // decremente la selection 
                if (selectedIndex < 0)
                    selectedIndex = menuItems.Length - 1;
            }
            base.Update(gameTime);
            oldkeyboardState = keyboardState;
        }
        public override void Draw(GameTime gameTime) // dessine tout les options necessaire au menu
        {
            base.Draw(gameTime);
            Vector2 location = position;
            Color tint;
            for (int i = 0; i < menuItems.Length; i++) // dessine tout les options du menu comprise dans le menu item 
            {
                if (i == selectedIndex)
                    tint = selec;
                else
                    tint = normal;
                spriteBatch.DrawString(spriteFont, menuItems[i], location, tint);
                location.Y += spriteFont.LineSpacing + 5;
            }
        }
    }
}
