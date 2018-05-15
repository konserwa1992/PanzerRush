using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanzerRush.Units.Crew.NewFolder1;

namespace PanzerRush.Units
{
	class Commander : ICommander
	{
		public List<ISkill> ComanderSkillsCollection { get; set; }
	}
}
