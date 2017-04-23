using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;

namespace MapboxExample.iOS
{
	public partial class CustomRasterStyleViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public CustomRasterStyleViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// Local paths are also acceptable.
			var styleURL = new NSUrl("https://www.mapbox.com/ios-sdk/files/mapbox-raster-v8.json");
			mapView = new MGLMapView(View.Bounds, styleURL);

			View.AddSubview(mapView);
		}
	}
}