using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;

namespace MapboxExample.iOS
{
	public partial class SatelliteStylesViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public SatelliteStylesViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// A hybrid style with unobtrusive labels is also available via satelliteStreetsStyleURL(withVersion:).
			mapView = new MGLMapView(View.Bounds, MGLStyle.SatelliteStyleURLWithVersion(9));

			// Tint the i button.
			mapView.AttributionButton.TintColor = UIColor.White;

			// Set the map’s center coordinate and zoom level.
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(45.5188, -122.6748), 13, false);

			View.AddSubview(mapView);
		}
	}
}