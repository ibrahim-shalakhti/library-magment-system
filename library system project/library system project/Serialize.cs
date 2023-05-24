using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace library_system_project
{
        public class SerializeDeserialize<LDB>
        {
            StringBuilder sbData;
            StringWriter swWriter;
            XmlDocument xDoc;
            XmlNodeReader xNodeReader;
            XmlSerializer xmlSerializer;
            public SerializeDeserialize()
            {
                sbData = new StringBuilder();
            }
            public string SaveData(LDB data)
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(LDB));
                swWriter = new StringWriter(sbData);
                Serializer.Serialize(swWriter, data);
                return sbData.ToString();
            }
            public LDB LoadData(string dataXML)
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dataXML);
                xNodeReader = new XmlNodeReader(xDoc.DocumentElement);
                xmlSerializer = new XmlSerializer(typeof(LDB));
                var Data = xmlSerializer.Deserialize(xNodeReader);
                LDB deserializedData = (LDB)Data;
                return deserializedData;
            }
        }
    
}

