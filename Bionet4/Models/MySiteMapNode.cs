namespace Bionet4.Models
{
    public class MySiteMapNode
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public MySiteMapNode ParentNode { get; set; }
    }
}