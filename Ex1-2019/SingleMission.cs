using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
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

        //constructor
        public SingleMission(Function mission, String Name)
        {
            this.mission = mission;
            this.name = Name;
            this.type = "Single";
        }

        /// <summary>
        /// the execute part of the command design pattern
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value after calculated</returns>
        public double Calculate(double value)
        {
            //activate eventhandler
            OnCalculate?.Invoke(this, value);
            return this.mission.Invoke(value);
        }
    }
}
