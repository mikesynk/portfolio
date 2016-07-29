using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces_Repositories;
using SGFlooring.Models;

namespace SGFlooring.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        private const string _filepath = @"DataFiles\State.txt";

        public State GetState(Order order)
        {
            throw new NotImplementedException();
        }

        public List<State> GetAllStates()
        {
            List<State> results = new List<State>();

            var rows = File.ReadAllLines(_filepath);
            // start at 1 to skip the header
            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');

                var state = new State();
                state.StateAbbreviation = columns[0];
                state.StateName = columns[1];
                state.StateTaxRate = decimal.Parse(columns[2]);
                results.Add(state);
            }
            return results;
        }
    }
}
