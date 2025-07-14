using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DependenciaHelper
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            int quantidadeArquivo = 0;
            int quantidadeDependencia = 0;

            if (args.Length < 2)
            {
                Console.WriteLine("Uso: dotnet run -- <caminho.csproj|.sln> <namespaceAlvo>");
                return;
            }

            string caminho = args[0];
            string namespaceAlvo = args[1];

            MSBuildLocator.RegisterDefaults();
            using var workspace = MSBuildWorkspace.Create();

            var projeto = await workspace.OpenProjectAsync(caminho);

            Console.WriteLine($"Analisando {caminho} para namespace '{namespaceAlvo}'...");

            
            foreach (var document in projeto.Documents)
            {
                quantidadeArquivo++;
                Console.WriteLine(document.FilePath);

                var semanticModel = await document.GetSemanticModelAsync();
                var root = await document.GetSyntaxRootAsync();

                var ids = root.DescendantNodes().OfType<IdentifierNameSyntax>();

                foreach (var id in ids)
                {
                    var symbol = semanticModel.GetSymbolInfo(id).Symbol ?? semanticModel.GetDeclaredSymbol(id);
                    if (symbol == null) continue;

                    var ns = symbol.ContainingNamespace?.ToDisplayString() ?? "";
                    if (ns == namespaceAlvo || ns.StartsWith(namespaceAlvo + "."))
                    {
                        var loc = id.GetLocation().GetLineSpan();
                        quantidadeDependencia++;
                        Console.WriteLine($"\t{loc.StartLinePosition.Line + 1}\t{id}");
                    }
                }
            }

            Console.WriteLine($"Quantidade de arquivos: {quantidadeArquivo}");
            Console.WriteLine($"Quantidade de dependências do {namespaceAlvo}: {quantidadeDependencia}");
        }
    }
}
