using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;
using System.Linq;
using System.Collections.Generic;

namespace MapboxExample.iOS
{
	public partial class DrawingAPolygonViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public DrawingAPolygonViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// Create a MapView
			mapView = new MGLMapView(View.Bounds);
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(45.520486, -122.673541), 11, false);
			mapView.WeakDelegate = this;

			View.AddSubview(mapView);

			DrawShape();
		}

		void DrawShape()
		{
			List<CLLocationCoordinate2D> coordinates = new List<CLLocationCoordinate2D>(){
				new CLLocationCoordinate2D(45.522585, -122.685699),
				new CLLocationCoordinate2D(45.534611, -122.708873),
				new CLLocationCoordinate2D(45.530883, -122.678833),
				new CLLocationCoordinate2D(45.547115, -122.667503),
				new CLLocationCoordinate2D(45.530643, -122.660121),
				new CLLocationCoordinate2D(45.533529, -122.636260),
				new CLLocationCoordinate2D(45.521743, -122.659091),
				new CLLocationCoordinate2D(45.510677, -122.648792),
				new CLLocationCoordinate2D(45.515008, -122.664070),
				new CLLocationCoordinate2D(45.502496, -122.669048),
				new CLLocationCoordinate2D(45.515369, -122.678489),
				new CLLocationCoordinate2D(45.506346, -122.702007),
				new CLLocationCoordinate2D(45.522585, -122.685699)
			};

			var coords = coordinates.ToArray();

			MGLPolygon shape = MGLPolygon.PolygonWithCoordinates(ref coords[0], (uint)coords.Count());

			mapView.AddAnnotation(shape);
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
			return UIColor.White;
		}

		[Export("mapView:fillColorForPolygonAnnotation:")]
		public virtual UIColor FillColorForPolygonAnnotation(MGLMapView mapView, MGLPolygon annotation)
		{
			return new UIColor(59.0f / 255.0f, 178.0f / 255.0f, 208.0f / 255.0f, 1.0f);

		}
	}
}