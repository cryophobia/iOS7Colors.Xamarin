using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace IOS7Colors
{
	public partial class CLAViewController : DialogViewController
	{
		Dictionary<string, UIColor> _colorPalette;

		public CLAViewController () : base (UITableViewStyle.Grouped, null)
		{
				InitColors();
		}

		void InitColors ()
		{
			_colorPalette = new Dictionary<string, UIColor>();
			_colorPalette.Add("red", new IOS7RedColor());
			_colorPalette.Add("orange", new IOS7OrangeColor());
			_colorPalette.Add("yellow", new IOS7YellowColor());
			_colorPalette.Add("green", new IOS7GreenColor());
			_colorPalette.Add("light blue", new IOS7LightBlueColor());
			_colorPalette.Add("dark blue", new IOS7DarkBlueColor());
			_colorPalette.Add("purple", new IOS7PurpleColor());
			_colorPalette.Add("pink", new IOS7PinkColor());
			_colorPalette.Add("dark gray", new IOS7DarkGrayColor());
			_colorPalette.Add("light gray", new IOS7LightGrayColor());
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			InitView();
		}

		private void InitView(){

			Root = new RootElement ("iOS 7 Colors") {
				new Section ("") {
					from palette in _colorPalette
						select Item(palette.Key)
				}
			};
		}

		private StyledStringElement Item(string caption){
			var item = new StyledStringElement(caption);
			item.TextColor = _colorPalette[caption];
			return item;
		}
	}
}
