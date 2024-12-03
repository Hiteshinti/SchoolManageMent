namespace SchoolManageMent.MiddileWare
{
    public class CustomMiddileware :IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           
            await next(context);    
        }
    }
}
