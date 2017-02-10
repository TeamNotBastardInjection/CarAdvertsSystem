using System;
using WebFormsMvp;

namespace CarAdvertsSystem.WebFormsClient.App_Start.Factories.Contracts
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
