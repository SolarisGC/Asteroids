using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace Asteroids
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Player : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D textura;
        protected Rectangle retanguloSprite;
        protected Vector2 posicao;

        protected const int LARGPLAYER = 30;
        protected const int ALTPLAYER = 30;

        protected Rectangle areaTela;

        public Player(Game game, ref Texture2D theTexture)
            : base(game)
        {
            textura = theTexture;
            posicao = new Vector2();

            retanguloSprite = new Rectangle(31, 83, LARGPLAYER, ALTPLAYER);

            areaTela = new Rectangle(0, 0,
                Game.Window.ClientBounds.Width,
                Game.Window.ClientBounds.Height);

            // TODO: Construct any child components here
        }


        /// <summary>
        ///  Coloca a nave na sua posição inicial na tela.
        /// </summary>
        public void PosicaoInicialNave()
        {
            posicao.X = areaTela.Width / 2;
            posicao.Y = areaTela.Height - ALTPLAYER;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // Move a nave com o teclado
            KeyboardState teclado = Keyboard.GetState();
            if (teclado.IsKeyDown(Keys.W))
                posicao.Y -= 3;
            if (teclado.IsKeyDown(Keys.S))
                posicao.Y += 3;
            if (teclado.IsKeyDown(Keys.A))
                posicao.X -= 3;
            if (teclado.IsKeyDown(Keys.D))
                posicao.X += 3;

            // Mantém a nave dentro da tela
            if (posicao.X < areaTela.Left)
                posicao.X = areaTela.Left;
            if (posicao.X > areaTela.Width - LARGPLAYER)
                posicao.X = areaTela.Width - LARGPLAYER;
            if (posicao.Y < areaTela.Top)
                posicao.Y = areaTela.Top;
            if (posicao.Y > areaTela.Height - ALTPLAYER)
                posicao.Y = areaTela.Height - ALTPLAYER;

            // TODO: Add your update code here

            base.Update(gameTime);
        }

        ///<summary>
        /// Desenha a sprite da nave.
        ///</summary>
        public override void Draw(GameTime gameTime)
        {
            //Obtém o spritebatch atual
            SpriteBatch sbatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            // Desenha a nave
            sbatch.Draw(textura, posicao, retanguloSprite, Color.White);


            base.Draw(gameTime);
        }

        ///<summary>
        /// Obtém o retângulo do limite da posição da nave na tela
        ///</summary>
        public Rectangle GetLimites()
        {
            return new Rectangle((int)posicao.X, (int)posicao.Y, LARGPLAYER, ALTPLAYER);
        }

    }
}