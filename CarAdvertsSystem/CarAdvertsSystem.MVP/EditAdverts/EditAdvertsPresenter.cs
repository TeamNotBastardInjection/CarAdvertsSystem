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

        public void View_OnAdvertUpdateItem(object sender, IdEventAdvertArgs e)
        {
            Guard.WhenArgument(e.Id, "Advert Id must be positive number!!!").IsLessThan(1).Throw();

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

        // InvokeIAdvertService_GetByIdMethodColdOnce()
        // AddModelError_WhenItemIsNotFound()
        // TryUpdateModelIsNotCalled_WhenItemIsNotFound()
        // TryUpdateModelIsCalled_WhenItemIsFound()
        // UpdateCategoryIsCalled_WhenItemIsFoundAndIsInValidState()
        // UpdateCategoryIsNotCalled_WhenItemIsFoundAndIsInInvalidState()

        public void View_OnAdvertDeleteItem(object sender, IdEventAdvertArgs e)
        {
            Guard.WhenArgument(e.Id, "Advert Id must be positive number!!!").IsLessThan(1).Throw();
            
            this.advertService.DeleteAdvertById(e.Id);
        }

        public void View_OnAdvertsGetData(object sender, EventArgs e)
        {
            this.View.Model.Adverts = this.advertService.GetAllAdverts();
        }
    }
}
