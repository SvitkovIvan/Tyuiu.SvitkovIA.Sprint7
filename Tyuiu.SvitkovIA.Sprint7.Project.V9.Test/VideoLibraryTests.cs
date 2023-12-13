using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Tyuiu.SvitkovIA.Sprint7.Project.V9.Lib;

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9.Test
{
    public class VideoLibraryTests
    {
        [TestMethod]
        public void AddVideoClip_ValidData_VideoClipAdded()
        {
            
            VideoLibrary videoLibrary = new VideoLibrary("videoClips.csv");
            VideoClip videoClip = new VideoClip
            {
                Code = "VC001",
                Date = DateTime.Now,
                Duration = TimeSpan.FromMinutes(30),
                Theme = "Action",
                Cost = 10.99m,
                Actor = new Actor
                {
                    LastName = "Stepan",
                    FirstName = "Egor",
                    MiddleName = "Maxim",
                    Role = "Lead Actor"
                }
            };


            videoLibrary.AddVideoClip(videoClip);


            Assert.AreEqual(1, videoLibrary.GetVideoClipsCount());


            VideoClip addedVideoClip = videoLibrary.GetVideoClipByCode("VC001");
            Assert.IsNotNull(addedVideoClip);
            Assert.AreEqual("Action", addedVideoClip.Theme);

        }

        
    }


}
    



