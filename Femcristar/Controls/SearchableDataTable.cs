using Xamarin.Forms.Internals;
namespace AppEmergencia.Controls
{
    [Preserve(AllMembers = true)]
    public class SearchableDataTable : SearchableListView
    {
        #region Method

        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        public override bool FilterContacts(object obj)
        {
            if (base.FilterContacts(obj))
            {
                //var taskInfo = obj as Models.Detail.DataTable;

                //if (string.IsNullOrEmpty(taskInfo.ClubName))
                //{
                //    return false;
                //}

                //return taskInfo.ClubName.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }
            return false;
        }
        #endregion
    }
}
