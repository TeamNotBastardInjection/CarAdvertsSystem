using System;

using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;

using Bytes2you.Validation;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.EditAdverts
{
    public class EditAdvertsPresenter : Presenter<IEditAdvertsView>
    {
        private readonly IAdvertServices advertService;

        public EditAdvertsPresenter(IEditAdvertsView view, IAdvertServices advertService)
            : base(view)
        {
            Guard.WhenArgument(view, "View Instance is Null!!").IsNull().Throw();
            Guard.WhenArgument(advertService, "Advert Service Instance is Null!!").IsNull().Throw();

            this.advertService = advertService;

            this.View.OnAdvertsGetData += View_OnAdvertsGetData;
            this.View.OnAdvertDeleteItem += View_OnAdvertDeleteItem;
            this.View.OnAdvertUpdateItem += View_OnAdvertUpdateItem;
        }

        private void View_OnAdvertUpdateItem(object sender, IdEventAdvertArgs e)
        {
            Advert item = this.advertService.GetById(e.Id);
            if (item == null)
            {
                this.View.ModelState.AddModelError("", $"Item with id {e.Id} was not found");
                return;
            }

            this.View.TryUpdateModel(item);
            if (this.View.ModelState.IsValid)
            {
                this.advertService.UpdateAdvert(item);
            }
        }

        private void View_OnAdvertDeleteItem(object sender, IdEventAdvertArgs e)
        {
            this.advertService.DeleteAdvertById(e.Id);
        }

        private void View_OnAdvertsGetData(object sender, EventArgs e)
        {
            this.View.Model.Adverts = this.advertService.GetAllAdverts();
        }
    }
}
