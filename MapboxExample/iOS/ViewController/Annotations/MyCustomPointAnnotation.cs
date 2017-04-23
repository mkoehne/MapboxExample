using System;
using Mapbox;

namespace MapboxExample.iOS
{
	public class MyCustomPointAnnotation : MGLPointAnnotation
	{
		public bool WillUseImage = false;

		public MyCustomPointAnnotation()
		{
		}
	}
}
