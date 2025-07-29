using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UserRegitration.Controls
{	
	public partial class LoadingOverlay : ContentView
	{	
		public LoadingOverlay ()
		{
			InitializeComponent ();
		}

		public void Show()
        {
            this.IsVisible = true;
            OverlayStack.IsVisible = true;
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            loadingLabel.IsVisible = true;
        }

        public void Hide()
        {
            OverlayStack.IsVisible = false;
            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
            loadingLabel.IsVisible = false;
            this.IsVisible = false;
        }
    }
}

