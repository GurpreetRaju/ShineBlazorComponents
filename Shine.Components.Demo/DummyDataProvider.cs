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
    }
}
