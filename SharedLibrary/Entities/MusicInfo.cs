using System;

namespace Entities
{
    public class MusicInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string TransName { get; set; }
        public string Album { get; set; }
        public double Gain { get; set; }
        public double Peak { get; set; }
        public double Lra { get; set; }
        public int Bpm { get; set; }
        public int Interval { get; set; }
        public string Company { get; set; }
        public string Genre { get; set; }
        public string Mid { get; set; }
    }
}