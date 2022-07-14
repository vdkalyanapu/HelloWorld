using System;
using System.Collections.Generic;
using AceCoreiOS;
using Apacheta.Utilities.IO;
using MonoTouch.Foundation;

namespace HelloWorld.iOS
{
	public partial class FirstScreen
	{
		#region Method Composer generated code to define outcomes

		public const string OUTCOME_ok = "ok";
		public const string OUTCOME_error = "error";

		#endregion Method Composer generated code to define outcomes

		#region Method Composer generated code to access explicit property

		#endregion Method Composer generated code to access explicit property
		
		#region Method Composer generated code to close task
		public void EndTask(string outcome)
		{
			AceLogger.LogMessage(this.ToString(), AceLogger.LogLevels.DEBUG, string.Format("End Task: outcome={0}, ActivityId={1}, SubmethodId={2}", outcome, base.TaskId, base.SubMethodId));
		
			if (base.TaskId == "method_0")
			{
				if (outcome == OUTCOME_ok)
				{
					throw new Exception("Outcome is not mapped: ok");
				}
				else if (outcome == OUTCOME_error)
				{
					throw new Exception("Outcome is not mapped: error");
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
