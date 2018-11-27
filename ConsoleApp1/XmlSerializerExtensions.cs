using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HowToBenchmark
{
    public static class XmlSerializerExtensions
    {
        /// <summary>
        /// The <see cref="XmlSerializerNamespaces"/> used in all the serialize operations.
        /// </summary>
        private static readonly XmlSerializerNamespaces SerializerNamespaces = new XmlSerializerNamespaces();

        /// <summary>
        /// Static constructor, add an empty serializer namespaces to not show any namespace in the converted XML.
        /// </summary>
        static XmlSerializerExtensions()
        {
            SerializerNamespaces.Add(string.Empty, string.Empty);
        }

        /// <summary>
        /// Serializes the instance of <see cref="T"/> into a XML string.
        /// </summary>
        /// <param name="value">Object to be serialized.</param>
        /// <param name="omitXmlDeclaration">Indicates whether to writer an XML declaration. (XML version, enconding)</param>
        /// <returns>The <paramref name="value"/> instance serialized as a XML <see cref="string"/>.</returns>
        public static string ToXml<T>(this T value, bool omitXmlDeclaration = false)
        {
            //if (value == null) return string.Empty;

            var settings = new XmlWriterSettings { OmitXmlDeclaration = omitXmlDeclaration };
            var serializer = new XmlSerializer(typeof(T));

            using (StringWriter stringWriter = new Utf8StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(xmlWriter, value, SerializerNamespaces);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Internal class to override <see cref="StringWriter.Encoding"/> property and set to UTF-8 by default.
        /// </summary>
        internal class Utf8StringWriter : StringWriter
        {
            /// <inheritdoc />
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}