using System;
using CoreLocation;
using Mapbox;

namespace MapboxExample.iOS
{
	public class CustomPointAnnotation : MGLAnnotation
	{
		CLLocationCoordinate2D coordinate;
		string title;
		string subtitle;

		public CustomPointAnnotation()
		{
		}

		public CustomPointAnnotation(CLLocationCoordinate2D coordinate, string title, string subtitle)
		{
			this.coordinate = coordinate;
			this.title = title;
			this.subtitle = subtitle;
		}

		public override CLLocationCoordinate2D Coordinate
		{
			get
			{
				return this.coordinate;
			}
		}

		public override string Title
		{
			get
			{
				return this.title;
			}
		}

		public override string Subtitle
		{
			get
			{
				return this.subtitle;
			}
		}
	}
}
