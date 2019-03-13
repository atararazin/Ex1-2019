using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Ex1
{
    public class ComposedMission : IMission
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
        private Queue<Function> queueOfFuncs;

        /// <summary>
        /// Constructor. creates the queue of functions and defines the 
        /// type as "Composed". gets the name as a param.
        /// </summary>
        /// <param name="name"></param>
        public ComposedMission(string name)
        {
            this.name = name;
            this.type = "Composed";
            this.queueOfFuncs = new Queue<Function>();
        }

        public double Calculate(double value)
        {
            Queue<Function> tempQ = new Queue<Function>(this.queueOfFuncs);
            double result = tempQ.Dequeue().Invoke(value);
            Function curr;
            while(tempQ.Count != 0)
            {
                curr = tempQ.Dequeue();
                result = curr.Invoke(result);
            }
            OnCalculate?.Invoke(this, result); //activates event handler
            return result;
        }

        /// <summary>
        /// uses the biulder design pattern to create a ComposedMission.
        /// therefore, simply adds the Function to the queue of Functions 
        /// and then returns the cureent object
        /// </summary>
        /// <param name="missionToAdd"></param>
        /// <returns>the object with the new function in its queue</returns>
        public ComposedMission Add(Function missionToAdd)
        {
            this.queueOfFuncs.Enqueue(missionToAdd);
            return this;
        }
    }
}
