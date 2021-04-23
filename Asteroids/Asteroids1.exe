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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch = null;
        private Texture2D texturaBackground;
        private Texture2D texturaMeteoro;
        // Jogador
        private Player play;
        // Constante que define a quantidade inicial de meteoros.
        private const int CONTMETEOROINICIO = 10;
        // Jogo
        private KeyboardState teclado; // Captura entradas do teclado
        private int contador; // Contagem de mortes do jogador
        private SpriteFont gameFont; // Utilizando para escrever na tela



        public Game1()
        {  
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texturaBackground = Content.Load<Texture2D>("background");
            // Carrega a textura do meteoro
            texturaMeteoro = Content.Load<Texture2D>("Jogador");
            // Adiciona o serviço SpriteBatch
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            // Carrega a fonte do placar
            gameFont = Content.Load<SpriteFont>("Fonte");
        }
        

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Sair do jogo através do GamePad do XBox 360.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // faz com que o atributo teclado receba as teclas pressionadas.
            teclado = Keyboard.GetState();
            if (teclado.IsKeyDown(Keys.Escape))
                Exit();

            // Inicializa caso ainda não o tenha.
            if (play == null)
                Start();

            LogicaJogo();

            // Atualiza todos os outros componentes
            base.Update(gameTime);
        }

       

       

        ///<summary>
        /// Inicializa o jogo
        ///</summary>
        private void Start()
        {
            // Adiciona os meteoros
            for (int i = 0; i < CONTMETEOROINICIO; i++)
                Components.Add(new Meteor(this, ref texturaMeteoro));

            // Será utilizado para ver quantas vezes o jogador morreu
            contador++;

            // Cria (se necessário) e coloca o jogador na posição INICIAL
            if (play == null)
            {
                // Adiciona o GameComponent Player
                play = new Player(this, ref texturaMeteoro);
                Components.Add(play);
            }
            play.PosicaoInicialNave();
        }

        ///<sumarry>
        ///Remove todos os meteoros da tela.
        /// </sumarry>
        private void RemoveMeteoros()
        {
          for (int i = 0; i < Components.Count; i++)
              //Verifica se o componente é um meteoro
              if(Components[i] is Meteor)
              {
                  /* Se for verdadeiro ele remove todos
                   * e decrementa do vetor Components */
                  Components.RemoveAt(i);
                  i--;
              }
        }

        ///<summary>
        ///Executa a lógica de todo o jogo
        /// </summary>
        private void LogicaJogo()
        {
            // Verifica se houve colisão entre nave e meteoro
            bool colisao = false; // Variável booleana
            Rectangle rectPlayer = play.GetLimites(); // Retorna o limite da tela
            foreach (GameComponent gc in Components)
            {
                if (gc is Meteor)
                {
                    colisao = ((Meteor)gc).CheckCollision(rectPlayer);
                    if (colisao)
                    {
                      
                        RemoveMeteoros();
                        Start();

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(texturaBackground, new Rectangle(0, 0,
                graphics.GraphicsDevice.DisplayMode.Width,
                graphics.GraphicsDevice.DisplayMode.Height),
                Color.LightGray);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            spriteBatch.End();

            // Desenha o placar
            spriteBatch.Begin();
            spriteBatch.DrawString(gameFont, "Colisoes: " + contador.ToString(), 
                  new Vector2(15, 15), Color.White);
            spriteBatch.End();
        }
    }
}
