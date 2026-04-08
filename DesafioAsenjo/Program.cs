#nullable disable
using DesafioAsenjo;
using System;
using System.IO;
using System.Windows.Forms;

namespace GeradorClasses
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para a aplicação.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string logPath = Path.Combine(Application.StartupPath ?? string.Empty, "erro_log.txt");

            try
            {
                // Garantir que o diretório existe
                string logDirectory = Path.GetDirectoryName(logPath);
                if (!string.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                File.WriteAllText(logPath, $"Iniciando aplicação em: {DateTime.Now}\r\n");

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += (sender, e) =>
                {
                    string erro = $"Thread Exception: {e.Exception.Message}\r\nStackTrace: {e.Exception.StackTrace}\r\n";
                    File.AppendAllText(logPath, erro);
                };

                AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                    Exception ex = (Exception)e.ExceptionObject;
                    string erro = $"Unhandled Exception: {ex.Message}\r\nStackTrace: {ex.StackTrace}\r\n";
                    File.AppendAllText(logPath, erro);
                };

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                File.AppendAllText(logPath, "Inicializando banco...\r\n");

                // Inicializar banco de dados silenciosamente
                Database.InicializarBanco();

                File.AppendAllText(logPath, "Abrindo Form1...\r\n");
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                string erro = $"Erro fatal no Main: {ex.Message}\r\nStackTrace: {ex.StackTrace}\r\n";
                File.AppendAllText(logPath, erro);

                // Mostrar erro apenas em caso de falha grave
                MessageBox.Show($"Erro fatal ao iniciar aplicação.\n\nDetalhes: {ex.Message}",
                    "Erro Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}