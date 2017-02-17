using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.AdvertsSearcher;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.AdvertCreator
{
    public class AdvertSearcherPresenter : Presenter<IAdvertSearcherView>
    {
        private readonly IAdvertServices advertServices;

        protected AdvertSearcherPresenter(IAdvertSearcherView view, IAdvertServices advertServices) : 
            base(view)
        {
            Guard.WhenArgument(advertServices, "advertServices is null").IsNull().Throw();

            this.advertServices = advertServices;

            this.View.OnAdvertsGetData += View_OnAdvertsGetData;
        }

        private void View_OnAdvertsGetData(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
