using Foundation;
using System;
using UIKit;
using Mapbox;
using CoreLocation;

namespace MapboxExample.iOS
{
	public partial class AddAndToggleALayerViewController : UIViewController, IMGLMapViewDelegate
	{
		MGLMapView mapView;
		MGLLineStyleLayer contoursLayer;
		UIButton button;

		protected AddAndToggleALayerViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// Create a MapView and set the coordinates/zoom
			mapView = new MGLMapView(View.Bounds);
			mapView.SetCenterCoordinate(new CLLocationCoordinate2D(37.745395, -119.594421), false);
			mapView.SetZoomLevel(11, false);

			View.AddSubview(mapView);

			mapView.WeakDelegate = this;

			button = new UIButton(UIButtonType.RoundedRect);
			button.Frame = new CoreGraphics.CGRect(10, 10, 150, 40);
			button.SetTitle("Toggle Contours", UIControlState.Normal);
			button.Selected = true;
			button.TouchUpInside += Button_TouchUpInside;
			mapView.Add(button);
		}

		void AddLayer(MGLStyle style)
		{
			var source = new MGLVectorSource(identifier: "contours", configurationURL: new NSUrl("mapbox://mapbox.mapbox-terrain-v2"));
			var layer = new MGLLineStyleLayer(identifier: "contours", source: source);

			layer.SourceLayerIdentifier = "contour";
			layer.LineJoin = MGLStyleValue.ValueWithRawValue(NSValue.FromObject(MGLLineJoin.Round));
			layer.LineCap = MGLStyleValue.ValueWithRawValue(NSValue.FromObject(MGLLineCap.Round));

			layer.LineColor = MGLStyleValue.ValueWithRawValue(UIColor.Brown);

			layer.LineWidth = MGLStyleValue.ValueWithRawValue(NSValue.FromObject(1.0));
			style.AddSource(source);

			style.AddLayer(layer);
			contoursLayer = layer;

		}

		void Button_TouchUpInside(object sender, EventArgs e)
		{
			if (button.Selected)
			{
				contoursLayer.Visible = false;
				button.Selected = false;
			}
			else
			{
				contoursLayer.Visible = true;
				button.Selected = true;
			}
		}

		[Export("mapView:didFinishLoadingStyle:")]
		public void MapView(MGLMapView mapView, MGLStyle style)
		{
			AddLayer(style);
		}

		[Export("mapView:annotationCanShowCallout:")]
		public bool AnnotationCanShowCallout(MGLMapView mapView, NSObject annotation)
		{
			return true;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
