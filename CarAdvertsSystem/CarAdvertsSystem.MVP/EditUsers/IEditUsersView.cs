using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.EditUsers
{
    public interface IEditUsersView : IView<EditUsersViewModel>
    {
        event EventHandler OnGetData;
        event EventHandler OnInsertItem;
        event EventHandler<IdEventArgs> OnDeleteItem;
        event EventHandler<IdEventArgs> OnUpdateItem;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
