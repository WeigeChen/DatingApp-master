using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Helpers;

namespace API.Extensions
{
    public static class HttpExtenssions
    {
        public static void AddPaginationHeader (this HttpResponse response , int currentpage, int itemsPerPage , int totalItems , int totalPages)
        {
            var PaginationHeader = new PaginationHeader( currentpage , itemsPerPage , totalItems, totalPages);
            var options  = new JsonSerializerOptions
            {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            response.Headers.Add("Pagination" , JsonSerializer.Serialize(PaginationHeader,options ) );
            response.Headers.Add("Access-Control-Expose-Headers" , "Pagination");

        }
    }
}