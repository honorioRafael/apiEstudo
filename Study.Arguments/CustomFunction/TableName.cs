using System.Security.Cryptography;
using System.Text;

namespace Study.Arguments.CustomFunction
{
    public static class TableName
    {
        public static long GetNameId(string name)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(name.ToLower());
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                long positiveHash = Math.Abs(BitConverter.ToInt32(hashBytes, 0));

                return positiveHash;
            }
        }

    }
}
