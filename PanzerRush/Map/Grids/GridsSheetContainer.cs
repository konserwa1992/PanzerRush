using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanzerRush.Map
{
	class GridsSheetContainer
	{
		public int ID { set; get; }
		public string TextureName { set; get; }
		public int TextureSizeX { set; get; }
		public int TextureSizeY { set; get; }
		public List<Grid> GridsDataList { set; get; } = new List<Grid>();
		public Texture2D Texture { set; get; }


		public void LoadTexture(ContentManager content)
		{
			Texture = content.Load<Texture2D>(TextureName);
		}
	}
}
