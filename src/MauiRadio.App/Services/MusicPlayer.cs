using LibVLCSharp.Shared;
using MauiRadio.Core.Entities;

namespace MauiRadio.App.Services
{
    internal class MusicPlayer : IMusicPlayer
    {
        private readonly LibVLC libVLC;
        private readonly MediaPlayer mediaPlayer;
        private Media? media;

        public MusicPlayer(LibVLC libVLC, MediaPlayer mediaPlayer)
        {
            this.libVLC = libVLC;
            this.mediaPlayer = mediaPlayer;
        }

        public bool Play(Station station)
        {
            media = new Media(libVLC, station.Url, FromType.FromPath);
            mediaPlayer.Media = media;
            mediaPlayer.Media.AddOption("no-video");
            mediaPlayer.Volume = 50;
            
            return mediaPlayer.Play();
        }

        public void Stop()
        {
            media?.Dispose();
            mediaPlayer.Stop();
        }
    }
}
