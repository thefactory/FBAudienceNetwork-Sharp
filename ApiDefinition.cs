using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using System.Drawing;

namespace MonoTouch.FacebookConnect {

    [BaseType (typeof (NSObject))]
    public partial interface FBAdImage {

        [Export ("url", ArgumentSemantic.Copy)]
        NSUrl Url { get; }

        [Export ("width")]
        int Width { get; }

        [Export ("height")]
        int Height { get; }

        [Export ("initWithURL:width:height:")]
        IntPtr Constructor (NSUrl url, int width, int height);

        [Field ("FacebookAdsSDKErrorDomain", "__Internal")]
        NSString FacebookAdsSDKErrorDomain { get; }
    }

    [BaseType (typeof (NSObject))]
    public partial interface FBAdSettings {

        [Static, Export ("addTestDevice:")]
        void AddTestDevice (string deviceHash);

        [Static, Export ("addTestDevices:")]
        void AddTestDevices (string [] devicesHash);

        [Static, Export ("clearTestDevices")]
        void ClearTestDevices ();

        [Static, Export ("isChildDirected")]
        bool IsChildDirected { set; }

        [Static, Export ("urlPrefix")]
        string UrlPrefix { set; }
    }

    [BaseType (typeof (UIView))]
    public partial interface FBAdView : IUIWebViewDelegate {

        [Export ("initWithPlacementID:adSize:rootViewController:")]
        IntPtr Constructor (string placementID, SizeF adSize, UIViewController viewController);

        [Export ("loadAd")]
        void LoadAd ();

        [Export ("disableAutoRefresh")]
        void DisableAutoRefresh ();

        [Export ("placementID", ArgumentSemantic.Copy)]
        string PlacementID { get; }

        [Export ("rootViewController", ArgumentSemantic.Assign)]
        UIViewController RootViewController { get; }

        [Export ("delegate", ArgumentSemantic.Assign)]
        FBAdViewDelegate Delegate { get; set; }
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface FBAdViewDelegate {

        [Export ("adViewDidClick:")]
        void  DidClick (FBAdView adView);

        [Export ("adViewDidFinishHandlingClick:")]
        void  DidFinishHandlingClick (FBAdView adView);

        [Export ("adViewDidLoad:")]
        void  DidLoad (FBAdView adView);

        [Export ("adView:didFailWithError:")]
        void DidFailWithError (FBAdView adView, NSError error);

        [Export ("adViewWillLogImpression:")]
        void  WillLogImpression (FBAdView adView);

        [Export ("viewControllerForPresentingModalView")]
        UIViewController ViewControllerForPresentingModalView { get; }

        [Field ("FacebookAdsSDKErrorDomain", "__Internal")]
        NSString FacebookAdsSDKErrorDomain { get; }

        [Field ("kFBAdSize320x50", "__Internal")]
        SizeF FBAdSize320x50 { get; }

        [Field ("kFBAdSizeHeight50Banner", "__Internal")]
        SizeF FBAdSizeHeight50Banner { get; }

        [Field ("kFBAdSizeHeight90Banner", "__Internal")]
        SizeF FBAdSizeHeight90Banner { get; }

        [Field ("kFBAdSizeInterstital", "__Internal")]
        SizeF FBAdSizeInterstital { get; }

    }

    [BaseType (typeof (UIViewController))]
    public partial interface FBInterstitialAd : FBAdViewDelegate {

        [Export ("placementID", ArgumentSemantic.Copy)]
        string PlacementID { get; }

        [Wrap ("WeakDelegate")]
        IFBInterstitialAdDelegate Delegate { get; set; }

        [Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
        IFBInterstitialAdDelegate WeakDelegate { get; set; }

        [Export ("initWithPlacementID:")]
        IntPtr Constructor (string placementID);

        [Export ("isAdValid")]
        bool IsAdValid { get; }

        [Export ("loadAd")]
        void LoadAd ();

        [Export ("showAdFromRootViewController:")]
        bool ShowAdFromRootViewController (UIViewController rootViewController);
    }

    [Model, Protocol, BaseType (typeof (NSObject))]
    public partial interface FBInterstitialAdDelegate {

        [Export ("interstitialAdDidClick:")]
        void  DidClick (FBInterstitialAd interstitialAd);

        [Export ("interstitialAdDidClose:")]
        void  DidClose (FBInterstitialAd interstitialAd);

        [Export ("interstitialAdWillClose:")]
        void  WillClose (FBInterstitialAd interstitialAd);

        [Export ("interstitialAdDidLoad:")]
        void  DidLoad (FBInterstitialAd interstitialAd);

        [Export ("interstitialAd:didFailWithError:")]
        void DidFailWithError (FBInterstitialAd interstitialAd, NSError error);

        [Export ("interstitialAdWillLogImpression:")]
        void  WillLogImpression (FBInterstitialAd interstitialAd);

        [Export ("starRating", ArgumentSemantic.Assign)]
        FBAdStarRating StarRating { get; }
    }

    public interface IFBInterstitialAdDelegate {}

    [BaseType (typeof (NSObject))]
    public partial interface FBNativeAd {

        [Export ("placementID", ArgumentSemantic.Copy)]
        string PlacementID { get; }

        [Export ("starRating", ArgumentSemantic.Assign)]
        FBAdStarRating StarRating { get; }

        [Export ("title", ArgumentSemantic.Copy)]
        string Title { get; }

        [Export ("socialContext", ArgumentSemantic.Copy)]
        string SocialContext { get; }

        [Export ("callToAction", ArgumentSemantic.Copy)]
        string CallToAction { get; }

        [Export ("icon", ArgumentSemantic.Retain)]
        FBAdImage Icon { get; }

        [Export ("coverImage", ArgumentSemantic.Retain)]
        FBAdImage CoverImage { get; }

        [Export ("body", ArgumentSemantic.Copy)]
        string Body { get; }

        [Wrap ("WeakDelegate")]
        IFBNativeAdDelegate Delegate { get; set; }

        [Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
        IFBNativeAdDelegate WeakDelegate {get; set; }

        [Export ("initWithPlacementID:")]
        IntPtr Constructor (string placementID);

        [Export ("registerViewForInteraction:withViewController:")]
        void RegisterViewForInteraction (UIView view, UIViewController viewController);

        [Export ("registerViewForInteraction:withViewController:withClickableViews:")]
        void RegisterViewForInteraction (UIView view, UIViewController viewController, UIView [] clickableViews);

        [Export ("unregisterView")]
        void UnregisterView ();

        [Export ("loadAd")]
        void LoadAd ();

        [Export ("isAdValid")]
        bool IsAdValid { get; }
    }

    [BaseType (typeof (NSObject))]
    [Model, Protocol]
    public partial interface FBNativeAdDelegate {

        [Export ("nativeAdDidLoad:")]
        void DidLoad (FBNativeAd nativeAd);

        [Export ("nativeAdWillLogImpression:")]
        void  WillLogImpression (FBNativeAd nativeAd);

        [Export ("nativeAd:didFailWithError:")]
        void DidFailWithError (FBNativeAd nativeAd, NSError error);

        [Export ("nativeAdDidClick:")]
        void  DidClick (FBNativeAd nativeAd);

        [Export ("nativeAdDidFinishHandlingClick:")]
        void  DidFinishHandlingClick (FBNativeAd nativeAd);
    }

    public interface IFBNativeAdDelegate {}
}
