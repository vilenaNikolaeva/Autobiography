﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class CreateLanguageViewModel
    {
        //[Required]
        [MaxLength(100)]
        public string Title { get; set; }
        //[Required]
        //[Range(1, 100)]
        public int Level { get; set; }

        public string UserId { get; set; }
    }
}
