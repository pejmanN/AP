using APT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APT
{
    public class MenuDTO
    {
        public MenuDTO()
        {
            Pages = new List<PageDto>();
            Children = new List<MenuDTO>();
        }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public bool IsLast { get; set; }
        public List<PageDto> Pages { get; set; }
        public List<MenuDTO> Children { get; set; }
    }
}