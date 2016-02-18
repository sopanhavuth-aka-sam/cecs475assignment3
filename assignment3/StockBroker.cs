using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3 {
   class StockBroker {
      //class member
      private Object thisLock = new Object(); //use for "critical section" locking
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

      //CustomEvent
      void CustomEvent (object sender, StockNotificationEventArgs e) {
         //lock this code block
         lock (thisLock) {
            string stockFormat = String.Format("{0} \t {1} \t {2} \t {3}", name, e.Name, e.CurrentValue, e.NumOfChanges);
            Console.WriteLine("{0} \t {1} \t {2} \t {3}", name, e.Name, e.CurrentValue, e.NumOfChanges);
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            sb.Append("Written on ->" + now.ToString() + "\t");
            sb.Append(stockFormat);
            try {
               File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "output.txt", sb.ToString() + Environment.NewLine);
            }
            catch (IOException) { //do nothing
            }
         }//unlock code block
      }
   }
}
