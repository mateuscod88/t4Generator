using Entities;
using Entities.Mappings;
using Handlers;
using Handlers.Command.AS;
using Handlers.Command.DS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repositories.IRepository;
using Repositories.Repository;
using System;
using System.IO;

namespace t4LiquiBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPartNamespaceAS = "EZDRP.Sprawy.AS";
            var firstPartNamespaceDS = "EZDRP.Sprawy.DS";
            var firstPartNamespaceIRepository = "EZDRP.Sprawy.DS.Data.Repositories";
            var firstPartNamespaceRepository = "EZDRP.Sprawy.DS.DataEF.Repositories";
            var firstPartNamespaceMappings =  "EZDRP.Sprawy.DS.DataEF.Mappings";
            var command = "Command";
            var query = "Query";
            var operationType = query;
            var repositoryLabel = "Repository";
            var ormLabel = "EF";
            var mappingsLabel = "Mappings";
            //var entityName = typeof(SprawaNotatka).Name;
            var entityName = typeof(SprawaNotatka).Name;

            var name = "PobierzHistorieNotatki";
            Directory.CreateDirectory($"../../../DS{name}");
            Directory.CreateDirectory($"../../../AS{name}");
            Directory.CreateDirectory($"../../../IRepository{entityName}");
            Directory.CreateDirectory($"../../../Repository{entityName}");
            Directory.CreateDirectory($"../../../Mappings{entityName}");


            //var commandASDto = new CommandASDto($"{firstPartNamespaceAS}.CommandsDto",name);
            //var commandASHandler = new CommandASHandler($"{firstPartNamespaceAS}.CommandsRole.Commands", name);

            //var commandDSDto = new CommandDSDto($"{firstPartNamespaceDS}.CommandsDto", name);
            //var commandDSHandler = new CommandDSHandler($"{firstPartNamespaceDS}.CommandsRole.Commands", name);

            var commandASDto = new CommandASDto($"{firstPartNamespaceAS}.QueriesDto", name,operationType);
            var commandASHandler = new CommandASHandler($"{firstPartNamespaceAS}.QueriesRole.Queries", name,operationType);

            var commandDSDto = new CommandDSDto($"{firstPartNamespaceDS}.QueriesDto", name,operationType);
            var commandDSHandler = new CommandDSHandler($"{firstPartNamespaceDS}.QueriesRole.Queries", name, operationType);

            var handlersGenerator = new HandlersFileGenerator();
            handlersGenerator.Generate(commandASDto.TransformText(),$"{name}{operationType}.cs",$"../../../AS{name}/");
            handlersGenerator.Generate(commandASHandler.TransformText(), $"{name}Handler.cs", $"../../../AS{name}/");
            handlersGenerator.Generate(commandDSDto.TransformText(), $"{name}{operationType}.cs", $"../../../DS{name}/");
            handlersGenerator.Generate(commandDSHandler.TransformText(), $"{name}Handler.cs", $"../../../DS{name}/");

            //var repositoryInterface = new RepositoryInterface(firstPartNamespaceIRepository, entityName,command);
            //handlersGenerator.Generate(repositoryInterface.TransformText(), $"I{entityName}{command}{repositoryLabel}.cs", $"../../../IRepository{entityName}/");


            //var repository = new RepositoryConcrete(firstPartNamespaceRepository,entityName, command);
            //handlersGenerator.Generate(repository.TransformText(), $"{entityName}{command}{ormLabel}{repositoryLabel}.cs", $"../../../Repository{entityName}/");
            
            //var mappings = new Mappings(firstPartNamespaceMappings, entityName);
            //handlersGenerator.Generate(mappings.TransformText(),$"{entityName}{mappingsLabel}.cs", $"../../../Mappings{entityName}/");

            var repositoryInterface = new RepositoryInterface(firstPartNamespaceIRepository, entityName, operationType);
            handlersGenerator.Generate(repositoryInterface.TransformText(), $"I{entityName}{operationType}{repositoryLabel}.cs", $"../../../IRepository{entityName}/");


            var repository = new RepositoryConcrete(firstPartNamespaceRepository, entityName, operationType);
            handlersGenerator.Generate(repository.TransformText(), $"{entityName}{operationType}{ormLabel}{repositoryLabel}.cs", $"../../../Repository{entityName}/");

            var mappings = new Mappings(firstPartNamespaceMappings, entityName);
            handlersGenerator.Generate(mappings.TransformText(), $"{entityName}{mappingsLabel}.cs", $"../../../Mappings{entityName}/");

            var lbGenerator = new LiquiBaseFromEntitieGenerator();
            lbGenerator.Generator<SprawaNotatka>();
            lbGenerator.Generator<SprawaNotatkaWersja>();
            Console.WriteLine("Hello World!");
        }
    }
}
