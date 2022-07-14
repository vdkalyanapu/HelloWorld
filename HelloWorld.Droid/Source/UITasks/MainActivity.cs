using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Content.PM;
//using Apacheta.Utilities.IO;
using Android.Content;
using Android;
using System.Text;
using AndroidX.Core.App;
using System.Collections.Generic;
using AndroidX.Core.Content;
using Android.App;
using AceCoreAndroid;
using Apacheta.Utilities.IO;
using HelloWorld.DAO;
using System.IO;

namespace HelloWorld.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, NoHistory = true)]
    public class MainActivity : AppCompatActivity
    {
        public const string TAG = "SplashScreen";
        private const int PERMISSION_RESULT = 2222;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (!NeedPermissions())
            {
                InitializeApplicationState();
                StartApplication();
            }
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            int index = 0;
            foreach (var result in grantResults)
            {
                if (result == Permission.Denied)
                {
                    var dialog = new Android.App.AlertDialog.Builder(this)
                                 .SetNeutralButton("OK", (sender, args) =>
                                 {
                                     var intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings);
                                     intent.SetData(Android.Net.Uri.Parse("package:" + PackageName));
                                     StartActivity(intent);
                                 })
                                .SetMessage($"TransportACE requires the following permissions:{System.Environment.NewLine}{System.Environment.NewLine}{GetPermissionName(permissions)}" +
                                                    $"{System.Environment.NewLine}")
                                .SetCancelable(false)
                                .Create();

                    dialog.SetCanceledOnTouchOutside(false);
                    dialog.SetCancelable(false);
                    dialog.Show();

                    return;
                }
                index++;
            }

            if (!NeedPermissions())
            {
                InitializeApplicationState();
                StartApplication();
            }
        }

        private void StartApplication()
        {

            //AceLogger.Initialize("TransportACE.Droid", AceLogger.LogLevels.DEBUG, System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Apacheta/Logs");
            //Logging.StartListening();
            //AceLogger.LogMessage(TAG, AceLogger.LogLevels.INFORMATIONAL, "Application is starting....");

            InitializeApplicationState();

            //AceLogger.LogMessage(TAG, AceLogger.LogLevels.INFORMATIONAL, "Application is initialized.");

            //try
            //{
            //    AceLogger.LogMessage(TAG, AceLogger.LogLevels.INFORMATIONAL, "TransportACE version = " + PackageManager.GetPackageInfo(this.PackageName, 0).VersionName);
            //}
            //catch (PackageManager.NameNotFoundException ex)
            //{
            //    AceLogger.LogMessage(TAG, AceLogger.LogLevels.EXCEPTION, ex);
            //}

            BeginTheWorkflow();
        }

        public bool NeedPermissions()
        {

            List<string> permissions = new List<string>();

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
                permissions.Add(Manifest.Permission.WriteExternalStorage);

        

            if (permissions.Count > 0)
            {
                RequestPermission(permissions?.ToArray());
                return true;
            }

            return false;
        }

        private void RequestPermission(string[] permissions)
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, permissions[0]))
            {

                var dialog = new AndroidX.AppCompat.App.AlertDialog.Builder(this)
                                 .SetNeutralButton("OK", (sender, args) =>
                                 {
                                     ActivityCompat.RequestPermissions(this, permissions, PERMISSION_RESULT);
                                 })
                                .SetTitle("TransportACE Permission Detailed Reasons")
                                .SetMessage($"TransportACE requires the following permissions:{System.Environment.NewLine}{System.Environment.NewLine}{GetPermissionName(permissions)}" +
                                                    $"{System.Environment.NewLine}")
                                .SetCancelable(false)
                                .Create();

                dialog.SetCanceledOnTouchOutside(false);
                dialog.SetCancelable(false);
                dialog.Show();
            }
            else
                ActivityCompat.RequestPermissions(this, permissions, PERMISSION_RESULT);
        }

        private string GetPermissionName(string[] permissions)
        {
            if ((permissions?.Length ?? 0) == 0)
                return null;

            StringBuilder permissionName = new StringBuilder();

            foreach (var permission in permissions)
            {
                if (permission == Manifest.Permission.AccessCoarseLocation && permissionName.ToString().Contains(GetString(Resource.String.location)))
                    continue;

                if (permission == Manifest.Permission.WriteExternalStorage && permissionName.ToString().Contains(GetString(Resource.String.storage_access)))
                    continue;

                //de-dupe permission names to be displayed in alert
                if (!permissionName.ToString().Contains(GetPermissionName(permission)))
                    permissionName.Append($"{GetPermissionName(permission)}{System.Environment.NewLine}");
            }



            return permissionName.Remove(permissionName.Length - 2, 2).ToString();
        }
        private string GetPermissionName(string permission)
        {
            switch (permission)
            {
                case Manifest.Permission.AccessFineLocation:
                case Manifest.Permission.AccessCoarseLocation:
                case Manifest.Permission.AccessBackgroundLocation:
                    return GetString(Resource.String.location) + GetString(Resource.String.location_detail);
                case Manifest.Permission.Camera:
                    return GetString(Resource.String.camera) + GetString(Resource.String.camera_detail);
                case Manifest.Permission.ReadExternalStorage:
                case Manifest.Permission.WriteExternalStorage:
                    return GetString(Resource.String.storage_access) + GetString(Resource.String.storage_access_detail);
                case Manifest.Permission.CallPhone:
                case Manifest.Permission.ReadPhoneState:
                    return GetString(Resource.String.phone) + GetString(Resource.String.phone_detail);
            }

            return null;
        }
        public void InitializeApplicationState()
        {
          AcePaths.RootFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Apacheta";// Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Apacheta");

            Database.DatabasePath = Path.Combine(AcePaths.RootFolder, "HelloWorld.db");
            Database.GenerateTables();
        }

      
       
        private void BeginTheWorkflow()
        {
            // required for first UI task in the application
            ApplicationSession.Instance.SubMethodStack.Push("method");
            ActivityHelper.SetOutcome(ActivityHelper.SPLASH_SCREEN, new Outcome(this, typeof(StartHere), ActivityHelper.TASK_TYPE.SYSTEM_TASK, "method_-3", null, false, ""));
            Finish();
        }
    }
}
