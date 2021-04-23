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
    /// Isso é um componente de jogo que implementa a rocha
    /// que o jogador precisa evitar.
    /// </summary>
    public class Meteor : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D textura;
        protected Rectangle spriteRetangulo;
        protected Vector2 posicao;
        protected int velocidadeY;
        protected int velocidadeX;
        protected Random random;
        protected SpriteBatch sBatch;

        // Largura e altura da sprite na textura
        protected const int LARGMETEORO = 45;
        protected const int ALTMETEORO = 45;

        public Meteor(Game game, ref Texture2D theTexture)
            : base(game)
        {
            textura = theTexture;
            posicao = new Vector2();
            
            sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            /* Cria o retângulo fonte.
             * Isso representa onde a figura da sprite está na superfície.*/
            spriteRetangulo = new Rectangle(20, 16, LARGMETEORO, ALTMETEORO);

            /* Inicializa o gerador de números randômicos e coloca o metero na
             * sua posição inicial*/
            random = new Random(this.GetHashCode());
            PutinStartPosition();
        }

        /// <summary>
        /// Inicializa a posição e a velocidade do meteoro.
        /// </summary>
        protected void PutinStartPosition()
        {
            posicao.X = random.Next(Game.Window.ClientBounds.Width - LARGMETEORO);
            posicao.Y = 0;
            velocidadeY = 1 + random.Next(9);
            velocidadeX = random.Next(3) 1;
        }

        /// <summary>
        /// Permite que o componente de jogo desenhe seu
        /// conteúdo na tela do jogo.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // Desenha o meteoro.
            sBatch.Draw(textura, posicao, spriteRetangulo, Color.White);

            base.Draw(gameTime);
        }

        /// <summary>
        /// Permite que o componente do jogo se atualize.
        /// </summary>
        /// <param name="gameTime">Fornece um instantâneo dos valores do timing.</param>
        public override void Update(GameTime gameTime)
        {
            // Verifica se o meteoro ainda está visível.
            if ((posicao.Y >= Game.Window.ClientBounds.Height) ||
                (posicao.X >= Game.Window.ClientBounds.Width) || (posicao.X <= 0))
            {
                PutinStartPosition();
            }

            // Move o meteoro
            posicao.Y += velocidadeY;
            posicao.X += velocidadeX;

            base.Update(gameTime);
        }

        /// <summary>
        /// Verifica se o meteoro intercepta o retângulo especificado.
        /// </summary>
        /// <param name="rect">Testa o retângulo.</param>
        /// <returns>true, se houver colisão</returns>
        public bool CheckCollision(Rectangle rect)
        {
            Rectangle spriterect = new Rectangle((int)posicao.X, (int)posicao.Y,
                LARGMETEORO, ALTMETEORO);
            return spriterect.Intersects(rect);
        }
    }
}