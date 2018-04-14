namespace APT
{
    public class PageDto
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public int? PrevioudPageId { get; set; }
        public int? NextPageId { get; set; }
        public string Title { get; set; }
        public bool? HasService { get; set; }
        public PageDto NextPage { get; set; }
        public ServiceDto PageService { get; set; }

    }
}