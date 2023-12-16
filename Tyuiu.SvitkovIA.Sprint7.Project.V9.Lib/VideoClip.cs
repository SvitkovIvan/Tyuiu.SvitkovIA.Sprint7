using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

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

        public string FullName => $"{LastName} {FirstName} {MiddleName}";
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
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(videoClips);
            }
        }

        public VideoClip GetVideoClipByCode(string code)
        {
            return videoClips.FirstOrDefault(vc => vc.Code == code);
        }

        public List<VideoClip> GetVideoClipsByTheme(string theme)
        {
            return videoClips.Where(vc => vc.Theme == theme).ToList();
        }

        public decimal GetTotalCost()
        {
            return videoClips.Sum(vc => vc.Cost);
        }

        public void LoadFromCSV()
        {
            if (File.Exists(csvFilePath))
            {
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    videoClips = csv.GetRecords < VideoClip > ().ToList();
                }
            }

        }
    }
}



