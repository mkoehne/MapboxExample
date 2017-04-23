using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;
using CoreGraphics;

namespace MapboxExample.iOS
{
	public partial class AddMultipleAnnotationsViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public AddMultipleAnnotationsViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			mapView = new MGLMapView(View.Bounds, MGLStyle.LightStyleURLWithVersion(9));

			// Set the map’s center coordinate and zoom level.
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(36.54, -116.97), 9, false);

			// Set the delegate property of our map view to `self` after instantiating it.
			mapView.WeakDelegate = this;

			View.AddSubview(mapView);

			MyCustomPointAnnotation pointA = new MyCustomPointAnnotation();
			pointA.Coordinate = new CLLocationCoordinate2D(36.4623, -116.8656);
			pointA.Title = "Stovepipe Wells";
			pointA.WillUseImage = true;

			MyCustomPointAnnotation pointB = new MyCustomPointAnnotation();
			pointB.Coordinate = new CLLocationCoordinate2D(36.6071, -117.1458);
			pointB.Title = "Furnace Creek";
			pointB.WillUseImage = true;

			MyCustomPointAnnotation pointC = new MyCustomPointAnnotation();
			pointC.Coordinate = new CLLocationCoordinate2D(36.4208, -116.8101);
			pointC.Title = "Zabriskie Point";

			MyCustomPointAnnotation pointD = new MyCustomPointAnnotation();
			pointD.Coordinate = new CLLocationCoordinate2D(36.6836, longitude: -117.1005);
			pointD.Title = "Mesquite Flat Sand Dunes";

			MyCustomPointAnnotation[] myPlaces = new MyCustomPointAnnotation[4] { pointA, pointB, pointC, pointD };

			mapView.AddAnnotations(myPlaces); ;

		}

		// Use the default marker. See also: our view annotation or custom marker examples.
		[Export("viewForAnnotation:")]
		public MGLAnnotationView ViewForAnnotation(IMGLAnnotation annotation)
		{
			if (annotation is MyCustomPointAnnotation)
			{
				var anno = (MyCustomPointAnnotation)annotation;
				if (!anno.WillUseImage)
				{
					return null;
				}
				var reuseIdentifier = "reusableDotView";

				// For better performance, always try to reuse existing annotations.
				var annotationView = mapView.DequeueReusableAnnotationViewWithIdentifier(reuseIdentifier);
				if (annotationView == null)
				{
					annotationView = new MGLAnnotationView(reuseIdentifier);
					annotationView.Frame = new CGRect(0, 0, 30, 30);
					annotationView.Layer.CornerRadius = (annotationView.Frame.Size.Width) / 2;
					annotationView.Layer.BorderWidth = (nfloat)4.0;
					annotationView.Layer.BorderColor = UIColor.White.CGColor;
					annotationView.BackgroundColor = new UIColor((nfloat)0.03, (nfloat)0.80, (nfloat)0.69, (nfloat)1.0);
				}

				return annotationView;
			}
			else
			{
				return null;
			}
		}

		[Export("mapView:imageForAnnotation:")]
		public virtual MGLAnnotationImage ImageForAnnotation(MGLMapView mapView, NSObject annotation)
		{
			if (annotation is MyCustomPointAnnotation)
			{
				var castAnnotation = (MyCustomPointAnnotation)annotation;
				if (!castAnnotation.WillUseImage)
				{
					return null;
				}

				// For better performance, always try to reuse existing annotations.
				var annotationImage = mapView.DequeueReusableAnnotationImageWithIdentifier("camera");

				// If there is no reusable annotation image available, initialize a new one.
				if (annotationImage == null)
				{
					annotationImage = MGLAnnotationImage.AnnotationImageWithImage(UIImage.FromBundle("camera"), "camera");
				}

				return annotationImage;
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