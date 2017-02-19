using System;
using System.Linq;
using System.Web.ModelBinding;

using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using CarAdvertsSystem.MVP.Search;
using CarAdvertsSystem.WebFormsClient.App_Start;
using Ninject;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CarAdvertsSystem.WebFormsClient
{
    [PresenterBinding(typeof(SearcherPresenter))]
    public partial class Adverts : MvpPage<SearchViewModel>, ISearchView
    {
        public event EventHandler<SearchEventArgs> OnSearchAdverts;
        public event EventHandler<GetPicturePathEventArgs> OnGetPicturePath;
        
        public IQueryable<Advert> Reapeater_GetData([QueryString] string vM, [QueryString] string c, [QueryString] string miP, [QueryString] string maP, [QueryString] string yF, [QueryString] string yT)
        {
            // Showing you that there is a second way to get a query parameter :D
            var vmId = int.Parse(Request.QueryString["v"]);
            var cityId = int.Parse(c);
            var minPrice = int.Parse(miP);
            var maxPrice = int.Parse(maP);
            var yearFrom = int.Parse(yF);
            var yearTo = int.Parse(yT);

            this.OnSearchAdverts?.Invoke(this, new SearchEventArgs(cityId, minPrice, maxPrice, yearFrom, yearTo, vmId));

            return this.Model.Adverts.ToList().AsQueryable();
        }

        public string GetFirstPicturePathByAdvertId(int advertId)
        {
            this.OnGetPicturePath?.Invoke(this, new GetPicturePathEventArgs(advertId));

            var path = this.Model.PicturePath;

            return $"~/Uploaded_Files/{path}";
        }

    }
}