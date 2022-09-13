using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace APIEvent.Filters
{
    public class GeneralExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Tipo da exceção  {context.Exception.GetType().Name}");
            Console.WriteLine($"Mensagem  {context.Exception.Message}");
            Console.WriteLine($"Stack trace  {context.Exception.StackTrace}");
            switch (context.Exception)
            {
                case SqlException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    var problemSql = new ProblemDetails
                    {
                        Status = 503,
                        Title = "Erro inesperado ao se comunicar com o banco de dados",
                        Type = context.Exception.GetType().Name
                    };
                    context.Result = new ObjectResult(problemSql);
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    var problemDefault = new ProblemDetails
                    {
                        Status = 417,
                        Title = "Erro inesperado.Tente novamente",
                        Type = context.Exception.GetType().Name
                    };
                    context.Result = new ObjectResult(problemDefault);

                    break;
            }
        }
    }
}

