using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike.Content.Maps.MapAssets
{
	public partial class SimpleAssetSheet : Component
	{
		public SimpleAssetSheet()
		{
			InitializeComponent();
		}

		public SimpleAssetSheet(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
	}
}
