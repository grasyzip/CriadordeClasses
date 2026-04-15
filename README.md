

`CriadordeClasses` é um aplicativo de desktop construído com C# e Windows Forms que permite aos usuários gerar dinamicamente definições de classe C#. Os usuários podem especificar o nome da classe, a visibilidade e as propriedades com seus respectivos tipos de dados. O código gerado é então exibido com realce de sintaxe e pode ser copiado ou salvo. Este projeto foi desenvolvido como parte de um curso de Aplicações para Desktop.

## Features

-   **Geração Dinâmica de Classes::** Crie classes C# em tempo real, definindo sua estrutura através de uma interface amigável.
-   **Gestão Imobiliária:** Adicionar propriedades com vários tipos de dados comuns (por exemplo  `string`, `int`, `decimal`, `bool`, `DateTime`).
-   **Controle Visibilidade:** Escolher entre `público` ou ou `interno` visibilidade para a classe gerada e seus integrantes.
-   **Visualização Código:** Visualize o código C# gerado em uma janela dedicada com destaque básico de sintaxe para palavras-chave.
-   **Exportar Opções:**
    -   Copie o código completo da classe diretamente para a área de transferência.
    -   Baixeixe a aula como a `.cs` arquivo.
-   **Base de Dados Persistência:**  Salvar automaticamente as classes geradas em um banco de dados local do Microsoft Access para referência futura.
-   **Navegador de Classe Salva:** Visualizar, pesquisar e excluir classes salvas anteriormente do banco de dados.

## Tech Stack

-   **Linguagem:** C#
-   **Framework:** .NET 8
-   **UI:** Windows Forms
-   **Database:** Microsoft Access (.accdb)
-   **Data Access:** `System.Data.OleDb`

### Running the Application

1.  Clonar o repositório para sua máquina local:
    ```sh
    git clone https://github.com/grasyzip/CriadordeClasses.git
    ```
2.  Navegue até o diretório do projeto:
    ```sh
    cd CriadordeClasses
    ```
3.  Abra o arquivo da solução `DesafioAsenjo.sln` no Visual Studio.
4.  A aplicação exige o `GeradorClasses.accdb`arquivo de banco de dados para estar no diretório de saída da compilação. Este arquivo está incluído no repositório e deve ser copiado automaticamente na compilação. Se você encontrar problemas, assegure-se que `GeradorClasses.accdb` esteja presente em `DesafioAsenjo/bin/Debug/net8.0-windows/`.
5.  Execute o projeto (`F5`).

## Criadores

Estudantes do 3º semestre do curso de Sistemas de Informação na Universidade Santa Cecília

- Daniel de Alvarenga Assis
- Daniela Catarino Varela
- Grasielly Ribeiro
- Gustavo Kenzo de Barros
