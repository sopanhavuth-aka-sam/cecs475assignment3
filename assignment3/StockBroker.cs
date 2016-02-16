using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3 {
   class StockBroker {
      //private Object thisLock = new Object();
      //class member
      private string name;
      private List<Stock> stockList = new List<Stock>();

      //constructor
      public StockBroker (string name) {
         this.name = name;
      }

      //get and set for name
      public string StockBrokerName {
         get {
            return name;
         }
         set {
            this.name = value;
         }
      }

      //add a stock into this broker's stockList
      //and invoke CustomEvent
      public void AddStock (Stock newStock) {
         stockList.Add(newStock);
         newStock.StockEvent += CustomEvent;
      }
      //Work on this; Formatting errors
      //CustomEvent
      void CustomEvent (object sender, StockNotificationEventArgs e) {

         //lock (thisLock) {
         string stockFormat = String.Format("{0} \t {1} \t {2} \t {3}", name, e.Name, e.CurrentValue, e.NumOfChanges);
         Console.WriteLine("{0} \t {1} \t {2} \t {3}", name, e.Name, e.CurrentValue, e.NumOfChanges);
         StringBuilder sb = new StringBuilder();
         DateTime now = DateTime.Now;
         sb.Append("Written on ->" + now.ToString() + "\t");
         sb.Append(stockFormat);
         //sb.Append(name + "\t");
         //sb.Append(e.Name + "\t\t");
         //sb.Append(e.InitialValue.ToString() + "\t");
         //sb.Append(e.CurrentValue.ToString() + "\t");
         //sb.Append(e.Difference.ToString() + "\t");
         //sb.Append(e.NumOfChanges.ToString() + "\t");

         try {
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "output.txt", sb.ToString() + Environment.NewLine);
         }
         catch (IOException) { //do nothing
         }
         //}
      }
   }
}
