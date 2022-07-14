using System;
using System.Collections.Generic;
using AceCoreAndroid;
using Apacheta.Utilities.IO;
using Android.App;
using Android.OS;
using Android.Widget;

namespace HelloWorld.Droid
{
	[Activity (Label ="Hello World")]
	public class HelloWorldMainScreen : AceActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			
			SetContentView(Resource.Layout.HelloWorldMainScreen);

			FindViewById<Button>(Resource.Id.btnCount).Click += (s,args) =>
			{
				EndTask(OUTCOME_ok);
			};

			
			// TODO: add layout code here
		}

		
		
		public override void OnBackPressed()
		{
			// do not call the base method
		}
		
		#region Method Composer generated code to define outcomes

		public const string OUTCOME_ok = "ok";
		public const string OUTCOME_Error = "Error";

		#endregion Method Composer generated code to define outcomes

		#region Method Composer generated code to access explicit property
		
		public int Var_Counter
		{
			get { return ApplicationSession.Instance.GetValue<int>("Counter"); }
			set { ApplicationSession.Instance.SetValue("Counter", value); }
		}

		#endregion Method Composer generated code to access explicit property
		
		#region Method Composer generated code to close task
		public void EndTask(string outcome)
		{
			AceLogger.LogMessage(this.ToString(), AceLogger.LogLevels.DEBUG, string.Format("End Task: outcome={0}, ActivityId={1}, SubmethodId={2}", outcome, base.ActivityId, base.SubMethodId));
		
			if (base.ActivityId == "method_1")
			{
				if (outcome == OUTCOME_ok)
				{
					ActivityHelper.SetOutcome(base.ActivityId, new Outcome(this, typeof(StartHere), ActivityHelper.TASK_TYPE.SYSTEM_TASK, "Counter_-3", null, false, "method_2"));
				}
				else if (outcome == OUTCOME_Error)
				{
					ActivityHelper.SetOutcome(base.ActivityId, new Outcome(this, typeof(ShowError), ActivityHelper.TASK_TYPE.UI_TASK, "method_3", null, false, ""));
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
