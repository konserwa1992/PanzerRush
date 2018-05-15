using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.IO;
using PanzerRush.Map;

namespace PanzerRush
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		Texture2D _tex;

		Camera camera;

		MapContainer map;
		MeshModel model = new MeshModel();

		public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
					
			spriteBatch = new SpriteBatch(GraphicsDevice);
			camera = new Camera(GraphicsDevice, new Vector3(64, 0, 128), new Vector3(64, 200, 150+ 128));

			StreamReader gridJson = new StreamReader(Path.GetFullPath($"Content\\Maps\\map1.json"));
			map = JsonConvert.DeserializeObject<MapContainer>(gridJson.ReadToEnd());
			map.LoadLayerGrids(GraphicsDevice,Content);

			_tex = Content.Load<Texture2D>("grass");

			model.LoadMesh(Content, "Models\\TankModels\\Hull\\PanzerKpfII");
		}

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			camera.Update(gameTime);


			base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.DarkSlateBlue, 1.0f, 0);
			model.Draw(camera);
			map.Draw(GraphicsDevice, camera);
		}
    }
}
