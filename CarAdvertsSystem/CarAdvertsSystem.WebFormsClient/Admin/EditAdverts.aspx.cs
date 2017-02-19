using System;
using System.Linq;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.MVP.EditAdverts;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CarAdvertsSystem.WebFormsClient.Admin
{
    [PresenterBinding(typeof(EditAdvertsPresenter))]
    public partial class EditAdverts : MvpPage<EditAdvertsViewModel>, IEditAdvertsView
    {
        public event EventHandler OnAdvertsGetData;
        public event EventHandler<IdEventAdvertArgs> OnAdvertDeleteItem;
        public event EventHandler<IdEventAdvertArgs> OnAdvertUpdateItem;

        public IQueryable<Advert> ListView1_GetData()
        {
            this.OnAdvertsGetData?.Invoke(this, null);

            return this.Model.Adverts;
        }

        public void ListView1_DeleteItem(int id)
        {
            this.OnAdvertDeleteItem?.Invoke(this, new IdEventAdvertArgs(id));
        }

        public void ListView1_UpdateItem(int id)
        {
            this.OnAdvertUpdateItem?.Invoke(this, new IdEventAdvertArgs(id));
        }
    }
}