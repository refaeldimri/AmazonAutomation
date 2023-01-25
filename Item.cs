namespace AmazonAutomation
{
    public class Item
    {
        private string title;
        private string price;
        private string link;

        public Item(string title, string price, string link)
        {
            this.title = title;
            this.price = price;
            this.link = link;
        }

        public string Price { 
            get { 
                return price; 
            }
            set {
                price = value; 
            } 
        }

        public string Title
        {
            get {
                return title; 
            }   
            set {
                title = value;
            }
        }

        public string Link
        {
            get {
                return link;
            }
            set {
                link = value;
            }
        }
    }
}
