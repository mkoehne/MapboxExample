using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;

namespace MapboxExample.iOS
{
	public partial class CustomStyleViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public CustomStyleViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// Fill in the next line with your style URL from Mapbox Studio.
			var styleURL = new NSUrl("https://www.mapbox.com/ios-sdk/files/mapbox-raster-v8.json");
			mapView = new MGLMapView(View.Bounds, styleURL);

			// Set the map’s center coordinate and zoom level.
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(45.52954, -122.72317), 14, false);

			View.AddSubview(mapView);
		}
	}
}