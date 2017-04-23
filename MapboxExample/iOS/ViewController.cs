using System;
using System.Collections.Generic;
using UIKit;

namespace MapboxExample.iOS
{
	public partial class ViewController : UIViewController
	{
		UITableView table;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			this.Title = "Mapbox Examples";
			table = new UITableView(View.Bounds); // defaults to Plain style
			Dictionary<string, List<string>> indexedTableItems = new Dictionary<string, List<string>>();
			indexedTableItems.Add("Style", new List<string>() { "Default styles", "Custom style", "Satellite styles", "Custom raster style", "Custom vector style" });
			indexedTableItems.Add("Annotations", new List<string>() { "Adding a marker", "Annotation views", "Add multiple annotations", "Custom marker image", "Drawing a GeoJSON line", "Drawing a polygon", "Annotation models", "Draggable annotation views" });
			indexedTableItems.Add("Runtime Styling", new List<string>() { "Add and toggle a layer", "Dynamically-styled line", "Animated line", "Dynamically-styled circles", "Dynamically-styled interactive points", "Feature selection", "Add a shape collection feature", "Custom raster source" });
			indexedTableItems.Add("Data-Driven Styling", new List<string>() { "Clustered point data", "Data-driven circles", "Select a feature within a layer" });
			indexedTableItems.Add("Callouts", new List<string>() { "Callout delegate usage", "Custom callout view" });
			indexedTableItems.Add("Offline", new List<string>() { "Offline pack" });
			indexedTableItems.Add("Miscellaneous", new List<string>() { "Camera animation", "Point conversion" });

			table.Source = new TableSource(indexedTableItems, this);

			Add(table);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
