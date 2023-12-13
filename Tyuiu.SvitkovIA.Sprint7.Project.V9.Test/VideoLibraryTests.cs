using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Tyuiu.SvitkovIA.Sprint7.Project.V9.Lib;

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9.Test
{
    public class VideoLibraryTests
    {
        [TestMethod]
        public void AddVideoClip_ValidData_VideoClipAdded()
        {
            
            VideoLibrary videoLibrary = new VideoLibrary();
            VideoClip videoClip = new VideoClip
            {
                Code = "VC001",
                Date = DateTime.Now,
                Duration = TimeSpan.FromMinutes(30),
                Theme = "Action",
                Cost = 10.99m,
                Actor = new Actor
                {
                    LastName = "Alexandr",
                    FirstName = "Stepan",
                    MiddleName = "Maxim",
                    Role = "Lead Actor"
                }
            };

        }
    }
}






