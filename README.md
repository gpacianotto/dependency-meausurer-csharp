# dependency-meausurer-csharp

Este projeto desenvolvi durante um trabalho em que foi necessário descobrir os arquivos que possuíam uma certa dependência de um pacote em C#. Ele se utiliza do pacote `Microsoft.CodeAnalysis` para analisar o código e extrair a localização das dependências.

# Exemplo de Uso

Segue abaixo um exemplo de uso dessa ferramenta:

```bash
dotnet run -- "caminho/para/projeto/Projeto.csproj" "Nome.Do.Using" > caminho/para/arquivoDeSaida.txt
```
