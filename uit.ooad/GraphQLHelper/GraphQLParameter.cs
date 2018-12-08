using Newtonsoft.Json.Linq;

namespace uit.ooad.GraphQLHelper
{
    /**
     * Chỉ dùng để truyền vào bên trong parameter của controller để
     * action bắt được các dữ liệu truyền lên thôi
     */
    public class GraphQLParameter
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
