# dependency-meausurer-csharp

## English

This project was developed during a task on a job that it's main goal was mapping the the dependencies from a C# project and eliminate them. This project uses the package `Microsoft.CodeAnalysis` to analyse the codebase of a csharp project (`.csproj` file based) and extract the location of the files that uses the given dependency.

### Getting Started

To use this application, you can use it on your prompt as follows:

```bash
dotnet run -- "path/to/your/project/Project.csproj" "Package.Name" > path/to/OutputFile.txt
```

---

## Português

Este projeto desenvolvi durante um trabalho em que foi necessário descobrir os arquivos que possuíam uma certa dependência de um pacote em C#. Ele se utiliza do pacote `Microsoft.CodeAnalysis` para analisar o código e extrair a localização das dependências.

### Exemplo de Uso

Segue abaixo um exemplo de uso dessa ferramenta:

```bash
dotnet run -- "caminho/para/projeto/Projeto.csproj" "Nome.Do.Using" > caminho/para/arquivoDeSaida.txt
```
