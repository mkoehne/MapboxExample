using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;
using System.Collections.Generic;
using CoreGraphics;

namespace MapboxExample.iOS
{
	public partial class AnnotationViewsViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public AnnotationViewsViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			mapView = new MGLMapView(View.Bounds);

			// Set the map’s center coordinate and zoom level
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(0, 66), false);
			mapView.SetZoomLevel(2, false);
			mapView.StyleURL = MGLStyle.DarkStyleURLWithVersion(9);

			// Set the delegate property of our map view to `self` after instantiating it
			mapView.WeakDelegate = this;

			View.AddSubview(mapView);

			// Specify coordinates for our annotations.
			List<CLLocationCoordinate2D> coordinates = new List<CLLocationCoordinate2D>();
			coordinates.Add(new CLLocationCoordinate2D(0, 33));
			coordinates.Add(new CLLocationCoordinate2D(0, 66));
			coordinates.Add(new CLLocationCoordinate2D(0, 99));

			List<MGLPointAnnotation> pointAnnotations = new List<MGLPointAnnotation>();

			// Fill an array with point annotations and add it to the map.
			foreach (var coord in coordinates)
			{
				MGLPointAnnotation point = new MGLPointAnnotation();
				point.Coordinate = coord;
				point.Title = $"Lat: {coord.Latitude}, Long: {coord.Longitude}";
				pointAnnotations.Add(point);

			}

			mapView.AddAnnotations(pointAnnotations.ToArray());
		}

		// Use the default marker. See also: our view annotation or custom marker examples.
		[Export("mapView:viewForAnnotation:")]
		public MGLAnnotationView ViewForAnnotation(MGLMapView mapView, NSObject annotation)
		{
			if (annotation is MGLPointAnnotation)
			{
				var anno = (MGLPointAnnotation)annotation;
				var reuseIdentifier = $"{anno.Coordinate.Longitude}";

				// For better performance, always try to reuse existing annotations.
				var annotationView = mapView.DequeueReusableAnnotationViewWithIdentifier(reuseIdentifier);
				if (annotationView == null)
				{
					annotationView = new CustomAnnotationView(reuseIdentifier);

					annotationView.Frame = new CGRect(x: 0, y: 0, width: 40, height: 40);

					// Set the annotation view’s background color to a value determined by its longitude.
					var hue = anno.Coordinate.Longitude / 100;

					annotationView.BackgroundColor = UIColor.FromHSB((nfloat)hue, (nfloat)0.5, (nfloat)1);
				}

				return annotationView;
			}
			else
			{
				return null;
			}
		}

		// Allow callout view to appear when an annotation is tapped.
		[Export("mapView:annotationCanShowCallout:")]
		public bool AnnotationCanShowCallout(MGLMapView mapView, NSObject annotation)
		{
			return true;
		}
	}
}