# Mapbox iOS and Android SDK Examples


A Xamarin project that provides the Mapbox iOS SDK's [public examples](https://www.mapbox.com/ios-sdk/examples/) and Android SDK´s [public examples](https://www.mapbox.com/android-sdk/examples/).

### Configure your Xamarin.iOS project
Once you have generated an access token, you need to set it up within your app. There are two ways to provide an access token in your app:

1. In the Info.plist file set MGLMapboxAccessToken with the value of your token.
2. In the AppDelegate.FinishedLaunching method, call AccountManager.AccessToken = "YOUR-TOKEN";

### Configure your Xamarin.Android project
Once you have generated an access token, you need to set it up within your app:

1. In Strings.xml set the access_token with the value of your token.
2. In your MainActivity call MapboxAccountManager.Start(this, Resources.GetString(Resource.String.access_token));

### Other helpful links
- [Mapbox iOS SDK API documentation](https://www.mapbox.com/ios-sdk/api/)
- [First steps with the Mapbox iOS SDK](https://www.mapbox.com/help/first-steps-ios-sdk/)
- [Mapbox Android SDK API documentation](https://www.mapbox.com/android-sdk/api/)
- [First steps with the Mapbox Android SDK](https://www.mapbox.com/help/first-steps-android-sdk/)

### Thanks
Thanks to [NAXAM](https://github.com/NAXAM) for the Xamarin Mapbox bindings.
