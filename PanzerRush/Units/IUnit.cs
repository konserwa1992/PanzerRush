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
		ICommander UnitCommander { set; get; }


		void LoadUnitMeshes(ContentManager content);
		void Draw(Camera camera);
		void Update();
		void Attack(int squerCoordX, int squerCoordY);
	}
}
