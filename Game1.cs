using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace Time_and_Sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont _font;
        Texture2D bomb;
        float seconds, startTime;
        MouseState mouseState;
        SoundEffect christainsLittleExplosion;

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

            // TODO: use this.Content to load your game content here
            _font = Content.Load<SpriteFont>("Kian's Head");
            bomb = Content.Load<Texture2D>("Darrian's bomb");
            christainsLittleExplosion = Content.Load<SoundEffect>("explosion");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            if (mouseState.LeftButton == ButtonState.Pressed)
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            if (seconds > 10) 
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            if (seconds >= 10)
            {
                christainsLittleExplosion       .Play();
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }

            mouseState = Mouse.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(bomb,new Rectangle(130 ,110, 530, 300),Color.White);
            _spriteBatch.DrawString(_font, (10-seconds).ToString("0.0"), new Vector2 (280, 200), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}