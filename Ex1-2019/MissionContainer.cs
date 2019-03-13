using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public delegate double Mission(double x);

    public class FunctionsContainer
    {
        Mission functionsDelegate;
        public Dictionary<string, Mission> funcNames = new Dictionary<string, Mission>();
        public Mission this[string index]
        {
            get
            {
                return funcNames[index];
            }
            set
            {
                functionsDelegate += value;
                funcNames.Add(index, value);
            }
        }

        public List<string> getAllMissions()
        {
            return new List<string>(this.funcNames.Keys);
        }
    }
}