using Microsoft.Xna.Framework.Content;
using PanzerRush;
using PanzerRush.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike.Units.Tanks
{
	class MidTank : IUnit
	{
		public int Health { get; set; } = 100;
		public MeshModel HullMesh { get; set; }
		public MeshModel TurretMesh { get; set; }
		public ICommander UnitCommander { get; set; }


		public void Attack(int squerCoordX, int squerCoordY)
		{
		}

		public void Draw(Camera camera)
		{
			HullMesh.Draw(camera);
			TurretMesh.Draw(camera);
		}

		public void LoadUnitMeshes(ContentManager content)
		{
			HullMesh.LoadMesh(content);
			TurretMesh.LoadMesh(content);
		}

		public void Update()
		{
		}
	}
}
