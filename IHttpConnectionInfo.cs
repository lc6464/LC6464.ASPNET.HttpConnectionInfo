namespace LC6464.ASPNET.HttpConnectionInfo;
/// <summary>
/// 当前 HTTP 连接的信息。
/// </summary>
public interface IHttpConnectionInfo {
	/// <summary>
	/// 客户端当前使用的 IP 地址，可能为 <see langword="null"/>.
	/// </summary>
	IPAddress? RemoteAddress { get; init; }

	/// <summary>
	/// 客户端当前使用的端口。
	/// </summary>
	int RemotePort { get; init; }

	/// <summary>
	/// 服务端当前使用的 IP 地址。
	/// </summary>
	IPAddress LocalAddress { get; init; }

	/// <summary>
	/// 服务端当前使用的端口。
	/// </summary>
	int LocalPort { get; init; }

	/// <summary>
	/// 当前连接使用的 HTTP 协议。
	/// </summary>
	string Protocol { get; init; }

	/// <summary>
	/// 当前连接的 ID.
	/// </summary>
	string ID { get; set; }
}