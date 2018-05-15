using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanzerRush.Units
{
	interface IUnit
	{
		int Health { set; get; }
		HashSet<MeshModel> MeshCollection { get; set; }
		ICommander UnitCommander { set; get; }

		void Draw();
		void Update();
		void Attack(int x,int y);
	}
}
