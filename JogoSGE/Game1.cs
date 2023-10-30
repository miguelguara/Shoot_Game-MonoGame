using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace JogoSGE
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D Alvo;
        Texture2D MiraSprite;
        Texture2D BackgroundSprite;
        SpriteFont GameText;


        Vector2 Pos_Alvo = new Vector2(300, 300);
        const int raioAlvo = 45;
        MouseState mState;
        bool SBotao = true; 
        int pontos = 0;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Alvo = Content.Load<Texture2D>("target");
            MiraSprite = Content.Load<Texture2D>("crosshairs");
            BackgroundSprite = Content.Load<Texture2D>("sky");
            GameText = Content.Load<SpriteFont>("galleryFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mState = Mouse.GetState();

            if(mState.LeftButton == ButtonState.Pressed && SBotao == true)
            {
                float DistanciaMouse = Vector2.Distance(Pos_Alvo,mState.Position.ToVector2());
                if(DistanciaMouse < raioAlvo)
                {
                    pontos++;
                    Random ram = new Random();

                    Pos_Alvo.X = ram.Next(25,_graphics.PreferredBackBufferWidth);
                    Pos_Alvo.Y = ram.Next(20,_graphics.PreferredBackBufferHeight);
                }
                SBotao = false;
            }
            else if(mState.LeftButton == ButtonState.Released)
            {
                SBotao = true;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(BackgroundSprite,new Vector2(0f,0f),Color.White);
            _spriteBatch.DrawString(GameText, "Pontos: " + pontos, new Vector2(20f, 0f),Color.White);
            _spriteBatch.Draw(Alvo,new Vector2(Pos_Alvo.X - raioAlvo,Pos_Alvo.Y - raioAlvo),Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}