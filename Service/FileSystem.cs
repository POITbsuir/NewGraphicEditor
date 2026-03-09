using NewGraphicEditor.Data;
using NewGraphicEditor.Models;
using NewGraphicEditor.Models.ModelsShapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace NewGraphicEditor.Service
{
    //реализация третьей таски с сериализацией
    public interface IFileService
    {
        List<Shapes> OpenFile(string filePath);
        void SaveToFile(string filePath, List<Shapes> shapes);
    }
    public class FileSystem : IFileService
    {
        private static XmlSerializer CreateShapesSerializer()
        {
            var collectionTypes = new[]
            {
                typeof(Lines),
                typeof(Ellipses),
                typeof(Triangle),
                typeof(Rectangles)
            }.Where(t => t != null).ToArray();
            return new XmlSerializer(typeof(Shapes), collectionTypes);
        }
        public List<Shapes> OpenFile(string filePath)
        {
            var xmlSerializer = CreateShapesSerializer();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                return (List<Shapes>)xmlSerializer.Deserialize(stream);
            }
        }

        public void SaveToFile(string filePath, List<Shapes> shapes)
        {
            try
            {
                var xmlSerializer = CreateShapesSerializer();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    xmlSerializer.Serialize(stream, shapes);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public FileSystem() { }
    }
}
