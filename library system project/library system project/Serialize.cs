using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace library_system_project
{
        public static class SerializeDeserialize<T>
        {
            static StringBuilder sbData= new StringBuilder();
            static StringWriter swWriter;
            static XmlDocument xDoc;
            static XmlNodeReader xNodeReader ;
            static XmlSerializer xmlSerializer;

            public static string SaveData(T data)
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(T));
                swWriter = new StringWriter(sbData);
                Serializer.Serialize(swWriter, data);
                return sbData.ToString();
            }
            public static T LoadData(string dataXML)
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dataXML);
                xNodeReader = new XmlNodeReader(xDoc.DocumentElement);
                xmlSerializer = new XmlSerializer(typeof(T));
                var Data = xmlSerializer.Deserialize(xNodeReader);
                T deserializedData = (T)Data;
                return deserializedData;
            }
        }
    
}

