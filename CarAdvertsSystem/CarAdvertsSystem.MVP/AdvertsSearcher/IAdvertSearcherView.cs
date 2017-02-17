using System;
using CarAdvertsSystem.MVP.AdvertCreator;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.AdvertsSearcher
{
    public interface IAdvertSearcherView : IView<AdvertSearcherViewModel>
    {
        event EventHandler OnCitiesGetData;

        event EventHandler OnCategoriesGetData;

        event EventHandler OnManufacturersGetData;

        event EventHandler OnVehicleModelsGetData;
    }
}
