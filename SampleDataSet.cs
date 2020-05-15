using System.Collections.Generic;

namespace Ingenio
{
    public static class SampleDataSet
    {
        private static List<DataItem> dataSet = null;
        public static List<DataItem> DataSet
        {
            get 
            {
                if (dataSet != null)
                {
                    return dataSet;
                }

                dataSet = new List<DataItem>();

                dataSet.Add(new DataItem { CategoryId = 100, ParentCategoryId = -1, Name = "Business", KeyWords = "Money"} );
                dataSet.Add(new DataItem { CategoryId = 200, ParentCategoryId = -1, Name = "Tutoring", KeyWords = "Teaching"} );
                dataSet.Add(new DataItem { CategoryId = 101, ParentCategoryId = 100, Name = "Accounting", KeyWords = "Taxes"} );
                dataSet.Add(new DataItem { CategoryId = 102, ParentCategoryId = 100, Name = "Taxation"} );
                dataSet.Add(new DataItem { CategoryId = 201, ParentCategoryId = 200, Name = "Computer"} );
                dataSet.Add(new DataItem { CategoryId = 103, ParentCategoryId = 101, Name = "Corporate Tax"} );
                dataSet.Add(new DataItem { CategoryId = 202, ParentCategoryId = 201, Name = "Operating System"} );
                dataSet.Add(new DataItem { CategoryId = 109, ParentCategoryId = 101, Name = "Small Business Tax"} );

                dataSet.BuildHashTable();
                
                return dataSet;
            }
        }
    }
}
