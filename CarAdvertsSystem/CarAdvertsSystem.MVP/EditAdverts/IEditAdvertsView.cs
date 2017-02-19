using System;
using System.Web.ModelBinding;

using WebFormsMvp;

namespace CarAdvertsSystem.MVP.EditAdverts
{
    public interface IEditAdvertsView : IView<EditAdvertsViewModel>
    {
        event EventHandler OnAdvertsGetData;
        event EventHandler<IdEventAdvertArgs> OnAdvertDeleteItem;
        event EventHandler<IdEventAdvertArgs> OnAdvertUpdateItem;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
