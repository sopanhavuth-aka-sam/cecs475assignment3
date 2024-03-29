﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
   class StockApplication
   {
      static void Main(string[] args)
      {
         File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "output.txt", "");

         Stock stock1 = new Stock("Technology", 160, 5, 15);
         Stock stock2 = new Stock("Retail", 30, 2, 6);
         Stock stock3 = new Stock("Banking", 90, 4, 10);
         Stock stock4 = new Stock("Commodity", 500, 20, 50);

         StockBroker b1 = new StockBroker("Broker 1");
         b1.AddStock(stock1);
         b1.AddStock(stock2);

         StockBroker b2 = new StockBroker("Broker 2");
         b2.AddStock(stock1);
         b2.AddStock(stock3);
         b2.AddStock(stock4);

         StockBroker b3 = new StockBroker("Broker 3");
         b3.AddStock(stock1);
         b3.AddStock(stock3);

         StockBroker b4 = new StockBroker("Broker 4");
         b4.AddStock(stock1);
         b4.AddStock(stock2);
         b4.AddStock(stock3);
         b4.AddStock(stock4);

         System.Threading.Thread.Sleep(2000);
         stock1.KillThread();
         stock2.KillThread();
         stock3.KillThread();
         stock4.KillThread();

      }
   }
}
