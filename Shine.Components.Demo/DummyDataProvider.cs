using Shine.Components.Demo.Data;
using System.Reflection;
using System.Text.Json;

namespace Shine.Components.Demo
{
    /// <summary>
    /// Dummy data provider.
    /// </summary>
    public class DummyDataProvider
    {
        private DummyData DummyData;

        /// <summary>
        /// Initialize.
        /// </summary>
        public DummyDataProvider() 
        {
            LoadDummyData();
        }

        /// <summary>
        /// Fruits.
        /// </summary>
        public ICollection<FruitData> GetFruits(int take, int skip) => 
            DummyData.Fruits.Skip(skip).Take(take).ToList() ?? [];

        /// <summary>
        /// Gets the fruits.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<DataResponse<FruitData>> GetFruits(DataRequest request)
        {
            var response = new DataResponse<FruitData>();
            if (request == null)
                return Task.FromResult(response);

            IEnumerable<FruitData> fruits = DummyData.Fruits;

            // Apply filters
            foreach (var filter in request.Filters)
            {
                var propertyExpression = GetFilterExpression(filter.ColumnName, filter.FilterValue);
                if (propertyExpression != null)
                {
                    fruits = fruits.Where(propertyExpression);
                }
            }

            response.TotalCount = fruits.Count();

            // Apply sorting
            if (request.SortData != null && request.SortData.SortDirection != SortDirection.None)
            {
                var orderFunc = GetPropertyExpression(request.SortData.ColumnName);
                if (orderFunc != null)
                {
                    if (request.SortData.SortDirection == SortDirection.Ascending)
                        fruits = fruits.OrderBy(orderFunc);
                    else
                        fruits = fruits.OrderByDescending(orderFunc);
                }
            }

            fruits = fruits.Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize);

            response.Items.AddRange(fruits);

            return Task.FromResult(response);
        }

        /// <summary>
        /// Loads the dummy data.
        /// </summary>
        private void LoadDummyData()
        {
            foreach (var name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                Console.WriteLine(name);
            }

            var resourceName = "Shine.Components.Demo.Resources.fruits.json";
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new InvalidOperationException($"Resource '{resourceName}' not found.");

                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    DummyData = JsonSerializer.Deserialize<DummyData>(result);
                }
            }
        }

        /// <summary>
        /// Gets the property expression for property name.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private Func<FruitData, bool> GetFilterExpression(string propertyName, object filterValue)
        {
            Func<string, string, bool> contains = (x, y) => (x == null && y == null)
                || (x != null && y != null && x.Contains(y));

            return propertyName switch
            {
                nameof(FruitData.Id) => f => contains(f.Id, filterValue.ToString()),
                nameof(FruitData.Name) => f => contains(f.Name, filterValue.ToString()),
                nameof(FruitData.Price) => f => contains(f.Price, filterValue.ToString()),
                nameof(FruitData.Quantity) => f => contains(f.Quantity, filterValue.ToString()),
                _ => null
            };
        }

        /// <summary>
        /// Gets the property expression for property name.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private Func<FruitData, object> GetPropertyExpression(string propertyName)
        {
            return propertyName switch
            {
                nameof(FruitData.Id) => f => f.Id,
                nameof(FruitData.Name) => f => f.Name,
                nameof(FruitData.Price) => f => f.Price,
                nameof(FruitData.Quantity) => f => f.Quantity,
                _ => null
            };
        }
    }
}
