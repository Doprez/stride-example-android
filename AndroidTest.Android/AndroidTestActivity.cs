using Android.App;
using Android.OS;
using Android.Content.PM;
using Android.Widget;
using AndroidX.Core.Content;
using Stride.Engine;
using Stride.Starter;
using AndroidX.Core.App;
using System;
using Android;

namespace AndroidTest
{
    [Activity(MainLauncher = true, 
              Icon = "@mipmap/gameicon", 
              ScreenOrientation = ScreenOrientation.Landscape,
              Theme = "@android:style/Theme.NoTitleBar",
              ConfigurationChanges = ConfigChanges.UiMode | ConfigChanges.Orientation | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class AndroidTestActivity : StrideActivity
    {
        protected Game Game;

		private static int requestCodeMadeUp = 123456;

		protected override void OnRun()
        {
            base.OnRun();

            Game = new Game();
            Game.Run(GameContext);
        }

        protected override void OnDestroy()
        {
            Game.Dispose();

            base.OnDestroy();
        }

		private void CloseApplication()
		{
			if (Game != null) { Game.Dispose(); }

			System.Environment.Exit(0);
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			if (requestCode == requestCodeMadeUp)
			{
				if (grantResults.Length <= 0)
				{
					// If user interaction was interrupted, the permission request is cancelled and you
					// receive empty arrays.
					Toast.MakeText(this, "User interaction was cancelled. Please make sure to allow the requested permissions and restart the app.", ToastLength.Long).Show();
				}
				else if (grantResults[0] == PermissionChecker.PermissionGranted)
				{
					// Permission was granted.
					Toast.MakeText(this, "Permission Granted!", ToastLength.Long).Show();
				}
				else
				{
					// Permission denied.
					Toast.MakeText(this, "Permission Denied. Please make sure to allow the requested permissions and restart the app.", ToastLength.Long).Show();
				}
			}
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			try
			{
				// Add all required permissions to a list
				var requiredPermissions = new String[]
				{
					Manifest.Permission.Bluetooth,
					Manifest.Permission.BluetoothAdmin,
					Manifest.Permission.BluetoothScan,
					Manifest.Permission.BluetoothConnect
				};

				// Request permissions from requiredPermissions
				/// Always triggers <see cref="OnRequestPermissionsResult"/>, even if all permissions are already granted.
				ActivityCompat.RequestPermissions(this, requiredPermissions, requestCodeMadeUp);

				// Only run base.OnCreate if all permissions are granted, otherwise it would only throw an expception anyway, else close the app
				bool anyPermissionsDenied = false;

				foreach (string permission in requiredPermissions)
				{
					if ((int)ContextCompat.CheckSelfPermission(this, permission) == (int)Permission.Denied)
					{
						// A permission is denied, set to true; we need all permissions granted!
						anyPermissionsDenied = true;
					}
				}

				//if (!anyPermissionsDenied) 
				//{ 
					base.OnCreate(savedInstanceState); 
				//}
				//else { CloseApplication(); }
			}
			catch (Exception e)
			{
				CloseApplication();
			}
		}

	}
}
