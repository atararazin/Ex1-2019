using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public delegate double Function(double x);

    public class FunctionsContainer
    {
        public Dictionary<string, Function> namesToFuncDict = new Dictionary<string, Function>();
        public Function this[string index]
        {
            get
            {
                if (!this.namesToFuncDict.ContainsKey(index))
                {
                    this.namesToFuncDict[index] = val => val;
                }
                return namesToFuncDict[index];
            }
            set
            {
                //check the specs to see what exactly they want.
                if (this.namesToFuncDict.ContainsKey(index))
                {
                    this.namesToFuncDict[index] = value;
                }
                else
                {
                    Function mission = new Function(value);
                    namesToFuncDict.Add(index, value);
                }
            }
        }

        public List<string> getAllMissions()
        {
            return new List<string>(this.namesToFuncDict.Keys);
        }
    }
}