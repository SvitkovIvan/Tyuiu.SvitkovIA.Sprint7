using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9.Lib
{
    public class VideoClip
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public string Theme { get; set; }
        public decimal Cost { get; set; }

        public Actor Actor { get; set; }
    }

    public class Actor
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Role { get; set; }
    }

    public class VideoLibrary
    {
        private List<VideoClip> videoClips;
        private string csvFilePath;

        public VideoLibrary(string filePath)
        {
            videoClips = new List<VideoClip>();
            csvFilePath = filePath;
        }
        public void AddVideoClip(VideoClip videoClip)
        {
            videoClips.Add(videoClip);
        }

        public int GetVideoClipsCount()
        {
            return videoClips.Count;
        }

        public void SaveToCSV()
        {

        }

        public void LoadFromCSV()
        {

        }
    }
}



