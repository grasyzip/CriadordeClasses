using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorClasses
{
    public static class Erro
    {
        private static bool existeErro;
        private static string mensagem;

        public static void SetErro(bool erro)
        {
            existeErro = erro;
            if (!erro) mensagem = "";
        }

        public static void SetErro(string msg)
        {
            existeErro = true;
            mensagem = msg;
        }

        public static bool GetErro()
        {
            return existeErro;
        }

        public static string GetMensagem()
        {
            return mensagem;
        }
    }
}
