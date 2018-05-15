using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Xna.Framework.Graphics;


namespace PanzerRush.Map
{
	class MapContainer
	{
		public List<string> GridsSheetsNames { set; get; }
		public List<GridsSheetContainer> Grids{ private set; get; } = new List<GridsSheetContainer>();
		public List<Layer> Layers { get; set; } = new List<Layer>();


		public void LoadLayerGrids(GraphicsDevice device, ContentManager content)
		{
			foreach (string gridFile in GridsSheetsNames)
			{

				StreamReader gridJson = new StreamReader(Path.GetFullPath($"Content\\Grid\\{gridFile}.json"));
				GridsSheetContainer gridSheetListElement = JsonConvert.DeserializeObject<GridsSheetContainer>(gridJson.ReadToEnd());
				gridSheetListElement.LoadTexture(content);
				Grids.Add(gridSheetListElement);
			}

			InitMapMeshes(device,content);
		}

		private void InitMapMeshes(GraphicsDevice device, ContentManager content)
		{
			foreach (Layer layer in Layers)
			{
				layer.InitMesh(device, Grids,content);
			}
		}

		public void Draw(GraphicsDevice device,Camera camera)
		{
			foreach(Layer layer in Layers)
			{
				layer.Draw(device,camera);
			}
		}
	}
}
