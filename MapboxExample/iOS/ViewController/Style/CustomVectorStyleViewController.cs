using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;

namespace MapboxExample.iOS
{
	public partial class CustomVectorStyleViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public CustomVectorStyleViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// Third party vector tile sources can be added.
			// In this case we're using custom style JSON (https://www.mapbox.com/mapbox-gl-style-spec/) to add a third party tile source: <https://vector.mapzen.com/osm/all/{z}/{x}/{y}.mvt>
			var customStyleURL = NSBundle.MainBundle.PathForResource("third_party_vector_style", "json");
			mapView = new MGLMapView(View.Bounds, new NSUrl(customStyleURL));
			mapView.TintColor = UIColor.White;

			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(51.50713, -0.10957), 13, false);

			View.AddSubview(mapView);
		}
	}
}