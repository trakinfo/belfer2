using Belfer.Administrator.Model;
using System.Collections.Generic;
using System.Linq;

namespace Belfer.Helpers
{
    public static class SeekHelper
    {
        /// <summary>
        /// Checks if a user has an Operator privilage or Administrator privilege
        /// </summary>
        /// <returns></returns>
        public static bool HasOperatorPrivilage() => UserSession.User.Role > User.UserRole.Nauczyciel && UserSession.User.Role < User.UserRole.Administrator;

        /// <summary>
        /// Checks if a user has an Administrator privilege
        /// </summary>
        /// <returns></returns>
        public static bool HasAdminPrivilage() => UserSession.User.Role > User.UserRole.Operator;

        /// <summary>
        /// Finds and select an item in the objectlistview according to single property of pointed type
        /// </summary>
        /// <typeparam name="T">Object model type which contains the property</typeparam>
        /// <typeparam name="T1">Property type to compare with record identyfier</typeparam>
        /// <param name="recordID">Record identyfier to compare with the property name</param>
        /// <param name="propertyName">Name of property which should be found in the object model type</param>
        /// <param name="olv">ObjectListView which owns the record and the object model</param>
        public static void SetListItem<T, T1>(T1 recordID, string propertyName, BrightIdeasSoftware.ObjectListView olv)
        {
            var Item = ((ISet<T>)olv.Objects).Where(x => ((T1)x.GetType().GetProperty(propertyName).GetValue(x)).Equals(recordID)).FirstOrDefault();
            if (Item == null) return;
            olv.SelectObject(Item);
            olv.SelectedItem.EnsureVisible();
        }

        /// <summary>
        /// Finds and select an item in the objectlistview according to two properties of pointed types
        /// </summary>
        /// <typeparam name="T">Object model type which contains the property</typeparam>
        /// <typeparam name="T1">Property type of first property to compare with record first identyfier</typeparam>
        /// <typeparam name="T2">Property type of second property to compare with record second identyfier</typeparam>
        /// <param name="Value1">Record first identyfier to compare with the first property name</param>
        /// <param name="Value2">Record second identyfier to compare with the second property name</param>
        /// <param name="propertyName1">Name of first property which should be found in the object model type</param>
        /// <param name="propertyName2">Name of second property which should be found in the object model type</param>
        /// <param name="olv">ObjectListView which owns the record and the object model</param>
        public static void SetListItem<T, T1, T2>(T1 Value1, T2 Value2, string propertyName1, string propertyName2, BrightIdeasSoftware.ObjectListView olv)
        {
            var Item = ((ISet<T>)olv.Objects)
                .Where(x => ((T1)x.GetType().GetProperty(propertyName1).GetValue(x)).Equals(Value1))
                .Where(x => ((T2)x.GetType().GetProperty(propertyName2).GetValue(x)).Equals(Value2))
                .FirstOrDefault();
            if (Item == null) return;
            olv.SelectObject(Item);
            olv.SelectedItem.EnsureVisible();
        }
    }
}
