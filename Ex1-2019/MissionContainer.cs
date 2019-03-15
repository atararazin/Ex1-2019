using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public delegate double Function(double x);

    /// <summary>
    /// the container for the functions. Uses csharp's indexer so that it can comfortably be indexed.
    /// each name is mapped to a Function (see above delegate), using a dictionary.
    /// This class has the ability to return all existing missions.
    /// </summary>
    public class FunctionsContainer
    {
        public Dictionary<string, Function> namesToFuncDict = new Dictionary<string, Function>();
        /// <summary>
        /// indexer. Every index is mapped to its Function (a pointer to a function).
        /// has set and get properties.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Function this[string index]
        {
            get
            {
                if (!this.namesToFuncDict.ContainsKey(index))//if the index doesn't exist assign a default to it
                {
                    this.namesToFuncDict[index] = val => val;//default function
                }
                return namesToFuncDict[index];
            }
            set
            {
                if (this.namesToFuncDict.ContainsKey(index))//checks if index exists
                {
                    this.namesToFuncDict[index] = value;//have it point to a new value
                }
                else//new index
                {
                    Function mission = new Function(value);//create new delegate
                    namesToFuncDict.Add(index, value);//add to dictionary
                }
            }
        }

        /// <summary>
        /// return the list of missions' names in string form
        /// </summary>
        /// <returns>the list of strings</returns>
        public List<string> getAllMissions()
        {
            return new List<string>(this.namesToFuncDict.Keys);
        }
    }
}