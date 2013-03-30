using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace Templar
{
    class dessin_perso
    {
        GamePlayer Player;
        int Framecolumn;

        public dessin_perso(GamePlayer player)
        {
            this.Player = player;
        }

        public void update()
        {
            switch (Player.direction)
            {
                case Direction.Up:
                    Framecolumn = 4;
                    break;
                case Direction.Down:
                    Framecolumn = 0;
                    break;
                case Direction.Left:
                    Framecolumn = 2;
                    break;
                case Direction.Right:
                    Framecolumn = 2;
                    break;



            }
        }

        public void draw(SpriteBatch spritebatch)
        {


            switch (Player.direction)
            {
                #region up
                case Direction.Up:
                    switch (Player.framecolumn)
                    {
                        case 0:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 15, Player.position_player.Y - 17),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 1:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 13, Player.position_player.Y - 17),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 2:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 11, Player.position_player.Y - 17),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 3:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 13, Player.position_player.Y - 17),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 4:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 15, Player.position_player.Y - 17),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 5:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 13, Player.position_player.Y - 17),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 6:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 11, Player.position_player.Y - 17),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 7:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 9, Player.position_player.Y - 17),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;


                    }
                    Framecolumn = 4;
                    break;

                #endregion

                #region down
                case Direction.Down:
                    Framecolumn = 0;
                    switch (Player.framecolumn)
                    {

                        case 0:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 12, Player.position_player.Y - 15),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 1:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 11, Player.position_player.Y - 15),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 2:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 12, Player.position_player.Y - 15),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 3:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 11, Player.position_player.Y - 15),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 4:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 12, Player.position_player.Y - 15),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 5:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 11, Player.position_player.Y - 15),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 6:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 12, Player.position_player.Y - 15),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;

                        case 7:
                            spritebatch.Draw(ressource.tete_player,
                                new Vector2(Player.position_player.X + 11, Player.position_player.Y - 15),
                                new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50),
                                Color.White);
                            break;
                    }
                    break;
                #endregion

                case Direction.Left:
                    Framecolumn = 2;
                    break;
                case Direction.Right:
                    Framecolumn = 2;
                    break;



            }




            /*if (Player.direction == Direction.Right)
                spritebatch.Draw(ressource.tete_player, new Rectangle((int)Player.position_player.X, (int)Player.position_player.Y, 1, 1),
                    new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50), Color.White,
                    0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);

            else
                spritebatch.Draw(ressource.tete_player, new Vector2(Player.position_player.X + 11, Player.position_player.Y - 15), new Rectangle(Framecolumn * 39, Player.tete * 50, 39, 50), Color.White);
       */
        }
    }
}
