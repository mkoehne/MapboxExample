using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace MapboxExample.iOS
{
	public class TableSource : UITableViewSource
	{
		UIViewController owner;
		Dictionary<string, List<string>> TableItems;
		string CellIdentifier = "TableCell";

		public TableSource(Dictionary<string, List<string>> items, UIViewController owner)
		{
			this.owner = owner;
			TableItems = items;
		}
		public override nint NumberOfSections(UITableView tableView)
		{
			return TableItems.Count;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{

			return TableItems.Values.ElementAt((int)section).Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, false);
			UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
			switch (indexPath.Section)
			{
				case 0:
					switch (indexPath.Row)
					{
						case 0:
							DefaultStylesViewController defaultstylesViewController = storyboard.InstantiateViewController("DefaultStylesViewController") as DefaultStylesViewController;
							owner.NavigationController.PushViewController(defaultstylesViewController, true);
							break;
						case 1:
							CustomStyleViewController customstyleViewController = storyboard.InstantiateViewController("CustomStyleViewController") as CustomStyleViewController;
							owner.NavigationController.PushViewController(customstyleViewController, true);
							break;
						case 2:
							SatelliteStylesViewController satelliteStylesViewController = storyboard.InstantiateViewController("SatelliteStylesViewController") as SatelliteStylesViewController;
							owner.NavigationController.PushViewController(satelliteStylesViewController, true);
							break;
						case 3:
							CustomRasterStyleViewController customRasterStyleViewController = storyboard.InstantiateViewController("CustomRasterStyleViewController") as CustomRasterStyleViewController;
							owner.NavigationController.PushViewController(customRasterStyleViewController, true);
							break;
						case 4:
							CustomVectorStyleViewController customVectorStyleViewController = storyboard.InstantiateViewController("CustomVectorStyleViewController") as CustomVectorStyleViewController;
							owner.NavigationController.PushViewController(customVectorStyleViewController, true);
							break;
						default:
							break;
					}
					break;
				case 1:
					switch (indexPath.Row)
					{
						case 0:
							AddingAMarkerViewController addingAMarkerViewController = storyboard.InstantiateViewController("AddingAMarkerViewController") as AddingAMarkerViewController;
							owner.NavigationController.PushViewController(addingAMarkerViewController, true);
							break;
						case 1:
							AnnotationViewsViewController annotationViewsViewController = storyboard.InstantiateViewController("AnnotationViewsViewController") as AnnotationViewsViewController;
							owner.NavigationController.PushViewController(annotationViewsViewController, true);
							break;
						case 2:
							AddMultipleAnnotationsViewController addMultipleAnnotationsViewController = storyboard.InstantiateViewController("AddMultipleAnnotationsViewController") as AddMultipleAnnotationsViewController;
							owner.NavigationController.PushViewController(addMultipleAnnotationsViewController, true);
							break;
						case 3:
							CustomMarkerImageViewController customMarkerImageViewController = storyboard.InstantiateViewController("CustomMarkerImageViewController") as CustomMarkerImageViewController;
							owner.NavigationController.PushViewController(customMarkerImageViewController, true);
							break;
						case 4:
							DrawingAGeoJSONLineViewController drawingAGeoJSONLineViewController = storyboard.InstantiateViewController("DrawingAGeoJSONLineViewController") as DrawingAGeoJSONLineViewController;
							owner.NavigationController.PushViewController(drawingAGeoJSONLineViewController, true);
							break;
						case 5:
							DrawingAPolygonViewController drawingAPolygonViewController = storyboard.InstantiateViewController("DrawingAPolygonViewController") as DrawingAPolygonViewController;
							owner.NavigationController.PushViewController(drawingAPolygonViewController, true);
							break;
						case 6:
							AnnotationModelsViewController annotationModelsViewController = storyboard.InstantiateViewController("AnnotationModelsViewController") as AnnotationModelsViewController;
							owner.NavigationController.PushViewController(annotationModelsViewController, true);
							break;
						case 7:
							DraggableAnnotationViewsViewController draggableAnnotationViewsViewController = storyboard.InstantiateViewController("DraggableAnnotationViewsViewController") as DraggableAnnotationViewsViewController;
							owner.NavigationController.PushViewController(draggableAnnotationViewsViewController, true);
							break;
						default:
							break;
					}
					break;
				case 2:
					switch (indexPath.Row)
					{
						case 0:
							AddAndToggleALayerViewController addAndToggleALayerViewController = storyboard.InstantiateViewController("AddAndToggleALayerViewController") as AddAndToggleALayerViewController;
							owner.NavigationController.PushViewController(addAndToggleALayerViewController, true);
							break;
						case 1:
							DynamicallyStyledLineViewController dynamicallyStyledLineViewController = storyboard.InstantiateViewController("DynamicallyStyledLineViewController") as DynamicallyStyledLineViewController;
							owner.NavigationController.PushViewController(dynamicallyStyledLineViewController, true);
							break;
						case 2:
							AnimatedLineViewController animatedLineViewController = storyboard.InstantiateViewController("AnimatedLineViewController") as AnimatedLineViewController;
							owner.NavigationController.PushViewController(animatedLineViewController, true);
							break;
						case 3:
							DynamicallyStyledCirclesViewController dynamicallyStyledCirclesViewController = storyboard.InstantiateViewController("DynamicallyStyledCirclesViewController") as DynamicallyStyledCirclesViewController;
							owner.NavigationController.PushViewController(dynamicallyStyledCirclesViewController, true);
							break;
						case 4:
							DynamicallyStyledInteractivePointsViewController dynamicallyStyledInteractivePointsViewController = storyboard.InstantiateViewController("DynamicallyStyledInteractivePointsViewController") as DynamicallyStyledInteractivePointsViewController;
							owner.NavigationController.PushViewController(dynamicallyStyledInteractivePointsViewController, true);
							break;
						case 5:
							FeatureSelectionViewController featureSelectionViewController = storyboard.InstantiateViewController("FeatureSelectionViewController") as FeatureSelectionViewController;
							owner.NavigationController.PushViewController(featureSelectionViewController, true);
							break;
						case 6:
							AddAShapeCollectionFeatureViewController addAShapeCollectionFeatureViewController = storyboard.InstantiateViewController("AddAShapeCollectionFeatureViewController") as AddAShapeCollectionFeatureViewController;
							owner.NavigationController.PushViewController(addAShapeCollectionFeatureViewController, true);
							break;
						case 7:
							CustomRasterSourceViewController customRasterSourceViewController = storyboard.InstantiateViewController("CustomRasterSourceViewController") as CustomRasterSourceViewController;
							owner.NavigationController.PushViewController(customRasterSourceViewController, true);
							break;
						default:
							break;
					}
					break;
				case 3:
					switch (indexPath.Row)
					{
						default:
							break;
					}
					break;
				case 4:
					switch (indexPath.Row)
					{
						default:
							break;
					}
					break;
				case 5:
					switch (indexPath.Row)
					{
						default:
							break;
					}
					break;
				case 6:
					switch (indexPath.Row)
					{
						default:
							break;
					}
					break;
				default:
					break;
			}

		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = TableItems.Values.ElementAt(indexPath.Section).ElementAt(indexPath.Row);

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = item;

			return cell;
		}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			return TableItems.Keys.ElementAt((int)section);
		}

	}
}