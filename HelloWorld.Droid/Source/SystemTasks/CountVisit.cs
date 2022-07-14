using System;
using System.Collections.Generic;
using AceCoreAndroid;
using Apacheta.Utilities.IO;

namespace HelloWorld.Droid
{
	/// <summary>
	/// Summary description for CountVisit.
	/// </summary>
	public class CountVisit : SystemTask
	{
		public override string TaskExecute()
		{
			int counter = Var_Counter;

			Var_Counter = counter + 1;

			return OUTCOME_ok;
			// TODO: Add execution control logic here.
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
		public override Outcome EndTask(string outcome)
		{
			AceLogger.LogMessage(this.ToString(), AceLogger.LogLevels.DEBUG, string.Format("End Task: outcome={0}, ActivityId={1}, SubmethodId={2}", outcome, base.ActivityId, base.SubMethodId));
		
			if (base.ActivityId == "Counter_0")
			{
				if (outcome == OUTCOME_ok)
				{
					return new Outcome(null, typeof(ShowCounter), ActivityHelper.TASK_TYPE.UI_TASK, "Counter_1", null, false, "");
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
