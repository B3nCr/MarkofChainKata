using System.Collections.Generic;

namespace Kata4Tests
{
    public class StateSpace
    {
        private Dictionary<string, List<string>> _states = new Dictionary<string, List<string>>();

        public StateSpace(string[] tokens)
        {
            for (var i = 0; i < tokens.Length; i++)
            {
                if (i == tokens.Length - 1)
                {
                    _states.Add(tokens[i], new List<string>());
                }
                else if (_states.ContainsKey(tokens[i]))
                {
                    _states[tokens[i]].Add(tokens[i + 1]);
                }
                else
                {
                    _states.Add(tokens[i], new List<string> { tokens[i + 1] });
                }
            }
        }

        public State NextStates(string currentState)
        {
            var result = new State();

            var nextStates = _states[currentState];

            foreach (var state in nextStates)
            {
                result.Add(state, 1d / nextStates.Count);
            }

            return result;
        }
    }

    public class State : Dictionary<string, double>
    {
        public double ProbabilityOf(string state)
        {
            if (this.ContainsKey(state))
            {
                return this[state];
            }

            return 0;
        }
    }
}

