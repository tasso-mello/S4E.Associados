using System.Dynamic;

namespace domain.S4E.Associados.Extensions
{
    public static class Responses
    {
        #region Error

        public static string GetErrorResponse(string message)
            => (new { error = new { message = message } }).ToJson();

        public static string GetErrorResponse(string message, int statusCode)
            => (new { error = new { code = statusCode, message = message } }).ToJson();

        public static string GetErrorResponse(string message, string innerException)
            => (new { error = new { message = message, exception = innerException } }).ToJson();

        public static string GetErrorObjectResponse(string objectName, string objectResult)
        {
            var response = new ExpandoObject() as IDictionary<string, Object>;
            response.Add(objectName.ToLower(), objectResult);

            return response.ToJson();
        }

        public static string GetErrorNullResponse(string obj, string message)
            => (new { error = new { obj = obj, message = message } }).ToJson();

        #endregion Error

        #region Success

        public static string GetResponse(string message)
            => (new { message = message }).ToJson();

        public static string GetResponse(string objectName, object objectResult, string? message = null)
        {
            var response = new ExpandoObject() as IDictionary<string, object>;
            response.Add(objectName, objectResult);

            if (message != null)
                response.Add("message", message);

            return response.ToJson();
        }

        public static string GetCreatedResponse(string message)
            => (new { message = message }).ToJson();

        public static string GetCreatedResponse(string objectName, long id, string? message = null)
        {
            var response = new ExpandoObject() as IDictionary<string, object>;
            response.Add(objectName, id);

            if (message != null)
                response.Add("message", message);

            return response.ToJson();
        }

        public static string GetObjectResponse(string objectName, object objectResult, string? message = null)
        {
            var response = new ExpandoObject() as IDictionary<string, object>;
            response.Add(objectName.ToLower(), objectResult);

            if (message != null)
                response.Add("message", message);

            return response.ToJson();
        }

        public static string GetObjectResponse(string objectName, object objectResult, int skip, int take, int totalRegisters = 0, int countRegisters = 0, string query = null)
        {
            var response = new ExpandoObject() as IDictionary<string, object>;

            var pages = (int)Math.Ceiling((decimal)totalRegisters / take);

            if (!string.IsNullOrEmpty(query))
                response.Add("queryExecuted", query);

            response.Add(objectName.ToLower(), objectResult);
            response.Add("nextpage", (totalRegisters > (take * skip)) ? $"?skip={skip + 1}&take={take}" : string.Empty);
            response.Add("previouspage", (skip - 1) <= 0 ? string.Empty : $"?skip={(skip - 1)}&take={take}");
            response.Add("currentpage", (skip - 1) <= 0 ? 1 : skip);
            response.Add("firstpage", (skip - 1) <= 0 ? string.Empty : $"?skip=1&take={take}");
            response.Add("lastpage", (totalRegisters > (take * skip)) ? $"?skip={pages}&take={take}" : string.Empty);
            response.Add("pages", pages);
            response.Add("totalregisters", totalRegisters);
            return response.ToJson();
        }

        #endregion Success
    }
}
