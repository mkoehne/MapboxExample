using System;
using Mapbox;
using UIKit;

namespace MapboxExample.iOS
{
	public class CustomPolyline : MGLPolyline
	{
		public UIColor Color { get; set; }

		public CustomPolyline()
		{
		}
	}
}
