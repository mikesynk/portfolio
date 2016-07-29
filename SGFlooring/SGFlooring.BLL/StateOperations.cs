using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Factories;
using SGFlooring.Data.Repositories;
using SGFlooring.Models;

namespace SGFlooring.BLL
{
    public class StateOperations
    {
        public State GetState(string stateAbbreviation)
        {
            State state = new State() {StateAbbreviation = stateAbbreviation};
            var stateRepo = StateRepositoryFactory.GetStateRepository();

            List<State> states = stateRepo.GetAllStates();

            foreach (State s in states)
            {
                if (s.StateAbbreviation.ToUpper() == state.StateAbbreviation.ToUpper())
                {
                    state.StateName = s.StateName;
                    state.StateTaxRate = s.StateTaxRate;
                }
            }
            return state;
        }
    }
}
