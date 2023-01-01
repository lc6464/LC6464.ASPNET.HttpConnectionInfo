# LC6464.ASPNET.HttpConnectionInfo

[NuGet 包](https://www.nuget.org/packages/LC6464.ASPNET.HttpConnectionInfo "NuGet.Org")
[GitHub 项目](https://github.com/lc6464/LC6464.ASPNET.HttpConnectionInfo "GitHub.Com")

在 ASP.NET 中快速获取当前 HTTP 连接的信息。

## 使用方法
`ExampleWebAPI.csproj`:
``` xml
<Project Sdk="Microsoft.NET.Sdk.Web">
	<PropertyGroup>
		<TargetFramework>net6.0</TargetFramework>
		<Nullable>enable</Nullable>
		<ImplicitUsings>enable</ImplicitUsings>
		<!-- 一些东西 -->
	</PropertyGroup>
	<ItemGroup>
		<PackageReference Include="LC6464.ASPNET.HttpConnectionInfo" Version="1.2.0" />
		<!-- PackageReference，请使用 Visual Studio 或 dotnet cli 等工具添加 -->
	</ItemGroup>
	<ItemGroup>
		<Using Include="LC6464.ASPNET.HttpConnectionInfo" />
		<!-- 一些东西 -->
	</ItemGroup>
</Project>
```

`Program.cs`:
``` csharp
var builder = WebApplication.CreateBuilder(args); // 创建 builder


// -------- 添加一些服务 --------


builder.Services.AddHttpConnectionInfo(); // 添加 HttpConnectionInfo 服务


// -------- 添加另外一些服务、构建 WebApplication 等 --------
```

`ExampleController.cs`:
``` csharp
// -------- 一些 Using --------

namespace ExampleWebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase {
	private readonly ILogger<HelloController> _logger;
	private readonly IHttpConnectionInfo _info; // 接口

	public HelloController(ILogger<HelloController> logger, IHttpConnectionInfo info) { // 依赖注入
		_logger = logger;
		_info = info; // 赋值
	}

	[HttpGet]
	[ResponseCache(CacheProfileName = "NoCache")]
	public Hello Get() {
		var address = _info.RemoteAddress; // 获取接口的值
		_logger.LogDebug("Hello! Client {}:{} on {}", address?.AddressFamily == AddressFamily.InterNetworkV6 ? $"[{address}]" : address, _info.RemotePort, _info.Protocol);
		return new(_info);
	}
}
```