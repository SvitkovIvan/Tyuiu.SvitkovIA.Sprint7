﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Tyuiu.SvitkovIA.Sprint7.Project.V9.Lib;

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9.Test
{


    [TestClass]
    public class VideoLibraryTests
    {
        private const string TestCsvFilePath = "testVideoClips.csv";
        private VideoLibrary videoLibrary;

        [TestInitialize]
        public void Initialize()
        {
            videoLibrary = new VideoLibrary(TestCsvFilePath);
            if (File.Exists(TestCsvFilePath))
            {
                File.Delete(TestCsvFilePath);
            }
        }

        [TestMethod]
        public void AddVideoClip_ValidData_VideoClipAdded()
        {
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

        [TestMethod]
        public void AddVideoClip_InvalidData_VideoClipNotAdded()
        {
            VideoClip videoClip = new VideoClip
            {
                Code = "VC002",
                Date = DateTime.Now,
                Duration = TimeSpan.FromMinutes(45),
                Theme = null, // Invalid: Theme cannot be null
                Cost = 9.99m,
                Actor = new Actor
                {
                    LastName = "Smith",
                    FirstName = "John",
                    MiddleName = "Doe",
                    Role = "Supporting Actor"
                }
            };

            videoLibrary.AddVideoClip(videoClip);

            Assert.AreEqual(0, videoLibrary.GetVideoClipsCount());
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(TestCsvFilePath))
            {
                File.Delete(TestCsvFilePath);
            }
        }
    }
}








