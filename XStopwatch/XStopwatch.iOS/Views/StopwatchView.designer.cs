// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XStopwatch.iOS.Views
{
	[Register ("StopwatchView")]
	partial class StopwatchView
	{
		[Outlet]
		UIKit.UIButton Clear { get; set; }

		[Outlet]
		UIKit.UIButton StartStop { get; set; }

		[Outlet]
		UIKit.UILabel TimeElapsed { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StartStop != null) {
				StartStop.Dispose ();
				StartStop = null;
			}

			if (TimeElapsed != null) {
				TimeElapsed.Dispose ();
				TimeElapsed = null;
			}

			if (Clear != null) {
				Clear.Dispose ();
				Clear = null;
			}
		}
	}
}
