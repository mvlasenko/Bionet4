﻿using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class EventsViewModel
    {
        public Article Intro { get; set; }
        public List<Event> Events { get; set; }
    }
}