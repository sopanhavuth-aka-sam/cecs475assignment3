using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assignment3
{
   class Stock
   {
      //Declaring a delegate
      public delegate void StockNotificationHandler(Object sender, StockNotificationEventArgs e);

      //class member
      private string name;
      private int currentValue;
      private int initialValue;
      private int maxChange;
      private int numOfChange;
      private int threshold;
      private Thread thread;
      public event StockNotificationHandler StockEvent;

      //Constructor
      public Stock(string name, int initialValue, int maxChange, int threshold)
      {
         this.name = name;
         this.initialValue = initialValue;
         this.currentValue = initialValue;
         this.maxChange = maxChange;
         this.threshold = threshold;
         //start a thread for this stock
         thread = new Thread(new ThreadStart(Activate));
         thread.Start();
      }

      //Method to control thread
      //sleep for 500ms than updateStock
      private void Activate()
      {
         for (;;)
         {
            Thread.Sleep(50);
            updateStock();
         }
      }

      //UpdateStock = currentValue + rand(maxChange)
      public void updateStock()
      {
         Random rand = new Random();
         //update currentValue with +/- random number < maxChange
         currentValue += rand.Next(-(maxChange), maxChange);
         //Calculate diffValue between current and initalValue
         int diffValue = Math.Abs(currentValue - initialValue);
         //update number of change that take place on this stock
         numOfChange++;
         //throw event if diffValue is larger than threshold
         if(diffValue >= threshold)
         {
            StockNotificationEventArgs args = new StockNotificationEventArgs(name, initialValue, currentValue, diffValue, numOfChange);
            startEvent(args);
         }
      }

      //Kill this object thread
      public void KillThread () {
         this.thread.Abort();
      }

      //start event
      protected virtual void startEvent(StockNotificationEventArgs e)
      {
         //declare event handler
         StockNotificationHandler handler = StockEvent;
         //check event handler
         if (handler != null)
         {
            handler(this, e);
         }
      }
   }

   //SubClass: StockNotificationEventArgs
   public class StockNotificationEventArgs : EventArgs
   {
      private string name;
      private int currentValue;
      private int initialValue;
      private int numOfChange;
      private int diff;

      //constructor
      public StockNotificationEventArgs (string name, int initialValue, int currentValue, int diff, int numOfChange)
      {
         this.name = name;
         this.currentValue = currentValue;
         this.initialValue = initialValue;
         this.numOfChange = numOfChange;
         this.diff = diff;
      }

      //get and set for name
      public string Name
      {
         get { return name; }
         set { name = value; }
      }

      //get and set for currentValue
      public int CurrentValue
      {
         get { return currentValue; }
         set { currentValue = value; }
      }

      //get and set for initialValue
      public int InitialValue
      {
         get { return initialValue; }
         set { initialValue = value; }
      }

      //get and set for diffirence
      public int Difference
      {
         get { return diff; }
         set { diff = value; }
      }

      //get and set for NumOfChanges
      public int NumOfChanges
      {
         get { return numOfChange; }
         set { numOfChange = value; }
      }
   }
}
