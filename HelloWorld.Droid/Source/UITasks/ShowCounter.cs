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
	public class ShowCounter : AceActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.ShowCounter);

			FindViewById<TextView>(Resource.Id.txtShowCounter).Text = $"Visit Count = {Var_Counter}";

			FindViewById<Button>(Resource.Id.btnOk).Click += (s, args) =>
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
		
			if (base.ActivityId == "Counter_1")
			{
				if (outcome == OUTCOME_ok)
				{
					Dictionary<string, string> properties = new Dictionary<string, string>();
					properties.Add("Outcome", "ok");
					ActivityHelper.SetOutcome(base.ActivityId, new Outcome(this, typeof(EndHere), ActivityHelper.TASK_TYPE.SYSTEM_TASK, "Counter_-4", properties, false, ""));
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
