using System;
using System.Collections.Generic;
using AceCoreAndroid;
using Apacheta.Utilities.IO;

namespace HelloWorld.Droid
{
    class EndHere : SystemTask
    {
        public override string TaskExecute()
        {
            return Prop_Outcome;
        }

        #region Method Composer generated code to define outcomes


		#endregion Method Composer generated code to define outcomes

        #region Method Composer generated code to access explicit property
		
		public string Prop_Outcome
		{
			get { return ApplicationSession.Instance.GetValue<string>("Outcome"); }
		}

		#endregion Method Composer generated code to access explicit property
        
        #region Method Composer generated code to close task
		public override Outcome EndTask(string outcome)
		{
			AceLogger.LogMessage(this.ToString(), AceLogger.LogLevels.DEBUG, string.Format("End Task: outcome={0}, ActivityId={1}, SubmethodId={2}", outcome, base.ActivityId, base.SubMethodId));
		
			if (base.ActivityId == "Counter_-4")
			{
				if (outcome == "ok")
				{
					if (base.SubMethodId == "method_2")
					{
						return new Outcome(null, typeof(HelloWorldMainScreen), ActivityHelper.TASK_TYPE.UI_TASK, "method_1", null, true, "");
					}
					else { return null; } // this code should never execute
				}
				else
				{
					throw new Exception("Invalid outcome: " + outcome);
				}
			}
			else if (base.ActivityId == "method_-4")
			{
				if (outcome == "ok")
				{
					if (base.SubMethodId == "method")
					{
						return null; // Application.Exit();
					}
					else { return null; } // this code should never execute
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
