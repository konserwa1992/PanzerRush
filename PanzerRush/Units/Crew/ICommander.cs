using PanzerRush.Units.Crew.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanzerRush.Units
{
	interface ICommander
	{
		List<ISkill> ComanderSkillsCollection { set; get; }

	}
}
