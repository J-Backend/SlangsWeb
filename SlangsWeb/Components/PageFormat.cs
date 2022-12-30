namespace SlangsWeb.Components
{
    public class PageFormat
    {
        public string Text { get; set; }
        public int Page { get; set; }

        public bool Enabled { get; set; } = true;
        public bool Active { get; set; } = false;

        public PageFormat(int page) : this(page, true)
        {

        }

        public PageFormat(int page, bool enabled) : this(page, enabled, page.ToString())
        {

        }

        public PageFormat(int page, bool enabled, string text)
        {
            this.Page = page;
            this.Text = text;
            this.Enabled = enabled;
        }
    }
}
