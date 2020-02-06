using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.DTOs
{
    public class PreviewDto
    {
        public IEnumerable<BookPreviewDto> Books { get; set; }
    }
}
