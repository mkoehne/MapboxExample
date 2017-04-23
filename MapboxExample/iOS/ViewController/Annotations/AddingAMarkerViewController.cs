using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;

namespace MapboxExample.iOS
{
	public partial class AddingAMarkerViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public AddingAMarkerViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			mapView = new MGLMapView(View.Bounds);

			// Set the map’s center coordinate and zoom level.
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(40.7326808, -73.9843407), 12, false);

			// Set the delegate property of our map view to `self` after instantiating it.
			mapView.WeakDelegate = this;

			View.AddSubview(mapView);

			// Declare the marker `hello` and set its coordinates, title, and subtitle.
			var hello = new MGLPointAnnotation();
			hello.Coordinate = new CLLocationCoordinate2D(40.7326808, -73.9843407);
			hello.Title = "Hello world!";
			hello.Subtitle = "Welcome to my marker";

			// Add marker `hello` to the map.
			mapView.AddAnnotation(hello);
		}

		// Use the default marker. See also: our view annotation or custom marker examples.
		[Export("viewForAnnotation:")]
		public MGLAnnotationView ViewForAnnotation(IMGLAnnotation annotation)
		{
			return null;
		}

		// Allow callout view to appear when an annotation is tapped.
		[Export("mapView:annotationCanShowCallout:")]
		public bool AnnotationCanShowCallout(MGLMapView mapView, NSObject annotation)
		{
			return true;
		}
	}
}