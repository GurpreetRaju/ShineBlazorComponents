using ModelContextProtocol.Server;
using System.ComponentModel;

namespace ShineBlazor.Developer.Tools;

/// <summary>
/// Sample MCP tools for demonstration purposes.
/// These tools can be invoked by MCP clients to perform various operations.
/// </summary>
public class ShineBlazorResources
{
    private const string QuickReferencePath = @"CodeSnippets\QUICK_REFERENCE.md";

    /// <summary>
    /// Gets the Quick Reference.
    /// </summary>
    /// <returns></returns>
    [McpServerResource]
    [Description("Returns the content of the ShineBlazor quick reference markdown.")]
    public string GetQuickReference()
    {
        var baseDir = AppContext.BaseDirectory;
        var filePath = Path.GetFullPath(Path.Combine(baseDir, QuickReferencePath));
        if (!File.Exists(filePath))
            return "QUICK REFERENCE not found.";

        return File.ReadAllText(filePath);
    }
}
