namespace MauiRadio.App.Models
{
    public class Grouped<T> : List<T>
    {
        public string Title { get; }

        public Grouped(string title, List<T> items) : base(items) { Title = title; }
    }
}
