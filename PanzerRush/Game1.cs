using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.IO;

using Maps;

namespace RogueLike
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		Texture2D _tex;

		Camera camera;
		MeshModel mesh;

		Map map;

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
			camera = new Camera(GraphicsDevice, new Vector3(0, 0, 0), new Vector3(0, 300, 250));
			mesh = new MeshModel();
			mesh.LoadMesh(Content, "TankModels\\Hull\\PanzerKpfII");


			StreamReader gridJson = new StreamReader(Path.GetFullPath($"Content\\Maps\\map1.json"));
			map = JsonConvert.DeserializeObject<Map>(gridJson.ReadToEnd());
			map.LoadLayerGrids(GraphicsDevice,Content);

			_tex = Content.Load<Texture2D>("grass");
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

			//mesh.Draw(camera);

			map.Draw(GraphicsDevice, camera);
		}
    }
}
