using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueLike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps
{
	class Layer
	{
		public int LayerIndex { get; set; }
		public string Name { get; set; }
		public int[,] MapGridsData { get; set; }
		public int SheetID { get; set; }

		private VertexBuffer layerVertexBuffer { set; get; }

		public void InitMesh(GraphicsDevice device, List<GridsSheetContainer> gridTexSheet)
		{
			List<VertexPositionNormalTexture> verticesList = new List<VertexPositionNormalTexture>();

			for (int x=0;x < MapGridsData.GetLength(0); x++)
			{
				for (int y = 0; y < MapGridsData.Length/MapGridsData.GetLength(0); y++)
				{
					verticesList.Add(new VertexPositionNormalTexture(new Vector3(x*64,0, y * 64),new Vector3(0,1,0),new Vector2(0,0)));
					verticesList.Add(new VertexPositionNormalTexture(new Vector3((x+1) * 64, 0, (y+1) * 64), new Vector3(0, 1, 0), new Vector2(1, 1)));
					verticesList.Add(new VertexPositionNormalTexture(new Vector3((x+1) * 64, 0, y * 64), new Vector3(0, 1,0), new Vector2(1, 0)));

					verticesList.Add(new VertexPositionNormalTexture(new Vector3(x * 64, 0, y * 64), new Vector3(0, 1, 0), new Vector2(0, 0)));
					verticesList.Add(new VertexPositionNormalTexture(new Vector3(x  * 64, 0, (y+1) * 64), new Vector3(0, 1, 0), new Vector2(0, 1)));
					verticesList.Add(new VertexPositionNormalTexture(new Vector3((x+1) * 64, 0, (y+1) * 64), new Vector3(0, 1, 0), new Vector2(1, 1)));
				}
			}
			layerVertexBuffer = new VertexBuffer(device, VertexPositionNormalTexture.VertexDeclaration, verticesList.Count, BufferUsage.WriteOnly);
		}

		public void Draw(GraphicsDevice device, Camera camera,Texture2D tex)
		{

			BasicEffect basicEffect = new BasicEffect(device);
			basicEffect.World = Matrix.CreateTranslation(Vector3.Zero);
			basicEffect.View = camera.View;
			basicEffect.Projection = camera.Projection;
			basicEffect.
			basicEffect.TextureEnabled = true;
			basicEffect.Texture = tex;
			device.SetVertexBuffer(layerVertexBuffer);

			foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
			{
				pass.Apply();
				device.DrawPrimitives(PrimitiveType.TriangleList, 0, layerVertexBuffer.VertexCount / 3);
			}
		}
	}
}
