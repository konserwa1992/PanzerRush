using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace PanzerRush
{
	class MeshModel
	{
		public string MeshName { get; set; }
		public string MeshFileName { get; set; }
		private Model modelMesh;
		public Vector3 Rotation { get; set; } = Vector3.Zero;
		public Vector3 LocalPosition { get; set; } = Vector3.Zero;
		public Vector3 WorldPosition { get; set; } = Vector3.Zero;



		float angle = 0.0f;

		public MeshModel()
		{
		}


		public void LoadMesh(ContentManager content)
		{
			modelMesh = content.Load<Model>(MeshFileName);
		}

		public void Draw(Camera camera)
		{
			angle += 0.25f;
			foreach (ModelMesh mesh in modelMesh.Meshes)
			{
				foreach (BasicEffect effect in mesh.Effects)
				{
					effect.EnableDefaultLighting();
					effect.World = Matrix.CreateScale(3)* Matrix.CreateRotationX(MathHelper.ToRadians(-90))* Matrix.CreateRotationY(MathHelper.ToRadians(angle)) *  Matrix.CreateTranslation(new Vector3(32,15,32)) * Matrix.CreateScale(1.0f);
					effect.View = camera.View;
					effect.Projection = camera.Projection;
				}
				mesh.Draw();
			}
		}
	}
}