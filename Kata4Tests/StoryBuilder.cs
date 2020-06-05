using System.Text;
using System.Collections.Generic;

namespace Kata4Tests
{
    public class StoryBuilder
    {
        private Dictionary<string, string[]> _tokens = new Dictionary<string, string[]>();

        public StoryBuilder(string input)
        {
            ExtractTokens(input);
        }

        private void ExtractTokens(string input)
        {
            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(input);

            for (var i = 0; i < tokens.Length - 1; i++)
            {
                var key = tokens[i];
                var option = tokens[i + 1];

                _tokens.Add(key, new string[] { option });
            }
        }

        public string TellStory(string seed)
        {
            var builder = new StringBuilder(seed);

            while (seed != null)
            {
                seed = GetNextWord(seed, builder);
            }

            return $"{builder.ToString()}.";
        }

        private string GetNextWord(string seed, StringBuilder builder)
        {
            if (_tokens.ContainsKey(seed))
            {
                var tokens = _tokens[seed];

                builder.Append(" ");
                builder.Append(tokens[0]);

                return tokens[0];
            }

            return null;
        }
    }
}

