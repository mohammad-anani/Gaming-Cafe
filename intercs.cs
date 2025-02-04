using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inter
{

   public struct orderhist
    {
        public int id;
        public List<string> orders;
        public float total;
        public string date;

    }

    public struct addorder
    {
        public string name;
        public float price;
    }
    public class inter
    {
       public static char tablenum;

        public static orderhist oneOrderHist=new orderhist();

       public static List<string> ordersdetails = new List<string>();

        public static string console;
        public static float pph;

        


   

       
       
    }
}
