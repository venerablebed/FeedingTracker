﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FeedingTracker.Droid
{
    public class FileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            //string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //return Path.Combine(path, filename);

            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), filename);
        }
    }
}