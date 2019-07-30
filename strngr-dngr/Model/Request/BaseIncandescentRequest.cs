using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace strngr_dngr.Model.Request
{
    [Serializable]
    public class BaseIncandescentRequest
    {
        private static readonly int IncandescentApiUid = 7596;
        private static readonly string IncandescentApiKey = "56e94346f17109525a4ddea135149eb2";

        public BaseIncandescentRequest()
        {
            var expires = DateTimeOffset.UtcNow.AddSeconds(30).ToUnixTimeSeconds();

            var stringToSign = $"{IncandescentApiUid}-{expires}-{IncandescentApiKey}";

            Uid = IncandescentApiUid;
            Expires = expires;
            Auth = SignString(stringToSign);
        }

        [JsonProperty(PropertyName = "uid")]
        public int Uid { get; private set; }

        [JsonProperty(PropertyName = "expires")]
        public long Expires { get; private set; }

        [JsonProperty(PropertyName = "auth")]
        public string Auth { get; private set; }


        private static string SignString(string stringToSign)
        {
            using (var md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, stringToSign);
            }
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();

        }
    }

}
