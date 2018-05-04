using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps
{
	class GridsSheetContainer
	{
		public int TextureSizeX { private set; get; }
		public int TextureSizeY { private set; get; }
		public List<Grid> GridsDataList { set; get; } = new List<Grid>();
	}
}
