# ShineBlazor MCP Server

This project hosts the MCP (Modular Component Protocol) server for the ShineBlazor component library. 
The MCP server provides tooling and protocol support for developing and integrating ShineBlazor components.

## Features

- **Stdio-based MCP server** for integration with IDEs and automation tools.
- **Component tooling** for code generation.
- **Resource management** for component documentation and examples.

## Getting Started

1. **Build the server:**
2. **Run the server:**
3. The server communicates over standard input/output (stdio) and is intended for use with compatible clients or development tools.

## Project Structure

- `ShineBlazor.Developer.Local/` - Local MCP server.
- `ShineBlazor.Components/` - ShineBlazor component library.

## Development

- Requires .NET 10 SDK or later.
- Logging is configured to output to stderr.
- MCP tools and resources are registered in `Program.cs`.

## License

This project is licensed under the MIT License.

---

For more information, see the main ShineBlazor documentation or contact the maintainers.

