using FairyGodStore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FairyGodStore.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationDate { get; set; }
        public string SortDescription { get; set; }
        public BookCategory bookCategory { get; set; }
        public string LinkData { get; set; }
    }
}
