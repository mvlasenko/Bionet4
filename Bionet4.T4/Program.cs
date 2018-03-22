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
            string webProjectDir = dir.Replace(".T4", ".Admin");

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

                //data project

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

                ContractTemplate contractTemplate = new ContractTemplate();
                contractTemplate.Model = model;
                contractTemplate.RootNamespace = databaseInfo.RootNamespace;
                string contractContent = contractTemplate.TransformText();
                File.WriteAllText(Path.Combine(dataProjectDir, "Contracts", "I" + model.Plural + "Repository.cs"), contractContent);

                //web project

                ModelBinderTemplate modelBinderTemplate = new ModelBinderTemplate();
                modelBinderTemplate.Model = model;
                modelBinderTemplate.RootNamespace = databaseInfo.RootNamespace;
                string modelBinderContent = modelBinderTemplate.TransformText();
                File.WriteAllText(Path.Combine(webProjectDir, "ModelBinding", model.Plural + "FilterModelBinder.cs"), modelBinderContent);

                ControllerTemplate controllerTemplate = new ControllerTemplate();
                controllerTemplate.Model = model;
                controllerTemplate.RootNamespace = databaseInfo.RootNamespace;
                string controllerContent = controllerTemplate.TransformText();
                File.WriteAllText(Path.Combine(webProjectDir, "Controllers", model.Plural + "Controller.cs"), controllerContent);

                ApiControllerTemplate apiControllerTemplate = new ApiControllerTemplate();
                apiControllerTemplate.Model = model;
                apiControllerTemplate.RootNamespace = databaseInfo.RootNamespace;
                string apiControllerContent = apiControllerTemplate.TransformText();
                File.WriteAllText(Path.Combine(webProjectDir, "Controllers\\Api", model.Plural + "Controller.cs"), apiControllerContent);
            }

            RegisterModelBindersTemplate registerModelBindersTemplate = new RegisterModelBindersTemplate();
            registerModelBindersTemplate.Models = databaseInfo.Models;
            registerModelBindersTemplate.RootNamespace = databaseInfo.RootNamespace;
            string registerModelBindersContent = registerModelBindersTemplate.TransformText();
            File.WriteAllText(Path.Combine(webProjectDir, "App_Start", "ModelBindersConfig.cs"), registerModelBindersContent);

            RegisterUnityTemplate registerUnityTemplate = new RegisterUnityTemplate();
            registerUnityTemplate.RootNamespace = databaseInfo.RootNamespace;
            registerUnityTemplate.Models = databaseInfo.Models;
            string registerUnityContent = registerUnityTemplate.TransformText();
            File.WriteAllText(Path.Combine(webProjectDir, "App_Start", "UnityConfig.custom.cs"), registerUnityContent);



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
