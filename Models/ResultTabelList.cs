using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasBuildingWeb.Models
{
    public class ResultTabelList<T>
    {
        public int total { get; set; }
        public List<T> objList{ get; set; }
    }
}
