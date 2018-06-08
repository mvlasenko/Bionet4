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
            string clientProjectDir = dir.Replace(".T4", "");

            DatabaseInfo databaseInfo = new DatabaseInfo();

            var serializer = new XmlSerializer(databaseInfo.GetType());
            using (StreamReader reader = new StreamReader(path))
            {
                databaseInfo = (DatabaseInfo)serializer.Deserialize(reader);
            }

            foreach (ModelInfo model in databaseInfo.Models)
            {
                //preparing FK collection names
                model.CollectionModel = databaseInfo.Models.Where(m => m.Fields.Any(f => f.FkSingular == model.Singular)).ToList();

                //data project

                ModelTemplate modelTemplate = new ModelTemplate();
                modelTemplate.Model = model;
                modelTemplate.RootNamespace = databaseInfo.RootNamespace;
                string modelContent = modelTemplate.TransformText();
                File.WriteAllText(Path.Combine(dataProjectDir, "Models", model.Singular + ".cs"), modelContent);

                MappingTemplate mapTemplate = new MappingTemplate();
                mapTemplate.Model = model;
                mapTemplate.RootNamespace = databaseInfo.RootNamespace;
                string mapContent = mapTemplate.TransformText();
                File.WriteAllText(Path.Combine(dataProjectDir, "Models\\Mapping", model.Singular + "Map.cs"), mapContent);

                RepositoryTemplate repositoryTemplate = new RepositoryTemplate();
                repositoryTemplate.Model = model;
                repositoryTemplate.RootNamespace = databaseInfo.RootNamespace;
                string repositoryContent = repositoryTemplate.TransformText();
                File.WriteAllText(Path.Combine(dataProjectDir, "Repository", model.Plural + "Repository.cs"), repositoryContent);

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

                EditorTemplate editorTemplate = new EditorTemplate();
                editorTemplate.Model = model;
                editorTemplate.RootNamespace = databaseInfo.RootNamespace;
                string editorContent = editorTemplate.TransformText();
                File.WriteAllText(Path.Combine(webProjectDir, "Views\\Shared\\EditorTemplates", "_" + model.Singular + ".cshtml"), editorContent);

                ////client web project

                //ApiControllerTemplate apiControllerTemplate = new ApiControllerTemplate();
                //apiControllerTemplate.Model = model;
                //apiControllerTemplate.RootNamespace = databaseInfo.RootNamespace;
                //string apiControllerContent = apiControllerTemplate.TransformText();
                //File.WriteAllText(Path.Combine(clientProjectDir, "Controllers\\Api", model.Plural + "Controller.cs"), apiControllerContent);
            }

            ContextTemplate contextTemplate = new ContextTemplate();
            contextTemplate.RootNamespace = databaseInfo.RootNamespace;
            contextTemplate.Models = databaseInfo.Models;
            string contextContent = contextTemplate.TransformText();
            File.WriteAllText(Path.Combine(dataProjectDir, "Models", databaseInfo.RootNamespace + "Context.cs"), contextContent);

            RegisterModelBindersTemplate registerModelBindersTemplate = new RegisterModelBindersTemplate();
            registerModelBindersTemplate.Models = databaseInfo.Models;
            registerModelBindersTemplate.RootNamespace = databaseInfo.RootNamespace;
            string registerModelBindersContent = registerModelBindersTemplate.TransformText();
            File.WriteAllText(Path.Combine(webProjectDir, "App_Start", "ModelBindersConfig.cs"), registerModelBindersContent);

            RegisterUnityTemplate registerUnityTemplate1 = new RegisterUnityTemplate();
            registerUnityTemplate1.RootNamespace = databaseInfo.RootNamespace + ".Admin";
            registerUnityTemplate1.Models = databaseInfo.Models;
            string registerUnityContent1 = registerUnityTemplate1.TransformText();
            File.WriteAllText(Path.Combine(webProjectDir, "App_Start", "UnityConfig.custom.cs"), registerUnityContent1);

            RegisterUnityTemplate registerUnityTemplate2 = new RegisterUnityTemplate();
            registerUnityTemplate2.RootNamespace = databaseInfo.RootNamespace;
            registerUnityTemplate2.Models = databaseInfo.Models;
            string registerUnityContent2 = registerUnityTemplate2.TransformText();
            File.WriteAllText(Path.Combine(clientProjectDir, "App_Start", "UnityConfig.custom.cs"), registerUnityContent2);

            MiscTemplate miscTemplate = new MiscTemplate();
            miscTemplate.Models = databaseInfo.Models;
            string miscContent = miscTemplate.TransformText();
            File.WriteAllText(Path.Combine(webProjectDir, "Misc.txt"), miscContent);

        }
    }
}
