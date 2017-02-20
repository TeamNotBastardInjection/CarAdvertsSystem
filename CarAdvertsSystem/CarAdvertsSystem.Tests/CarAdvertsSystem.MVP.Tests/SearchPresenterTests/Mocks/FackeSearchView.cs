using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAdvertsSystem.MVP.Search;

namespace CarAdvertsSystem.Tests.CarAdvertsSystem.MVP.Tests.SearchPresenterTests.Mocks
{
    internal class FackeSearchView : ISearchView
    {
        public bool ThrowExceptionIfNoPresenterBound { get; }
        public event EventHandler Load;
        public SearchViewModel Model { get; set; }
        public event EventHandler<SearchEventArgs> OnSearchAdverts;
        public event EventHandler<GetPicturePathEventArgs> OnGetPicturePath;
    }
}
