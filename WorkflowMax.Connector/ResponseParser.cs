namespace WorkflowMax.Connector
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    using WorkflowMax.Connector.Dto;

    public static class ResponseParser
    {
        public static T Deserialize<T>(string content)
        {
            CheckForErrorMessage(content);
            var serializer = new XmlSerializer(typeof(T));
            var stream = GetStream(content);
            var message = (T)serializer.Deserialize(stream);
            return message;
        }

        public static string Serialize(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }

        public static void CheckForErrorMessage(string content)
        {
            var serializer = new XmlSerializer(typeof(ErrorResponse));
            var stream = GetStream(content);
            var message = (ErrorResponse)serializer.Deserialize(stream);
            if (message.Status == Status.Error)
            {
                throw new ApplicationException(message.Description);
            }
        }

        public static MemoryStream GetStream(string content)
        {
            return new MemoryStream(Encoding.ASCII.GetBytes(content));
        }
    }
}