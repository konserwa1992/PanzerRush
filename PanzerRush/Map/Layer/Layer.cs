using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
		
		private Texture2D MeshTexture { set; get; }
		private VertexBuffer LayerVertexBuffer { set; get; }
		private GridsSheetContainer GridSheet { set; get; }

		public void InitMesh(GraphicsDevice device, List<GridsSheetContainer> gridTexSheets, ContentManager content)
		{
			List<VertexPositionNormalTexture> verticesList = new List<VertexPositionNormalTexture>();
			GridSheet = (from gridSheet in gridTexSheets where gridSheet.ID == SheetID select gridSheet).FirstOrDefault();

			GridSheet.LoadTexture(content);

			for (int x = 0; x < MapGridsData.GetLength(0); x++)
			{
				for (int y = 0; y < MapGridsData.Length / MapGridsData.GetLength(0); y++)
				{
					if (MapGridsData[x, y] != 0)
					{
						verticesList.Add(new VertexPositionNormalTexture(
							new Vector3(x * 64, 0, y * 64), 
							new Vector3(0, 1, 0),
							new Vector2(((float)GridSheet.GridsDataList.FirstOrDefault(g=>g.ID==MapGridsData[x, y]).X/ (float)GridSheet.TextureSizeX), ((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).Y / (float)GridSheet.TextureSizeY))));

						verticesList.Add(new VertexPositionNormalTexture(
							new Vector3((x + 1) * 64, 0, y * 64), 
							new Vector3(0, 1, 0),
							new Vector2(((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).SizeX / (float)GridSheet.TextureSizeX), ((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).Y / (float)GridSheet.TextureSizeY))));

						verticesList.Add(new VertexPositionNormalTexture(
							new Vector3((x + 1) * 64, 0, (y + 1) * 64), 
							new Vector3(0, 1, 0),
							new Vector2(((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).SizeX / (float)GridSheet.TextureSizeX), ((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).SizeY / (float)GridSheet.TextureSizeY))));

						verticesList.Add(new VertexPositionNormalTexture(
							new Vector3(x * 64, 0, y * 64), 
							new Vector3(0, 1, 0),
							new Vector2(((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).X / (float)GridSheet.TextureSizeX), ((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).Y / (float)GridSheet.TextureSizeY))));

						verticesList.Add(new VertexPositionNormalTexture(
							new Vector3((x + 1) * 64, 0, (y + 1) * 64),
							new Vector3(0, 1, 0),
							new Vector2(((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).SizeX / (float)GridSheet.TextureSizeX), ((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).SizeY / (float)GridSheet.TextureSizeY))));

						verticesList.Add(new VertexPositionNormalTexture(
							new Vector3(x * 64, 0, (y + 1) * 64), 
							new Vector3(0, 1, 0),
							new Vector2(((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).X / (float)GridSheet.TextureSizeX), ((float)GridSheet.GridsDataList.FirstOrDefault(g => g.ID == MapGridsData[x, y]).SizeY / (float)GridSheet.TextureSizeY))));
					}
				}
			}
			LayerVertexBuffer = new VertexBuffer(device, VertexPositionNormalTexture.VertexDeclaration, verticesList.Count, BufferUsage.WriteOnly);
			LayerVertexBuffer.SetData<VertexPositionNormalTexture>(verticesList.ToArray());
		}

		public void Draw(GraphicsDevice device, Camera camera)
		{

			BasicEffect basicEffect = new BasicEffect(device);
			basicEffect.World = Matrix.CreateTranslation(Vector3.Zero);
			basicEffect.View = camera.View;
			basicEffect.Projection = camera.Projection;
			basicEffect.TextureEnabled = true;
			basicEffect.Texture = GridSheet.Texture;
			device.SetVertexBuffer(LayerVertexBuffer);

			foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
			{
				pass.Apply();
				device.DrawPrimitives(PrimitiveType.TriangleList, 0, LayerVertexBuffer.VertexCount / 3);
			}
		}
	}

}
