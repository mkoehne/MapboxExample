using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;
using System.Linq;

namespace MapboxExample.iOS
{
	public partial class DrawingAGeoJSONLineViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;

		public DrawingAGeoJSONLineViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// Create a MapView
			mapView = new MGLMapView(View.Bounds);
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(45.5076, -122.6736), 11, false);
			mapView.WeakDelegate = this;

			View.AddSubview(mapView);

			DrawPolyline();
		}

		void DrawPolyline()
		{

			var jsonPath = NSBundle.MainBundle.PathForResource("example", "geojson");
			NSData data = NSFileManager.DefaultManager.Contents(jsonPath);
			NSError err;
			MGLShapeCollectionFeature shapeCollectionFeature = (MGLShapeCollectionFeature)MGLShape.ShapeWithData(data, (uint)NSStringEncoding.UTF8, out err);
			MGLPolylineFeature polyline = (MGLPolylineFeature)shapeCollectionFeature.Shapes.First();

			mapView.AddAnnotation(polyline);
		}

		[Export("mapView:alphaForShapeAnnotation:")]
		public virtual nfloat AlphaForShapeAnnotation(MGLMapView mapView, MGLShape annotation)
		{
			return 1;
		}

		[Export("mapView:lineWidthForPolylineAnnotation:")]
		public virtual nfloat LineWidthForPolylineAnnotation(MGLMapView mapView, MGLPolyline annotation)
		{
			return 2;
		}

		[Export("mapView:strokeColorForShapeAnnotation:")]
		public virtual UIColor StrokeColorForShapeAnnotation(MGLMapView mapView, MGLShape annotation)
		{
			if (annotation.Title == "Crema to Council Crest" && annotation is MGLPolyline)
			{
				// Mapbox cyan
				return new UIColor(red: 59 / 255, green: 178 / 255, blue: 208 / 255, alpha: 1);
			}
			else
			{
				return UIColor.Red;
			}
		}
	}
}