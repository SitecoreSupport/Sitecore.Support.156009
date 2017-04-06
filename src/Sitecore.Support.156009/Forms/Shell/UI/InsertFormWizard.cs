namespace Sitecore.Support.Forms.Shell.UI
{
    using System.Text;
    using Sitecore.Forms.Core.Data;
    using Sitecore.WFFM.Abstractions.Dependencies;

    public class InsertFormWizard : Sitecore.Forms.Shell.UI.InsertFormWizard
    {
        protected override string GenerateAnalytics()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<p>");
            builder.Append("<table>");
            builder.Append("<tr><td class='scwfmOptionName'>");
            builder.Append(DependenciesManager.ResourceManager.Localize("ASOCIATED_GOAL"));
            builder.Append("</td><td class='scwfmOptionValue'>");
            #region Added code
            FormItem form = FormItem.GetForm(base.multiTree.Selected); // get the selected form item
            #endregion
            #region Changed code
            string name = form.Tracking.Goal == null ? string.Empty : form.Tracking.Goal.Name; // get the proper goal name
            #endregion
            if (!this.CreateGoal.Checked)
            {
                name = this.FormsRoot.Database.GetItem(this.Goals.Value).Name;
            }
            builder.AppendFormat(": {0}", name);
            builder.Append("</td></tr>");
            builder.Append("<tr><td class='scwfmOptionName'>");
            builder.Append(DependenciesManager.ResourceManager.Localize("FORM_DROPOUT_TRACKING"));
            builder.Append("</td><td class='scwfmOptionValue'>");
            builder.AppendFormat(": {0}", this.EnableFormDropoutTracking.Checked ? "Enabled" : "Disabled");
            builder.Append("</td></tr>");
            builder.Append("</table>");
            builder.Append("</p>");
            return builder.ToString();
        }
    }
}