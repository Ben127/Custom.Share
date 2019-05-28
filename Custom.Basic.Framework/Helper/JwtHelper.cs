using JWT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// JwtHelper
    /// </summary>
    public class JwtHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        public static string Encode(object param, string key)
        {
            IJwtAlgorithm algorithm = new JWT.Algorithms.HMACSHA256Algorithm();
            IJsonSerializer serializer = new CustomJsonSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder.Encode(param, key);
        }


        /// <summary>
        /// 解密
        /// </summary>
        public static T Decode<T>(string encode, string key)
        {
            IJsonSerializer serializer = new CustomJsonSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            try
            {
                return decoder.DecodeToObject<T>(encode, key, true);
            }
            catch (TokenExpiredException)
            {
                return default(T);
            }
            catch (SignatureVerificationException)
            {
                return default(T);
            }

        }


    }


    public class CustomJsonSerializer : IJsonSerializer
    {

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }



}
