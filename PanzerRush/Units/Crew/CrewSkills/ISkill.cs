using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanzerRush.Units.Crew.NewFolder1
{
	interface ISkill
	{
		string Name { set; get; }
		uint Level { get; set; }
		void Use(IUnit unit);
	}
}
