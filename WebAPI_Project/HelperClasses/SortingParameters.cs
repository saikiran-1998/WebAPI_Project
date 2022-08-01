namespace WebAPI_Project.HelperClasses
{
    public class SortingParameters
    {
        public string SortBy { get; set; } = "ID";
        private string sortOrder = "asc";
        public string SortOrder
        {
            get
            {
                return sortOrder;
            }
            set
            {
                if (value == "asc" || value == "desc")
                {
                    sortOrder = value;
                }
            }
        }
    }
}
