using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Maps
{
	class Map
	{
		public List<string> GridsTextureSheetsNames { set; get; }
		public List<GridsSheetContainer> Grids{ private set; get; } = new List<GridsSheetContainer>();
		public List<Layer> Layers { get; set; } = new List<Layer>();


		public void LoadLayerGrids()
		{
			foreach (string gridFile in GridsTextureSheetsNames)
			{
				StreamReader gridJson = new StreamReader(Path.GetFullPath($"Content\\Grid\\{gridFile}.json"));
				Grids.Add(JsonConvert.DeserializeObject<GridsSheetContainer>(gridJson.ReadToEnd()));
			}
		}

		public void GenerateMap()
		{

		}
	}
}
