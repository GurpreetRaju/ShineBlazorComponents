using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace ShineBlazor.Developer.Tools;

/// <summary>
/// Tools for ShineBlazor development.
/// </summary>
public class ShineBlazorTools
{
    private const string SnippetsJsonPath = @"CodeSnippets\ComponentCodeSnippets.json";

    /// <summary>
    /// Loads the Component Snippents JSON.
    /// </summary>
    /// <returns></returns>
    private static JsonDocument? LoadComponentSnippetsJson()
    {
        var baseDir = AppContext.BaseDirectory;
        var jsonPath = Path.GetFullPath(Path.Combine(baseDir, SnippetsJsonPath));
        if (!File.Exists(jsonPath))
            return null;
        var json = File.ReadAllText(jsonPath);
        return JsonDocument.Parse(json);
    }

    /// <summary>
    /// Returns a formatted string listing the available ShineBlazor components.
    /// </summary>
    /// <returns>A string containing the names of available ShineBlazor components, each listed on a new line.</returns>
    [McpServerTool]
    [Description("Provides a list of available ShineBlazor components with descriptions.")]
    public string GetComponentList()
    {
        var doc = LoadComponentSnippetsJson();
        if (doc == null)
            return "ComponentCodeSnippets.json not found.";

        var components = doc.RootElement.GetProperty("componentSnippets");
        var lines = new List<string>();
        foreach (var comp in components.EnumerateArray())
        {
            var name = comp.GetProperty("name").GetString();
            var desc = comp.GetProperty("description").GetString();
            lines.Add($"- {name}: {desc}");
        }
        return string.Join(Environment.NewLine, lines);
    }

    /// <summary>
    /// Gets a code snippet for a specified ShineBlazor component. 
    /// This can be used by developers to quickly generate boilerplate code 
    /// for using ShineBlazor components in their applications.
    /// </summary>
    /// <param name="componentId"></param>
    /// <returns></returns>
    [McpServerTool]
    [Description("Generates code snippet for a component.")]
    public string GetComponentSnippet([Description("The name of the component to generate a snippet for.")] string componentId)
    {
        var doc = LoadComponentSnippetsJson();
        if (doc == null)
            return "ComponentCodeSnippets.json not found.";

        var components = doc.RootElement.GetProperty("componentSnippets");
        foreach (var comp in components.EnumerateArray())
        {
            var id = comp.GetProperty("id").GetString();
            if (string.Equals(id, componentId, StringComparison.OrdinalIgnoreCase))
            {
                var name = comp.GetProperty("name").GetString();
                var desc = comp.GetProperty("description").GetString();
                var snippets = comp.GetProperty("snippets");
                var result = $"# {name}\n{desc}\n\n";
                foreach (var snippet in snippets.EnumerateArray())
                {
                    var title = snippet.GetProperty("title").GetString();
                    var code = snippet.GetProperty("code").GetString();
                    result += $"## {title}\n```razor\n{code}\n```\n\n";
                }
                return result.Trim();
            }
        }
        return $"No code snippets found for component: {componentId}";
    }
}
