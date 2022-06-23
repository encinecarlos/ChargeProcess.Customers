using System.Text.RegularExpressions;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    public class DataConversion
    {

        private long ConvertDocument(string documentId)
        {
            var documentConverted = string.Empty;
            if (documentId.Contains(".") && documentId.Contains("-"))
            {
                documentConverted = Regex.Replace(documentId, "[^0-9]", "");
            }

            return Convert.ToInt64(documentConverted);
        }
    }
}