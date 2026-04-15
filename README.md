# CriadordeClasses
[![Ask DeepWiki](https://devin.ai/assets/askdeepwiki.png)](https://deepwiki.com/grasyzip/CriadordeClasses)

`CriadordeClasses` is a desktop application built with C# and Windows Forms that allows users to dynamically generate C# class definitions. Users can specify the class name, visibility, and properties with their respective data types. The generated code is then displayed with syntax highlighting and can be copied or saved. This project was developed as part of a Desktop Applications course.

## Features

-   **Dynamic Class Generation:** Create C# classes on the fly by defining their structure through a user-friendly interface.
-   **Property Management:** Add properties with various common data types (e.g., `string`, `int`, `decimal`, `bool`, `DateTime`).
-   **Visibility Control:** Choose between `public` or `internal` visibility for the generated class and its members.
-   **Code Visualization:** View the generated C# code in a dedicated window with basic syntax highlighting for keywords.
-   **Export Options:**
    -   Copy the full class code directly to the clipboard.
    -   Download the class as a `.cs` file.
-   **Database Persistence:** Automatically save generated classes to a local Microsoft Access database for future reference.
-   **Saved Class Browser:** View, search, and delete previously saved classes from the database.

## Tech Stack

-   **Language:** C#
-   **Framework:** .NET 8
-   **UI:** Windows Forms
-   **Database:** Microsoft Access (.accdb)
-   **Data Access:** `System.Data.OleDb`

## Getting Started

### Prerequisites

-   .NET 8 SDK
-   Visual Studio 2022 or later
-   Microsoft Access Database Engine 2016 Redistributable (to provide the `Microsoft.ACE.OLEDB.12.0` provider)

### Running the Application

1.  Clone the repository to your local machine:
    ```sh
    git clone https://github.com/grasyzip/CriadordeClasses.git
    ```
2.  Navigate to the project directory:
    ```sh
    cd CriadordeClasses
    ```
3.  Open the solution file `DesafioAsenjo.sln` in Visual Studio.
4.  The application requires the `GeradorClasses.accdb` database file to be in the build output directory. This file is included in the repository and should be copied automatically on build. If you encounter issues, ensure `GeradorClasses.accdb` is present in `DesafioAsenjo/bin/Debug/net8.0-windows/`.
5.  Build the solution (`Ctrl+Shift+B`) and run the project (`F5`).

## How to Use

1.  **Define the Class:**
    -   Enter a name for your class in the "Nome da Classe" field.
    -   Select the desired visibility (`Public` or `Private`, which maps to internal).

2.  **Add Properties:**
    -   In the "Propriedade" field, enter the name for a property (e.g., `FirstName`).
    -   Select its data type from the "Tipo" dropdown menu (e.g., `string`).
    -   Click the **ADICIONAR** button. The property will appear in the list below.
    -   Repeat this step for all required properties.

3.  **Generate the Class:**
    -   Once all properties are added, click the **⚙️ GERAR CLASSE** button.

4.  **View and Export:**
    -   A new window will appear, displaying the complete C# class code.
    -   Click **📋 COPIAR** to copy the code to your clipboard.
    -   Click **💾 DOWNLOAD .cs** to save the code as a `.cs` file.
    -   The generated class is also saved automatically to the database.

5.  **Manage Saved Classes:**
    -   From the main window, click **📂 CLASSES SALVAS** to open the browser.
    -   Here you can view a list of all saved classes. Select a class to **👁️ VISUALIZAR** or **🗑️ EXCLUIR** it.
