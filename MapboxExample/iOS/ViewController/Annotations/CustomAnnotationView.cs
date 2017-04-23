using System;
using CoreAnimation;
using Mapbox;
using UIKit;

namespace MapboxExample.iOS
{
	public class CustomAnnotationView : MGLAnnotationView
	{
		public CustomAnnotationView()
		{
		}

		public CustomAnnotationView(string reuseIdentifier) : base(reuseIdentifier)
		{
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			// Force the annotation view to maintain a constant size when the map is tilted.
			ScalesWithViewingDistance = false;

			// Use CALayer’s corner radius to turn this view into a circle.
			this.Layer.CornerRadius = this.Frame.Width / 2;
			this.Layer.BorderWidth = 2;
			this.Layer.BorderColor = UIColor.White.CGColor;
		}

		public override void SetSelected(bool selected, bool animated)
		{
			base.SetSelected(selected, animated);

			var animation = CABasicAnimation.FromKeyPath("borderWidth");
			animation.Duration = 0.1;
			this.Layer.BorderWidth = selected ? this.Frame.Width / 4 : 2;
			this.Layer.AddAnimation(animation, "borderWidth");

		}
	}
}
