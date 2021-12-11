namespace Application.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetTenantId(this HttpContext httpContext)
        {
            var tenant = httpContext.Request.Host.Value.Split('.', StringSplitOptions.RemoveEmptyEntries)[0];

            return tenant;
        }

    }
}
