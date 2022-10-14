using MauiRadio.Core.Entities;

namespace MauiRadio.App.Services
{
    public interface IMusicPlayer
    {
        bool Play(Station station);

        void Stop();
    }
}
