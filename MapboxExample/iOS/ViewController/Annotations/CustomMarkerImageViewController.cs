using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;
using CoreGraphics;

namespace MapboxExample.iOS
{
	public partial class CustomMarkerImageViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public CustomMarkerImageViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			mapView = new MGLMapView(View.Bounds, MGLStyle.LightStyleURLWithVersion(9));
			mapView.TintColor = UIColor.DarkGray;

			// Set the map's bounds to Pisa, Italy.
			var bounds = new MGLCoordinateBounds()
			{
				sw = new CLLocationCoordinate2D(latitude: 43.7115, longitude: 10.3725),
				ne = new CLLocationCoordinate2D(latitude: 43.7318, longitude: 10.4222)
			};

			mapView.SetVisibleCoordinateBounds(bounds, animated: false);

			// Set the map view‘s delegate property.
			mapView.WeakDelegate = this;

			View.AddSubview(mapView);

			// Initialize and add the point annotation.
			var pisa = new MGLPointAnnotation();
			pisa.Coordinate = new CLLocationCoordinate2D(latitude: 43.72305, longitude: 10.396633);
			pisa.Title = "Leaning Tower of Pisa";

			mapView.AddAnnotation(pisa);

		}

		[Export("mapView:imageForAnnotation:")]
		public virtual MGLAnnotationImage ImageForAnnotation(MGLMapView mapView, NSObject annotation)
		{
			// Try to reuse the existing ‘pisa’ annotation image, if it exists.
			var annotationImage = mapView.DequeueReusableAnnotationImageWithIdentifier("pisa");

			if (annotationImage == null)
			{
				// Leaning Tower of Pisa by Stefan Spieler from the Noun Project.
				var image = UIImage.FromBundle("pisavector");

				// The anchor point of an annotation is currently always the center. To
				// shift the anchor point to the bottom of the annotation, the image
				// asset includes transparent bottom padding equal to the original image
				// height.
				//
				// To make this padding non-interactive, we create another image object
				// with a custom alignment rect that excludes the padding.
				image = image.ImageWithAlignmentRectInsets(new UIEdgeInsets(top: 0, left: 0, bottom: image.Size.Height / 2, right: 0));

				// Initialize the ‘pisa’ annotation image with the UIImage we just loaded.
				annotationImage = MGLAnnotationImage.AnnotationImageWithImage(image: image, reuseIdentifier: "pisa");
			}

			return annotationImage;
		}

		// Allow callout view to appear when an annotation is tapped.
		[Export("mapView:annotationCanShowCallout:")]
		public bool AnnotationCanShowCallout(MGLMapView mapView, NSObject annotation)
		{
			return true;
		}
	}
}