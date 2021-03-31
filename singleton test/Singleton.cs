using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton_test
{
    public sealed class Singleton
    {
            Singleton()
            {
            }
            private static readonly object padlock = new object();
            private static Singleton instance = null;
        
            //I named it gub out of desperation while I was trying things and got too lazy to change it
            string gub = null;
            public static Singleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (padlock)
                        {
                            if (instance == null)
                            {
                                instance = new Singleton();
                            }
                        }
                    }
                    return instance;
                }
            }
        public string Add(string itemName,string priceName)
        {           
            using (StreamWriter sw = new StreamWriter("Log.txt",true))
            {
                sw.WriteLine(itemName + " was Added for R" + priceName);
                sw.Close();
               
            }
            return gub;
        }

        public string Delete(string itemName)
        {
            using (StreamWriter sw = new StreamWriter("Log.txt",true))
            {
                sw.WriteLine(itemName + " was Deleted");
                sw.Close();
            }
            return gub;
        }
    }
}
