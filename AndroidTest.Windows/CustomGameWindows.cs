using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTest;
public class CustomGameWindows : Game
{
	protected override void Initialize()
	{
		// Add custom code here
		base.Initialize();
		GraphicsDeviceManager.IsFullScreen = true;
	}
}

