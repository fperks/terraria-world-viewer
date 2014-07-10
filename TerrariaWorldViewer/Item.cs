namespace TerrariaWorldViewer
{
    /// <summary>
    /// Basic Item Representation
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The name of the item
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The count of the items
        /// </summary>
        private readonly int _count;

        public string Name
        {
            get { return _name; }
        }

        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="count">number of the items</param>
        public Item(string name, int count)
        {
            _name = name;
            _count = count;
        }

        public override string ToString()
        {
            if(Count == 1)
            {
                return Name;
            }
            else
            {
                return string.Format("{0}, Count: {1}", Name, Count);
            }
            
        }
    
    }
}
