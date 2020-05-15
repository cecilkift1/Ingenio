using System;
using System.Collections.Generic;
using System.Linq;

namespace Ingenio
{
    public static class DataSetExtensions
    {
        public static string GetPrintOutPut(this List<DataItem> dataSet, int categoryId)
        {
            var dataItem = dataSet.FirstOrDefault(ds => ds.CategoryId == categoryId);

            if (dataItem == null)
            {
                 // this should not happen, since the input was validated.
                return $"Category with Id:{categoryId} not found";
            }

            var keyWords = dataItem.KeyWords;
            var currentItem = dataItem;
            while (string.IsNullOrEmpty(keyWords))
            {
                currentItem = currentItem.Parent;
                if (currentItem != null)
                {
                    keyWords = currentItem.KeyWords;
                }
            }

            return $"Output: ParentCategoryID={dataItem.ParentCategoryId}, Name={dataItem.Name}, Keywords={keyWords}\n\n";
        }

        public static void BuildHashTable(this List<DataItem> dataSet)
        {
            var dictionary = new Dictionary<int, DataItem>();
            var ascendingOrder = dataSet.OrderBy(i => i.ParentCategoryId);

            foreach (var item in ascendingOrder)
            {
                if (!dictionary.ContainsKey(item.CategoryId))
                {
                    dictionary.Add(item.CategoryId, item);
                }

                if (item.ParentCategoryId != -1)
                {
                    var parentItem = dictionary[item.ParentCategoryId];
                    if (!parentItem.Children.Contains(item))
                    {
                        item.Parent = parentItem;
                        parentItem.Children.Add(item);
                    }
                }
            }
        }

        public static string PrintCategoryLevel(this List<DataItem> dataSet, int level)
        {
            var startingLevel = 1;
            var result = new List<string>();

            foreach (var item in dataSet.Where(i => i.ParentCategoryId == -1))
            {
                var recurseResult = RecurseParent(item, level, startingLevel);
                if (recurseResult.Any())
                {
                    result.AddRange(recurseResult);
                }
            }

            return $"Output: [{string.Join(",", result)}]\n\n";   
        }
    
        private static List<string> RecurseParent(DataItem parent, int maxLevel, int currentLevel)
        {
            var result = new List<string>();
            if (currentLevel == maxLevel)
            {
                result.Add(parent.CategoryId.ToString());
                return result;
            }

            var recurseLevel = currentLevel + 1;
            foreach (var child in parent.Children)
            {        
                var childResult = RecurseParent(child, maxLevel, recurseLevel);
                if (childResult.Any())
                {
                    result.AddRange(childResult);
                }
            }

            return result;

        }
    }
}
