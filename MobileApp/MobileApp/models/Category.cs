﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }

        public string FullImageUrl => AppSetting.ApiURL + imageUrl;
    }
}
