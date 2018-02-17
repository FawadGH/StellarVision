using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PTSS.Application.SMSCore.Models
{
    public class ControlHelper
    {
        public static IEnumerable<SelectListItem> GetSelectList(DataView oDV, string ValueColumnName, string TextColumnName)
        {
            var SelectList = new List<SelectListItem>();
            foreach (DataRowView row in oDV)
            {
                SelectList.Add(new SelectListItem
                {
                    Value = row[ValueColumnName].ToString(),
                    Text = row[TextColumnName].ToString()
                });
            }
            return SelectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList<TModel>(IEnumerable<TModel> ModelList, string ValueColumnName, string TextColumnName)
        {
            var SelectList = ModelList.Select(item => new SelectListItem() {
                Text = item.GetType().GetProperty(TextColumnName).GetValue(item).ToString(),
                Value = item.GetType().GetProperty(ValueColumnName).GetValue(item).ToString()
            });
            return SelectList;
        }
    }
}
