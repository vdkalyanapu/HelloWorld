using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Apacheta.Utilities.IO;
using AceCoreAndroid;

namespace HelloWorld.Droid
{
    class StartHere : SystemTask
    {
        #region Apacheta Method Composer Generated Code
        public override string TaskExecute()
        {
            return OUTCOME_Start;
        }
        #endregion

        #region Method Composer generated code to define outcomes

		public const string OUTCOME_Start = "Start";

		#endregion Method Composer generated code to define outcomes

        #region Method Composer generated code to access explicit property

		#endregion Method Composer generated code to access explicit property

        #region Method Composer generated code to close task
		public override Outcome EndTask(string outcome)
		{
			AceLogger.LogMessage(this.ToString(), AceLogger.LogLevels.DEBUG, string.Format("End Task: outcome={0}, ActivityId={1}, SubmethodId={2}", outcome, base.ActivityId, base.SubMethodId));
		
			if (base.ActivityId == "method_-3")
			{
				if (outcome == OUTCOME_Start)
				{
					return new Outcome(null, typeof(InitializeApp), ActivityHelper.TASK_TYPE.SYSTEM_TASK, "method_0", null, false, "");
				}
				else
				{
					throw new Exception("Invalid outcome: " + outcome);
				}
			}
			else if (base.ActivityId == "Counter_-3")
			{
				if (outcome == OUTCOME_Start)
				{
					return new Outcome(null, typeof(CountVisit), ActivityHelper.TASK_TYPE.SYSTEM_TASK, "Counter_0", null, false, "");
				}
				else
				{
					throw new Exception("Invalid outcome: " + outcome);
				}
			}
			else
			{
				throw new Exception("Invalid ActivityId: " + base.ActivityId);
			}
		}

		#endregion Method Composer generated code to close task
    }
}
