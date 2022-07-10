namespace LC6464.ASPNET.HttpConnectionInfo;
/// <summary>
/// 获取当前 HTTP 连接的信息的类。
/// </summary>
public class HttpConnectionInfo : IHttpConnectionInfo {
	/// <summary>
	/// 使用 <see cref="IHttpContextAccessor"/> 初始化所有属性的构造函数。
	/// </summary>
	/// <param name="accessor">用于初始化所有属性的 <see cref="IHttpContextAccessor"/></param>
	public HttpConnectionInfo(IHttpContextAccessor accessor) {
		var context = accessor.HttpContext!;
		var connection = context.Connection;
		RemoteAddress = connection.RemoteIpAddress;
		RemotePort = connection.RemotePort;
		LocalAddress = connection.LocalIpAddress!;
		LocalPort = connection.LocalPort;
		ID = connection.Id;
		Protocol = context.Request.Protocol;
	}

	/// <summary>
	/// 客户端当前使用的 IP 地址，可能为 <see langword="null"/>.
	/// </summary>
	public IPAddress? RemoteAddress { get; init; }
	/// <summary>
	/// 客户端当前使用的端口。
	/// </summary>
	public int RemotePort { get; init; }
	/// <summary>
	/// 服务端当前使用的 IP 地址。
	/// </summary>
	public IPAddress LocalAddress { get; init; }
	/// <summary>
	/// 服务端当前使用的端口。
	/// </summary>
	public int LocalPort { get; init; }
	/// <summary>
	/// 当前连接使用的 HTTP 协议。
	/// </summary>
	public string Protocol { get; init; }
	/// <summary>
	/// 当前连接的 ID.
	/// </summary>
	public string ID { get; set; }
}