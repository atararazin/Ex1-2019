using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private IMission m;

        public ComposedMission(string name)
        {
            this.name = name;
            this.type = "Composed";
        }

        public double Calculate(double value)
        {
            throw new NotImplementedException();
        }

        public ComposedMission Add(Mission missionToAdd)
        {
            if (this.m == null)
            {
                this.m = new SingleMission(missionToAdd, this.name);
            }
            else
            {
                //add to list.
            }
            return this;
        }
    }
}
