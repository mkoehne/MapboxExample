using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;

namespace MapboxExample.iOS
{
	public partial class DefaultStylesViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public DefaultStylesViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// Create a MapView
			mapView = new MGLMapView(View.Bounds, MGLStyle.OutdoorsStyleURLWithVersion(9));

			// Tint the i button and the user location annotation.
			mapView.TintColor = UIColor.DarkGray;

			// Set the map’s center coordinate and zoom level.
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(51.50713, -0.10957), 13, false);

			View.AddSubview(mapView);
		}
	}
}