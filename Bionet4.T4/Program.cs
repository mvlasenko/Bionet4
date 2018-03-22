using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Bionet4.T4.Model;
using Bionet4.T4.Templates;
using System.Linq;

namespace Bionet4.T4
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", "").Replace("\\bin", "");
            string path = Path.Combine(dir, "data.xml");

            string dataProjectDir = dir.Replace(".T4", ".Data");

            DatabaseInfo databaseInfo = new DatabaseInfo();

            var serializer = new XmlSerializer(databaseInfo.GetType());
            using (StreamReader reader = new StreamReader(path))
            {
                databaseInfo = (DatabaseInfo)serializer.Deserialize(reader);
            }

            foreach (ModelInfo model in databaseInfo.Models)
            {
                //preparing FK collection names
                model.CollectionModel = databaseInfo.Models.FirstOrDefault(m => m.Fields.Any(f => f.FkSingular == model.Singular));

                ModelTemplate modelTemplate = new ModelTemplate();
                modelTemplate.Model = model;
                modelTemplate.RootNamespace = databaseInfo.RootNamespace;
                string modelContent = modelTemplate.TransformText();
                File.WriteAllText(Path.Combine(dataProjectDir, "Models", model.Singular + ".cs"), modelContent);

                RepositoryTemplate repositoryTemplate = new RepositoryTemplate();
                repositoryTemplate.Model = model;
                repositoryTemplate.RootNamespace = databaseInfo.RootNamespace;
                string repositoryContent = repositoryTemplate.TransformText();
                File.WriteAllText(Path.Combine(dataProjectDir, "Repository", model.Plural + "Repository.cs"), repositoryContent);

                MappingTemplate mapTemplate = new MappingTemplate();
                mapTemplate.Model = model;
                mapTemplate.RootNamespace = databaseInfo.RootNamespace;
                string mapContent = mapTemplate.TransformText();
                File.WriteAllText(Path.Combine(dataProjectDir, "Models\\Mapping", model.Singular + "Map.cs"), mapContent);




            }




            //DatabaseInfo databaseInfo = new DatabaseInfo();
            //databaseInfo.RootNamespace = "Bionet4";

            //ModelInfo modelInfo = new ModelInfo();
            //modelInfo.Singular = "Product";
            //modelInfo.Plural = "Products";

            //modelInfo.Fields = new List<Model.FieldInfo>();
            //modelInfo.Fields.Add(new Model.FieldInfo { Name = "Title", Type = "string", IncludeList = true });
            //modelInfo.Fields.Add(new Model.FieldInfo { Name = "ImagePath", Type = "string", IncludeList = true });
            //modelInfo.Fields.Add(new Model.FieldInfo { Name = "CategoryId", Type = "int", FriendlyName = "Category", FkSingular = "Category" });

            //databaseInfo.Models = new List<ModelInfo>();
            //databaseInfo.Models.Add(modelInfo);

            //string text = "";
            //var serializer = new XmlSerializer(databaseInfo.GetType());
            //using (StringWriter textWriter = new StringWriter())
            //{
            //    serializer.Serialize(textWriter, databaseInfo);
            //    text = textWriter.ToString();
            //}
            //Console.Write(text);

        }
    }
}
