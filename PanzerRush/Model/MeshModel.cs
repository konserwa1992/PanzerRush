using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RogueLike
{
	class MeshModel
	{
		public Vector3 Position { get; set; } = Vector3.Zero;
		public Vector3 Rotation { get; set; } = Vector3.Zero;

		Model modelMesh;

		float angle = 0.0f;

		public void LoadMesh(ContentManager content,string meshName)
		{
			modelMesh = content.Load<Model>(meshName);
		}

		public void Draw(Camera camera)
		{
			angle += 0.25f;
			foreach (ModelMesh mesh in modelMesh.Meshes)
			{
				foreach (BasicEffect effect in mesh.Effects)
				{
					effect.EnableDefaultLighting();
					effect.World = Matrix.CreateRotationX(MathHelper.ToRadians(-90))* Matrix.CreateRotationY(MathHelper.ToRadians(angle)) *  Matrix.CreateTranslation(Position) * Matrix.CreateScale(1.0f);
					effect.View = camera.View;
					effect.Projection = camera.Projection;
				}
				mesh.Draw();
			}
		}
	}
}