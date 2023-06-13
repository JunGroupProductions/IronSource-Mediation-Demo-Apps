﻿using System;
using CoreGraphics;
using Foundation;
using IronSourceiOS;
using UIKit;

namespace DemoApp_iOS
{
    public class BannerWrapper : LevelPlayBannerDelegate
    {
        readonly UIViewController parent;
        ISBannerView bannerView = null;

        public bool DestroyBanner()
        {
            if (bannerView != null)
            {
                IronSource.DestroyBanner(bannerView);
                bannerView = null;
                return true;
            }
            return false;
        }

        public override void didClickWithAdInfo(ISAdInfo adInfo)
        {
        }

        public override void didDismissScreenWithAdInfo(ISAdInfo adInfo)
        {
        }

        public override void didFailToLoadWithError(NSError error)
        {
        }

        public override void didLeaveApplicationWithAdInfo(ISAdInfo adInfo)
        {
        }

        public override void didLoad(ISBannerView bannerView, ISAdInfo adInfo)
        {
            InvokeOnMainThread(() =>
            {

                this.bannerView = bannerView;

                nfloat y = this.parent.View.Frame.Size.Height - (bannerView.Frame.Size.Height / 2);
                if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                {
                    y -= this.parent.View.SafeAreaInsets.Bottom;
                }
                bannerView.Center = new CGPoint(this.parent.View.Frame.Size.Width / 2, y);

                this.parent.View.AddSubview(bannerView);
                bannerView.AccessibilityLabel = "bannerContainer";

            });
        }

        public override void didPresentScreenWithAdInfo(ISAdInfo adInfo)
        {
        }

        public BannerWrapper(UIViewController viewController)
        {
            this.parent = viewController;
        }


    }

}
