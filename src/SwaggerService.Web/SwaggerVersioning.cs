

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace SwaggerService.Web
{
    /// <summary>
    /// RemoveVersionParameter class
    /// </summary>
    public class RemoveVersionParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if(operation.Parameters.Count > 0)
            {
                var version = operation.Parameters.SingleOrDefault(v => v.Name == "version");
                operation.Parameters.Remove(version);
            }
            
        }
    }

    /// <summary>
    /// ReplaceVersionPath class
    /// </summary>
    public class ReplaceVersionPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths;
            swaggerDoc.Paths = new OpenApiPaths();

            foreach(var path in paths)
            {
                var key = path.Key.Replace("v{version}",swaggerDoc.Info.Version);
                var value = path.Value;
                swaggerDoc.Paths.Add(key,value);
            }
        }
    }
}
