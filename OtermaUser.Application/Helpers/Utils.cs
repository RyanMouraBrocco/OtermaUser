using OtermaUser.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Application.Helpers
{
    public static class Utils
    {
        public static string Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static IList<string> GetFieldsToUpdate<TEntity>(IEnumerable<string> fieldsNames)
        {
            var entityType = typeof(TEntity);
            var specialPropertyUpdateAttributeType = typeof(SpecialProperyUpdateAttribute);
            return fieldsNames.Where(x => !(entityType.GetProperty(x)?.CustomAttributes.Any(x => x.AttributeType == specialPropertyUpdateAttributeType) ?? false)).Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToList();
        }
    }
}
