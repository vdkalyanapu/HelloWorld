using System;
using System.Collections.Generic;
using AceCoreiOS;
using Apacheta.Utilities.IO;
using MonoTouch.Foundation;

namespace HelloWorld.iOS
{
	public partial class HelloWorldMainScreen
	{
		#region Method Composer generated code to define outcomes

		public const string OUTCOME_ok = "ok";
		public const string OUTCOME_Error = "Error";

		#endregion Method Composer generated code to define outcomes

		#region Method Composer generated code to access explicit property
		
		public int Var_Counter
		{
			get { return ApplicationSession.Instance.GetVariable<int>("Counter"); }
			set { ApplicationSession.Instance.SetVariable("Counter", value); }
		}

		#endregion Method Composer generated code to access explicit property
		
		#region Method Composer generated code to close task
		public void EndTask(string outcome)
		{
			AceLogger.LogMessage(this.ToString(), AceLogger.LogLevels.DEBUG, string.Format("End Task: outcome={0}, ActivityId={1}, SubmethodId={2}", outcome, base.TaskId, base.SubMethodId));
		
			if (base.TaskId == "method_1")
			{
				if (outcome == OUTCOME_ok)
				{
					UIViewControllerHelper.SetOutcome(new Outcome(new StartHere(), UIViewControllerHelper.TASK_TYPE.SYSTEM_TASK, "Counter_-3", null, false, "method_2"));
				}
				else if (outcome == OUTCOME_Error)
				{
					UIViewControllerHelper.SetOutcome(new Outcome(
						AceUIApplicationDelegate.Storyboard.InstantiateViewController("ShowError") as ShowError, UIViewControllerHelper.TASK_TYPE.UI_TASK, "method_3", null, false, ""));
				}
				else
				{
					throw new Exception("Invalid outcome: " + outcome);
				}
			}
			else
			{
				throw new Exception("Invalid TaskId: " + base.TaskId);
			}
		}

		#endregion Method Composer generated code to close task
	}
}
