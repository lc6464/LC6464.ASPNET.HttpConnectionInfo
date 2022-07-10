using Microsoft.Extensions.DependencyInjection;

namespace LC6464.ASPNET.HttpConnectionInfo;
/// <summary>
/// 为 <see cref="IServiceCollection">builder.Services</see> 添加扩展方法。
/// </summary>
public static class IServiceCollectionExtensions {
	/// <summary>
	/// 为 <paramref name="services"/> 添加 <see cref="IHttpConnectionInfo"/> 的扩展方法。
	/// </summary>
	/// <param name="services"><see cref="IServiceCollection">builder.Services</see></param>
	/// <returns></returns>
	public static IServiceCollection AddHttpConnectionInfo(this IServiceCollection services) =>
		services.AddHttpContextAccessor().AddScoped<IHttpConnectionInfo, HttpConnectionInfo>();
}