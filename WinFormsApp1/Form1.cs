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

            // Phase 2: Run the Parser
            if (tokens.Count == 0) return;

            try
            {
                MiniLParser parser = new MiniLParser(tokens);
                parser.ParseProgram();
                MessageBox.Show("Success: Your miniL code is correct!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Syntax Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        List<Token> Scan(string code)
        {
            List<Token> tokens = new List<Token>();

            string pattern =
                @"\/\*[\s\S]*?\*\/" + "|" +
                "\"[^\"]*\"" + "|" +
                @"\b(num|text|check|otherwise|until|repeat|then)\b" + "|" +
                @"[a-zA-Z][a-zA-Z0-9]*" + "|" +
                @"[0-9]+(\.[0-9]+)?" + "|" +
                @":=" + "|" +
                @"==|!=|<>|<=|>=|<|>" + "|" +
                @"[\+\-\*/]" + "|" +
                @"[;,\(\)\{\}]";

            MatchCollection matches = Regex.Matches(code, pattern);

            foreach (Match m in matches)
            {
                string lexeme = m.Value;
                string type = GetTokenType(lexeme);
                if (type == "Comment") continue;
                tokens.Add(new Token(lexeme, type));
            }

            return tokens;
        }

        string GetTokenType(string lexeme)
        {
            if (Regex.IsMatch(lexeme, @"^\/\*[\s\S]*?\*\/$"))
                return "Comment";

            if (Regex.IsMatch(lexeme, @"^(num|text|check|otherwise|until|repeat|then)$"))
                return "Keyword";

            if (Regex.IsMatch(lexeme, @"^[a-zA-Z][a-zA-Z0-9]*$"))
                return "Identifier";

            if (Regex.IsMatch(lexeme, @"^[0-9]+(\.[0-9]+)?$"))
                return "Number";

            if (Regex.IsMatch(lexeme, "^\"[^\"]*\"$"))
                return "String";

            if (lexeme == ":=")
                return "Assignment_Op";

            if (Regex.IsMatch(lexeme, @"^(==|!=|<>|<=|>=|<|>)$"))
                return "Relational_Op";

            if (lexeme == "+") return "Plus_Op";
            if (lexeme == "-") return "Minus_Op";
            if (lexeme == "*") return "Multiply_Op";
            if (lexeme == "/") return "Divide_Op";

            if (lexeme == ";") return "Semicolon";
            if (lexeme == "(") return "Left_Paren";
            if (lexeme == ")") return "Right_Paren";
            if (lexeme == "{") return "Left_Brace";
            if (lexeme == "}") return "Right_Brace";
            if (lexeme == ",") return "Comma";

            return "Unknown";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}