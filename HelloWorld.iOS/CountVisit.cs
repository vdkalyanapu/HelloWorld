using System;
using System.Collections.Generic;
using AceCoreiOS;
using Apacheta.Utilities.IO;

namespace HelloWorld.iOS
{
	/// <summary>
	/// Summary description for CountVisit.
	/// </summary>
	public class CountVisit : SystemTask
	{
		public override string TaskExecute()
		{
			// TODO: Add execution control logic here.
		}
		
		#region Method Composer generated code to define outcomes

		public const string OUTCOME_ok = "ok";

		#endregion Method Composer generated code to define outcomes

		#region Method Composer generated code to access explicit property
		
		public int Var_Counter
		{
			get { return ApplicationSession.Instance.GetVariable<int>("Counter"); }
			set { ApplicationSession.Instance.SetVariable("Counter", value); }
		}

		#endregion Method Composer generated code to access explicit property
		
		#region Method Composer generated code to close task
		public override Outcome EndTask(string outcome)
		{
			AceLogger.LogMessage(this.ToString(), AceLogger.LogLevels.DEBUG, string.Format("End Task: outcome={0}, ActivityId={1}, SubmethodId={2}", outcome, base.TaskId, base.SubMethodId));
		
			if (base.TaskId == "Counter_0")
			{
				if (outcome == OUTCOME_ok)
				{
					return new Outcome(
						AceUIApplicationDelegate.Storyboard.InstantiateViewController("ShowCounter") as ShowCounter, UIViewControllerHelper.TASK_TYPE.UI_TASK, "Counter_1", null, false, "");
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
