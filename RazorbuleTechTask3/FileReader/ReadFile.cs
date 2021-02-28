using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RazorbuleTechTask3.FileReader
{
    /// <summary>
    /// Class used to read an embedded resource of a given fileName
    /// </summary>
    public class ReadFile : IDisposable
    {
        private readonly Stream _stream;
        private readonly StreamReader _reader;

        public ReadFile(string fileName)
        {
            // get the current assembly
            var assembly = Assembly.GetExecutingAssembly();

            var file = assembly.GetManifestResourceNames()
                .Single(s => s.EndsWith(fileName));

            // create a stream to convert into a stream reader and assign it to the private field
            _stream = assembly.GetManifestResourceStream(file);
            _reader = new StreamReader(_stream);
        }

        public string ReadLine()
        {
            return _reader.ReadLine();
        }

        public void Dispose()
        {
            _stream.Dispose();
            _reader.Dispose();
        }
    }
}
