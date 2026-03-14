using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public class Token
        {
            public string Lexeme { get; set; }
            public string Type { get; set; }

            public Token(string lexeme, string type)
            {
                Lexeme = lexeme;
                Type = type;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Split_Click(object sender, EventArgs e)
        {
            dgvTokens.Rows.Clear();

            List<Token> tokens = Scan(txtCode.Text);

            foreach (Token token in tokens)
            {
                dgvTokens.Rows.Add(token.Lexeme, token.Type);
            }

        }
        List<Token> Scan(string code)
        {
            List<Token> tokens = new List<Token>();

            string pattern =
            @"\/\*[\s\S]*?\*\/" + "|" +
            "\"[^\"]*\"" + "|" +
            @"\b(int|float|string|read|write|repeat|until|if|elseif|else|then|return|endl)\b" + "|" +
            @"[a-zA-Z][a-zA-Z0-9]*" + "|" +
            @"[0-9]+(\.[0-9]+)?" + "|" +
            @":=" + "|" +
            @"<>|<|>|=" + "|" +
            @"&&|\|\|" + "|" +
            @"[\+\-\*/]" + "|" +
            @"[;,\(\)\{\}]";

            MatchCollection matches = Regex.Matches(code, pattern);

            foreach (Match m in matches)
            {
                string lexeme = m.Value;
                string type = GetTokenType(lexeme);

                tokens.Add(new Token(lexeme, type));
            }

            return tokens;
        }
        string GetTokenType(string lexeme)
        {
            if (Regex.IsMatch(lexeme, @"^(int|float|string|read|write|repeat|until|if|elseif|else|then|return|endl)$"))
                return "Keyword";

            if (Regex.IsMatch(lexeme, @"^[a-zA-Z][a-zA-Z0-9]*$"))
                return "Identifier";

            if (Regex.IsMatch(lexeme, @"^[0-9]+(\.[0-9]+)?$"))
                return "Number";

            if (Regex.IsMatch(lexeme, "^\"[^\"]*\"$"))
                return "String";

            if (lexeme == ":=")
                return "Assignment Operator";

            if (Regex.IsMatch(lexeme, @"^(<>|<|>|=)$"))
                return "Condition Operator";

            if (Regex.IsMatch(lexeme, @"^(\&\&|\|\|)$"))
                return "Boolean Operator";

            if (Regex.IsMatch(lexeme, @"^[\+\-\*/]$"))
                return "Arithmetic Operator";

            if (Regex.IsMatch(lexeme, @"^[;,\(\)\{\}]$"))
                return "Symbol";

            return "Unknown";
        }

    }
}
