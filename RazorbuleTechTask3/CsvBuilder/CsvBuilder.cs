using System.Text;

namespace RazorbuleTechTask3.CsvBuilder
{
    public abstract class CsvBuilder
    {
        protected StringBuilder _sb;

        public CsvBuilder()
        {
            ResetStringBuilder();
        }

        // we shouldn't try to add the headers again, if the sb has already been appended
        // as the headers should already be applied in this instance
        public void BuildHeaders(string[] headers)
        {
            if (_sb.Length > 0)
            {
                return;
            }

            for (int i = 0; i < headers.Length; i++)
            {
                _sb.Append(headers[i]);

                // if we're not on the final header, append a comma
                // else we're on the final header and we'll apply \r\n
                AppendDelimiter(i == headers.Length - 1);
            }
        }

        public void BuildValue(string value, bool isLast = false)
        {
            _sb.Append(value);

            AppendDelimiter(isLast);
        }

        public void ResetStringBuilder()
        {
            _sb = new StringBuilder();
        }

        private void AppendDelimiter(bool isLast)
        {
            if (!isLast)
            {
                _sb.Append(",");
            }
            else
            {
                _sb.Append("\r\n");
            }
        }
    }
}
