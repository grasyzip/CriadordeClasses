using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeradorClasses
{
    public static class GeradorBLL
    {
        public static void ValidarDados(string nomeClasse, List<PropriedadeInfo> propriedades, bool isPublic = true)
        {
            Erro.SetErro(false);

            if (string.IsNullOrWhiteSpace(nomeClasse))
            {
                Erro.SetErro("O nome da classe é obrigatório!");
                return;
            }

            if (!char.IsLetter(nomeClasse[0]))
            {
                Erro.SetErro("O nome da classe deve começar com uma letra!");
                return;
            }

            if (nomeClasse.Any(c => !char.IsLetterOrDigit(c)))
            {
                Erro.SetErro("O nome da classe deve conter apenas letras e números!");
                return;
            }

            if (propriedades == null || propriedades.Count == 0)
            {
                Erro.SetErro("Adicione pelo menos uma propriedade à classe!");
                return;
            }

            foreach (PropriedadeInfo prop in propriedades)
            {
                if (string.IsNullOrWhiteSpace(prop.Nome))
                {
                    Erro.SetErro("Nome de propriedade inválido encontrado!");
                    return;
                }

                if (!char.IsLetter(prop.Nome[0]))
                {
                    Erro.SetErro($"A propriedade '{prop.Nome}' deve começar com uma letra!");
                    return;
                }

                if (prop.Nome.Any(c => !char.IsLetterOrDigit(c)))
                {
                    Erro.SetErro($"A propriedade '{prop.Nome}' deve conter apenas letras e números!");
                    return;
                }
            }
        }

        // MODIFICADO: Recebe List<PropriedadeInfo>
        public static string GerarClasse(string nomeClasse, List<PropriedadeInfo> propriedades, bool isPublic = true)
        {
            StringBuilder sb = new StringBuilder();

            // Usings
            sb.AppendLine("using System;");
            sb.AppendLine();

            // Namespace
            sb.AppendLine("namespace MinhasClasses");
            sb.AppendLine("{");

            // Classe com visibilidade escolhida
            string visibilidadeClasse = isPublic ? "public" : "internal"; // private não pode ser usado em classe nível namespace
            sb.AppendLine($"    {visibilidadeClasse} class {nomeClasse}");
            sb.AppendLine("    {");

            // Campos privados (sempre privados - isso não muda)
            foreach (PropriedadeInfo prop in propriedades)
            {
                string campo = prop.Nome.ToLower();
                sb.AppendLine($"        private {GetTipoCSharp(prop.Tipo)} {campo};");
            }
            sb.AppendLine();

            // Propriedades com a visibilidade escolhida
            foreach (PropriedadeInfo prop in propriedades)
            {
                string campo = prop.Nome.ToLower();
                string tipoCSharp = GetTipoCSharp(prop.Tipo);
                string visibilidade = isPublic ? "public" : "private";

                sb.AppendLine($"        {visibilidade} {tipoCSharp} {prop.Nome}");
                sb.AppendLine("        {");
                sb.AppendLine($"            get {{ return {campo}; }}");
                sb.AppendLine($"            set {{ {campo} = value; }}");
                sb.AppendLine("        }");
                sb.AppendLine();

                // Métodos set com a visibilidade escolhida
                sb.AppendLine($"        {visibilidade} void set{prop.Nome}({tipoCSharp} _{campo})");
                sb.AppendLine($"        {{");
                sb.AppendLine($"            {campo} = _{campo};");
                sb.AppendLine($"        }}");
                sb.AppendLine();

                // Métodos get com a visibilidade escolhida
                sb.AppendLine($"        {visibilidade} {tipoCSharp} get{prop.Nome}()");
                sb.AppendLine($"        {{");
                sb.AppendLine($"            return {campo};");
                sb.AppendLine($"        }}");
                sb.AppendLine();
            }

            // Método ToString (sempre público, pois é override)
            sb.AppendLine("        public override string ToString()");
            sb.AppendLine("        {");
            sb.Append("            return $\"");

            for (int i = 0; i < propriedades.Count; i++)
            {
                string campo = propriedades[i].Nome.ToLower();
                if (i > 0) sb.Append(", ");
                sb.Append($"{propriedades[i].Nome}: {{{campo}}}");
            }

            sb.AppendLine("\";");
            sb.AppendLine("        }");

            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        // NOVO MÉTODO: Converte o tipo selecionado para tipo C#
        private static string GetTipoCSharp(string tipoSelecionado)
        {
            return tipoSelecionado switch
            {
                "string" => "string",
                "int" => "int",
                "decimal" => "decimal",
                "double" => "double",
                "float" => "float",
                "bool" => "bool",
                "DateTime" => "DateTime",
                "Guid" => "Guid",
                "long" => "long",
                "short" => "short",
                "byte" => "byte",
                "char" => "char",
                _ => "string"
            };
        }
    }
}