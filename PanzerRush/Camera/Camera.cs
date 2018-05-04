using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Camera
    {
		public Matrix View {private set; get; }
		public Matrix Projection { private set; get; }
		public Vector3 Position { set; get; } = new Vector3(0, 0, 0);
		public Vector3 LookAtPosition { set; get; } = new Vector3(0, 0, 0);
		public GraphicsDevice GraphicDevice { private set; get; }

		public Camera(GraphicsDevice graphicDevice,Vector3 lookAt,Vector3 position)
		{
			GraphicDevice = graphicDevice;
			LookAtPosition = lookAt;
			Position = position;
		}

		public void SetCameraParams(Vector3 lookAt, Vector3 position)
		{
			LookAtPosition = lookAt;
			Position = position;
		}

		public void Update(GameTime gameTime)
		{
			View = Matrix.CreateLookAt(Position, LookAtPosition, Vector3.Up);
			Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), GraphicDevice.Viewport.AspectRatio, 1.0f, 1000.0f);
		}
    }
}
