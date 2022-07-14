using System;
using System.Collections.Generic;
using AceCoreAndroid;
using Apacheta.Utilities.IO;
using Android.App;
using Android.OS;
using Android.Widget;

namespace HelloWorld.Droid
{
	[Activity]
	public class ShowError : AceActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			
			// TODO: add layout code here
		}
		
		public override void OnBackPressed()
		{
			// do not call the base method
		}
		
		#region Method Composer generated code to define outcomes

		public const string OUTCOME_ok = "ok";

		#endregion Method Composer generated code to define outcomes

		#region Method Composer generated code to access explicit property

		#endregion Method Composer generated code to access explicit property
		
		#region Method Composer generated code to close task
		public void EndTask(string outcome)
		{
			AceLogger.LogMessage(this.ToString(), AceLogger.LogLevels.DEBUG, string.Format("End Task: outcome={0}, ActivityId={1}, SubmethodId={2}", outcome, base.ActivityId, base.SubMethodId));
		
			if (base.ActivityId == "method_3")
			{
				if (outcome == OUTCOME_ok)
				{
					Dictionary<string, string> properties = new Dictionary<string, string>();
					properties.Add("Outcome", "ok");
					ActivityHelper.SetOutcome(base.ActivityId, new Outcome(this, typeof(EndHere), ActivityHelper.TASK_TYPE.SYSTEM_TASK, "method_-4", properties, false, ""));
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
			Finish();
		}

		#endregion Method Composer generated code to close task
	}
}
