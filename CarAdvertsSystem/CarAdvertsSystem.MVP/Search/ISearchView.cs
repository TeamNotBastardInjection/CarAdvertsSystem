using System;
using WebFormsMvp;

namespace CarAdvertsSystem.MVP.Search
{
    public interface ISearchView : IView<SearchViewModel>
    {
        event EventHandler<SearchEventArgs> OnSearchAdverts;

        event EventHandler<GetPicturePathEventArgs> OnGetPicturePath;
    }
}
