namespace Core.Entities
{
    public class KTDatatableModel
    {
        public int draw { get; set; }

        public int start { get; set; }

        public int length { get; set; }

        public Search search { get; set; }

        public Order[] order { get; set; }
    }

    public class Order
    {
        public int column { get; set; }

        public string dir { get; set; }
    }

    public class Search
    {
        public string value { get; set; }

        public bool regex { get; set; }
    }
}