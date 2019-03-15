using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    /// <summary>
    /// SingleMission - can calculate a single function and not more. gets in its constructor a name and 
    /// a funciton/mission that it can calculate.
    /// </summary>
    public class SingleMission : IMission
    {
        private string name;
        public String Name
        {
            get { return name; }
        }

        private string type;
        public String Type
        {
            get { return type; }
        }

        public event EventHandler<double> OnCalculate;
        private Function mission;
        /// <summary>
        /// constructor. gets mission and name as params, 
        /// type gets defines here because it's always "Single"
        /// </summary>
        /// <param name="mission"></param>
        /// <param name="Name"></param>
        public SingleMission(Function mission, String Name)
        {
            this.mission = mission;
            this.name = Name;
            this.type = "Single";
        }

        /// <summary>
        /// the execute part of the command design pattern.
        /// also activates the EventHandler.
        /// this method calculates the final result
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value after calculated</returns>
        public double Calculate(double value)
        {
            double result = this.mission.Invoke(value);
            OnCalculate?.Invoke(this, result); //activates event handler
            return result;
        }
    }
}
