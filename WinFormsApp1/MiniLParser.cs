using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class MiniLParser
    {
        private List<Form1.Token> tokens;
        private int index = 0;
        private Form1.Token currentToken;

        public MiniLParser(List<Form1.Token> tokens)
        {
            this.tokens = tokens;
            if (tokens.Count > 0)
                currentToken = tokens[index];
        }

        private void Match(string expected)
        {
            if (index < tokens.Count &&
                (currentToken.Lexeme == expected || currentToken.Type == expected))
            {
                index++;
                if (index < tokens.Count)
                    currentToken = tokens[index];
            }
            else
            {
                string found = (index < tokens.Count) ? currentToken.Lexeme : "end of input";
                throw new Exception($"Expected '{expected}' but found '{found}'");
            }
        }

        public void ParseProgram()
        {
            ParseStatements();
            if (index < tokens.Count)
                throw new Exception($"Unexpected token '{currentToken.Lexeme}' at end of program");
        }

        private void ParseStatements()
        {
            ParseStatement();
            if (index < tokens.Count && currentToken.Lexeme == ";")
            {
                Match(";");
                if (index < tokens.Count &&
                    currentToken.Lexeme != "}" &&
                    currentToken.Lexeme != "until")
                {
                    ParseStatements();
                }
            }
        }

        private void ParseStatement()
        {
            if (index >= tokens.Count) return;

            if (currentToken.Lexeme == "num" || currentToken.Lexeme == "text")
            {
                ParseDeclaration();
            }
            else if (currentToken.Type == "Identifier")
            {
                ParseAssignment();
            }
            else if (currentToken.Lexeme == "check")
            {
                ParseCheck();
            }
            else if (currentToken.Lexeme == "repeat")
            {
                ParseRepeat();
            }
            else if (currentToken.Lexeme == "{")
            {
                ParseBlock();
            }
            else
            {
                throw new Exception(
                    $"Error: A statement cannot start with '{currentToken.Lexeme}' ({currentToken.Type})");
            }
        }

        private void ParseDeclaration()
        {
            if (currentToken.Lexeme == "num") Match("num");
            else Match("text");
            ParseAssignment();
        }

        private void ParseAssignment()
        {
            if (currentToken.Type != "Identifier")
                throw new Exception(
                    $"Error: Cannot assign to '{currentToken.Lexeme}'. Must be an Identifier.");
            Match("Identifier");
            Match(":=");
            ParseExpression();
        }

        private void ParseCheck()
        {
            Match("check");
            Match("(");
            ParseCondition();
            Match(")");
            ParseBlock();
            if (index < tokens.Count && currentToken.Lexeme == "otherwise")
            {
                Match("otherwise");
                ParseBlock();
            }
        }

        private void ParseRepeat()
        {
            Match("repeat");
            ParseBlock();
            Match("until");
            Match("(");
            ParseCondition();
            Match(")");
        }

        private void ParseBlock()
        {
            if (currentToken.Lexeme == "{")
            {
                Match("{");
                ParseStatements();
                Match("}");
            }
            else
            {
                ParseStatement();
            }
        }

        private void ParseCondition()
        {
            ParseExpression();
            if (index < tokens.Count &&
                (currentToken.Lexeme == "<" || currentToken.Lexeme == ">" ||
                 currentToken.Lexeme == "==" || currentToken.Lexeme == "!=" ||
                 currentToken.Lexeme == "<>"))
            {
                Match(currentToken.Lexeme);
            }
            else
            {
                throw new Exception("Expected Relational Operator (<, >, ==, !=)");
            }
            ParseExpression();
        }

        private void ParseExpression()
        {
            ParseTerm();
            while (index < tokens.Count &&
                   (currentToken.Lexeme == "+" || currentToken.Lexeme == "-"))
            {
                Match(currentToken.Lexeme);
                ParseTerm();
            }
        }

        private void ParseTerm()
        {
            ParseFactor();
            while (index < tokens.Count &&
                   (currentToken.Lexeme == "*" || currentToken.Lexeme == "/"))
            {
                Match(currentToken.Lexeme);
                ParseFactor();
            }
        }

        private void ParseFactor()
        {
            if (currentToken.Type == "Identifier")
                Match("Identifier");
            else if (currentToken.Type == "Number")
                Match("Number");
            else if (currentToken.Lexeme == "(")
            {
                Match("(");
                ParseExpression();
                Match(")");
            }
            else
                throw new Exception(
                    $"Expected Identifier or Number but found '{currentToken.Lexeme}'");
        }
    }
}