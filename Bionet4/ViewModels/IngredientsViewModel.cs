﻿using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class IngredientsViewModel
    {
        public Article Intro { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}