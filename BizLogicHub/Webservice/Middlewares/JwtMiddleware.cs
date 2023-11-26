using System.IdentityModel.Tokens.Jwt;

namespace Webservice.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = tokenHandler.ReadJwtToken(token);

                    var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
                    var name = jwtToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                    var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
                    var expiration = jwtToken.ValidTo;

                    // Set the token information in the HttpContext.Items to make it accessible in controllers
                    context.Items["UserId"] = id;
                    context.Items["UserName"] = name;
                    context.Items["UserEmail"] = email;
                    context.Items["TokenExpiration"] = expiration;
                }
                catch (Exception ex)
                {
                    // Handle token decoding errors
                    Console.WriteLine($"Token decoding error: {ex.Message}");
                }
            }

            await _next(context);
        }
    }
}
