using System;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.AdvertCreator
{
    public interface IAdvertCreatorView : IView<AdvertCreatorViewModel>
    {
        event EventHandler OnCitiesGetData;

        event EventHandler OnCategoriesGetData;

        event EventHandler OnManufacturersGetData;

        event EventHandler OnVehicleModelsGetData;
    }
}
