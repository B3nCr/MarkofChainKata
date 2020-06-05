using System;

namespace Kata4Tests
{
    public class Tokenizer
    {
        public string[] Tokenize(string input) => input.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }
}

