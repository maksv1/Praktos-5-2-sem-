using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Praktos5
{
    public class Figure
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Figure() { }

        public Figure(string name, double width, double height)
        {
            Name = name;
            Width = width;
            Height = height;
        }
    }

    public class FileManager
    {
        private List<Figure> figures;

        public FileManager()
        {
            figures = new List<Figure>();
        }

        public List<Figure> Figures
        {
            get { return figures; }
        }

        public List<Figure> LoadFromFile(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);

            switch (fileExtension)
            {
                case ".txt":
                    LoadFromTxt(filePath);
                    break;
                case ".json":
                    LoadFromJson(filePath);
                    break;
                case ".xml":
                    LoadFromXml(filePath);
                    break;
                default:
                    Console.WriteLine("Неподдерживаемый формат файла.");
                    break;
            }

            return figures;
        }

        private void LoadFromTxt(string filePath)
        {
        }

        private void LoadFromJson(string filePath)
        {
        }

        private void LoadFromXml(string filePath)
        {
        }

        public void SaveToFile(string filePath, List<Figure> figures)
        {
            string fileExtension = Path.GetExtension(filePath);

            switch (fileExtension)
            {
                case ".txt":
                    SaveToTxt(filePath, figures);
                    break;
                case ".json":
                    SaveToJson(filePath, figures);
                    break;
                case ".xml":
                    SaveToXml(filePath, figures);
                    break;
                default:
                    Console.WriteLine("Неподдерживаемый формат файла для сохранения.");
                    break;
            }
        }

        private void SaveToTxt(string filePath, List<Figure> figures)
        {
        }

        private void SaveToJson(string filePath, List<Figure> figures)
        {
        }

        private void SaveToXml(string filePath, List<Figure> figures)
        {
        }
    }
}