using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces_Repositories;
using SGFlooring.Models;

namespace SGFlooring.Data.FakeRepositories
{
    public class FakeStateRepository : IStateRepository
    {
        private static List<State> states;

        public FakeStateRepository()
        {
            states = new List<State>();

            if (states.Count == 0)
            {
                states = new List<State>()
                {
                    new State() {StateAbbreviation = "OH", StateName = "Ohio", StateTaxRate = 7m},
                    new State() {StateAbbreviation = "IL", StateName = "Illinois", StateTaxRate = 8.25m},
                    new State() {StateAbbreviation = "KY", StateName = "Kentucky", StateTaxRate = 5.9m}
                };
            }

        }

        public State GetState(Order order)
        {
            return states.FirstOrDefault(s => s.StateName.ToString() == order.State.ToString());
        }

        public List<State> GetAllStates()
        {
            return states;
        }
    }
}
