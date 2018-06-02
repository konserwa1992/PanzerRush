using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using PanzerRush;
using PanzerRush.Units;


namespace RogueLike.Units.Tanks
{
	class TankDestroyer : IUnit
	{
		public int Health { get; set; }
		public HashSet<MeshModel> MeshCollection { get; set; }
		public ICommander UnitCommander { get; set; }


	
		public void Attack(int squerCoordX, int squerCoordY)
		{
			
		}

		public void Draw(Camera camera)
		{
			
		}

		public void LoadUnitMeshes(ContentManager content)
		{
			throw new System.NotImplementedException();
		}

		public void Update()
		{
			
		}
	}
}
