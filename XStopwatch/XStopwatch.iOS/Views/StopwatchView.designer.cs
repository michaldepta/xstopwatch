// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XStopwatch.iOS.Views
{
    [Register ("StopwatchView")]
    partial class StopwatchView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StartStop { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
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
        }
    }
}