using System.Text;

namespace Application.Helpers
{
    public static class ConvertTo
    {
        public static string Base64(int value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value.ToString());
            return Convert.ToBase64String(bytes);
        }
    }
}
