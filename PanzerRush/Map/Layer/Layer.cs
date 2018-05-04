using Microsoft.Xna.Framework.Graphics;
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

		private VertexBuffer layerVertexBuffer { set; get; }

		public void InitMesh(GraphicsDevice device, List<GridsSheetContainer> gridTexSheet)
		{
			List<VertexPositionNormalTexture> verticesList = new List<VertexPositionNormalTexture>();

			for (int x=0;x<MapGridsData.Length;x++)
			{
				for (int y = 0; y < MapGridsData.Length; y++)
				{
					if(MapGridsData[x,y] != 0)
					{
						verticesList.Add(new VertexPositionNormalTexture());
					}
				}
			}

			layerVertexBuffer = new VertexBuffer(device, VertexPositionNormalTexture.VertexDeclaration, vertexCout * 4, BufferUsage.WriteOnly);

		}
	}
}
