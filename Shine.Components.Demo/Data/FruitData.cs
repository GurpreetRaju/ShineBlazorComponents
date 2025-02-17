using System.Text.Json.Serialization;

namespace Shine.Components.Demo.Data
{
    /// <summary>
    /// The dummy data.
    /// </summary>
    public record DummyData
    {
        /// <summary>
        /// Fruits.
        /// </summary>
        [JsonPropertyName("fruits")]
        public FruitData[] Fruits { get; set; }
    }

    /// <summary>
    /// Represents a fruit data.
    /// </summary>
    public record FruitData
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the fruit.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The quantity.
        /// </summary
        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// The price.
        /// </summary>
        [JsonPropertyName("price")]
        public string Price { get; set; }
    }
}
