using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;
using System.Collections.Generic;
using System.Linq;

namespace MapboxExample.iOS
{
	public partial class AnnotationModelsViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public AnnotationModelsViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// Create a MapView
			mapView = new MGLMapView(View.Bounds);
			mapView.StyleURL = MGLStyle.LightStyleURLWithVersion(9);
			mapView.TintColor = UIColor.DarkGray;
			mapView.SetZoomLevel(1, false);
			mapView.WeakDelegate = this;

			View.AddSubview(mapView);

			// Polyline
			// Create a coordinates array with all of the coordinates for our polyline.
			List<CLLocationCoordinate2D> coordinates = new List<CLLocationCoordinate2D>(){
				new CLLocationCoordinate2D(35, -25),
				new CLLocationCoordinate2D(20, -30),
				new CLLocationCoordinate2D(0, -25),
				new CLLocationCoordinate2D(-15, 0),
				new CLLocationCoordinate2D(-45, 10),
				new CLLocationCoordinate2D(-45, 40)
			};

			var coords = coordinates.ToArray();

			//TODO Use CustomPolyline
			MGLPolyline polyline = CustomPolyline.PolylineWithCoordinates(ref coords[0], (uint)coords.Count());

			// Set the custom `color` property, later used in the `mapView:strokeColorForShapeAnnotation:` delegate method.
			//((CustomPolyline)polyline).Color = UIColor.DarkGray;

			// Add the polyline to the map. Note that this method name is singular.
			mapView.AddAnnotation(polyline);


			// Point Annotations
			// Add a custom point annotation for every coordinate (vertex) in the polyline.
			List<CustomPointAnnotation> pointAnnotations = new List<CustomPointAnnotation>();

			foreach (var coordinate in coordinates)
			{
				CustomPointAnnotation point = new CustomPointAnnotation(coordinate, "Custom Point Annotation " + pointAnnotations.Count + 1, "");
				pointAnnotations.Add(point);
			}
			mapView.AddAnnotations(pointAnnotations.ToArray());
		}


		[Export("mapView:alphaForShapeAnnotation:")]
		public virtual nfloat AlphaForShapeAnnotation(MGLMapView mapView, MGLShape annotation)
		{
			return 0.5f;
		}

		[Export("mapView:lineWidthForPolylineAnnotation:")]
		public virtual nfloat LineWidthForPolylineAnnotation(MGLMapView mapView, MGLPolyline annotation)
		{
			return 2;
		}

		[Export("mapView:strokeColorForShapeAnnotation:")]
		public virtual UIColor StrokeColorForShapeAnnotation(MGLMapView mapView, MGLShape annotation)
		{
			if (annotation is CustomPolyline)
			{
				if (((CustomPolyline)annotation).Color == null)
				{
					return UIColor.Orange;
				}
				else
				{
					return ((CustomPolyline)annotation).Color;
				}
			}
			return UIColor.Orange;
		}

		[Export("mapView:fillColorForPolygonAnnotation:")]
		public virtual UIColor FillColorForPolygonAnnotation(MGLMapView mapView, MGLPolygon annotation)
		{
			return new UIColor(59.0f / 255.0f, 178.0f / 255.0f, 208.0f / 255.0f, 1.0f);

		}
	}
}