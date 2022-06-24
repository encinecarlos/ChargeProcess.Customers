using System.Text.RegularExpressions;

namespace ChargeProcess.Customers.Infrastructure.Common
{
    public static class DataConversion
    {
        public static long ConvertDocumentToNumber(this string documentId)
        {
            long documentConverted = 0;
            if (documentId.Contains(".") && documentId.Contains("-"))
            {
                documentConverted = Convert.ToInt64(Regex.Replace(documentId, "[^0-9]", ""));
                return documentConverted;
            }

            documentConverted = Convert.ToInt64(documentId);
            
            return documentConverted;
        }
    }
}