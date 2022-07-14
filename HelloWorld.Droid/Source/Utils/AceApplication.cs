using System;
using System.IO;
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.Runtime;

namespace HelloWorld.Droid
{
#if DEBUG
    [Application(Icon = "@drawable/ApachetaIcon", Debuggable = true)]
#else
    [Application(Icon = "@drawable/ApachetaIcon", Debuggable=false)]
#endif
    public class AceApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public const string TAG = "AceApplication";

        public Application Instance { get; private set; }

        // required by Xamarin
        public AceApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

        public override void OnCreate()
        {
            base.OnCreate();

            Instance = this;

            // trap all unhandled exceptions and write to the log file
            // http://androidapi.xamarin.com/?link=E%3aAndroid.Runtime.AndroidEnvironment.UnhandledExceptionRaiser
            AndroidEnvironment.UnhandledExceptionRaiser += (s, e) =>
            {
                // tried logging to AceLogger but it was too slow. the process was killed before the log was written to disk
                using (var stream = File.CreateText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/crash_" + DateTime.Now.Ticks + ".txt"))
                {
                    stream.Write(DateTime.Now + "\r\n" + e.Exception.ToString());
                }
                e.Handled = true;
            };
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
          //  AceLogger.LogMessage(TAG, AceLogger.LogLevels.INFORMATIONAL, "App is terminated.");
        }

        #region IActivityLifecycleCallbacks Members
        public void OnActivityStarted(Activity activity)
        {
        }

        public void OnActivityStopped(Activity activity)
        {
        }
        public void OnActivityCreated(Activity activity, Android.OS.Bundle savedInstanceState)
        {
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
        }

        public void OnActivitySaveInstanceState(Activity activity, Android.OS.Bundle outState)
        {
        }

        public override void OnLowMemory()
        {
            //AceLogger.LogMessage("AceApplication", "OnLowMemory()");
            base.OnLowMemory();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}