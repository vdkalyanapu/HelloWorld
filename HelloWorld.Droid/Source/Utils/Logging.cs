using System;
using System.Text;
using Android.Util;
using Apacheta.Utilities.IO;
using System.Collections;

namespace HelloWorld.Droid
{
    public static class Logging
    {
        public const string TAG = "TransportACE";

        public static void StartListening()
        {
            AceLogger.OnLoggedMessage += (object sender, AceLoggerEventArgs e) =>
                {
                    string logMsg = e.Category + " - " + e.Message;
                    switch (e.LogLevel)
                    {
                        case AceLogger.LogLevels.DEBUG:
                            Log.Debug(TAG, logMsg);
                            break;
                        case AceLogger.LogLevels.GENERAL:
                        case AceLogger.LogLevels.INFORMATIONAL:
                            Log.Info(TAG, logMsg);
                            break;
                        case AceLogger.LogLevels.ERROR:
                        case AceLogger.LogLevels.EXCEPTION:
                            Log.Error(TAG, logMsg);
                            break;
                        default:
                            Log.Verbose(TAG, logMsg);
                            break;
                    }
                };
        }

        public static void LogValues(this IEnumerable collection, string module)
        {
            try
            {
                if (collection == null) return;

                var enumerator = collection.GetEnumerator();
                StringBuilder logStatement = new StringBuilder();

                while (enumerator.MoveNext())
                {
                    logStatement.Append(enumerator.Current.ToString() + ", ");
                }

                if (logStatement.Length > 0)
                {
                    logStatement.Length -= 2; // trim ", "
                    AceLogger.LogMessage(module, AceLogger.LogLevels.INFORMATIONAL, logStatement.ToString());
                }
                else
                {
                    AceLogger.LogMessage(module, AceLogger.LogLevels.INFORMATIONAL, "Collection is empty.");
                }
            }
            catch(Exception ex)
            {
                AceLogger.LogMessage(module, AceLogger.LogLevels.EXCEPTION, "Something went wrong logging the values of this IEnumerable collection." + Environment.NewLine + ex.StackTrace, ex);
            }
        }
    }
}
