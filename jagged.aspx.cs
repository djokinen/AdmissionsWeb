using AdmissionsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdmissionsWeb
{
	public partial class jagged : System.Web.UI.Page
	{

		private SortedList<string, List<string>> _jaggedArray = new SortedList<string, List<string>>();

		protected override void OnLoadComplete(EventArgs e)
		{
			base.OnLoadComplete(e);
			_buildJaggedArray();
			_outputJaggedArray();
		}

		private void _buildJaggedArray()
		{
			string studentId = null;
			AO_Entities db = new AO_Entities();
			List<string> progPlans = new List<string>();

			foreach (Autoeval_progplan item in db.Autoeval_progplan)
			{
				// if this is the same student id
				if (studentId == item.StudentID)
				{
					progPlans.Add(item.ProgPlan);
				}
				// if this is a new student id
				else
				{
					if (studentId != null) { _jaggedArray.Add(studentId, progPlans); }
					studentId = item.StudentID;
					progPlans = new List<string>();
					progPlans.Add(item.ProgPlan);
				}
			}
		}

		private void _outputJaggedArray()
		{
			StringBuilder text = new StringBuilder();
			foreach (var item in _jaggedArray)
			{
				text.Append(item.Key);
				foreach (var plan in item.Value)
				{
					text.AppendFormat(",{0}", plan);
				}
				text.Append("<br />");
			}
			literal.Text = text.ToString();
		}
	}
}