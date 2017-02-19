using System;

using WebFormsMvp;

namespace CarAdvertsSystem.MVP.AdvertDetail
{
    public interface IAdvertDetailView : IView<AdvertDetailViewModel>
    {
        event EventHandler<GetPicturesEventArgs> OnGetPicturesByAdvertId;

        event EventHandler<GetAdvertsByIdEventArgs> OnGetAdvertsById;
    }
}
