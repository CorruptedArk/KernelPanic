using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KernalPanic
{
    class BatchProcessor
    {
        private string logFileName = "log.txt";
        private bool continueBatch;
        private int lastVendorShipSeq;
        private int lastCustOrderSeq;
        private int lastVendorOrderSeq;

        public BatchProcessor()
        {
            continueBatch = true;
            // lastSeq = value from database
        }

        public void run()
        {
            readVendorShipmentFile();

            if(continueBatch)
            {
                readCustomerOrderFile();
            }

            if(continueBatch)
            {
                readVendorOrderFile();
            }

        }

        private void readVendorShipmentFile()
        {
            string fileName = "vendorship.txt";
            string[] vendorShipLines = {};
            try
            {
                vendorShipLines = File.ReadAllLines(fileName);
            }
            catch(Exception e)
            {
                writeLineToLog("Error: vendorship.txt failed to open");
                continueBatch = false;
            }

            if (continueBatch)
            {
                if(vendorShipLines.Length < 2)
                {
                    continueBatch = false;
                    writeLineToLog("Error: Header or Trailer missing in vendorship.txt");
                }
                else if(vendorShipLines[0].Substring(0,2) != "HD")
                {
                    continueBatch = false;
                    writeLineToLog("Error: Header is missing in vendorship.txt");
                }
                else if(vendorShipLines.Last().Substring(0,1) != "T")
                {
                    continueBatch = false;
                    writeLineToLog("Error: Trailer is missing in vendorship.txt");
                }
                else if(int.Parse(vendorShipLines[0].Substring(3,4)) != lastVendorShipSeq + 1)
                {
                    continueBatch = false;
                    writeLineToLog("Error: Invalid Sequence in vendorship.txt");
                }
                else if(int.Parse(vendorShipLines.Last().Substring(2,4)) != vendorShipLines.Length - 2)
                {
                    writeLineToLog("Error: Row count mismatch in vendorship.txt");
                }
                else // the condition without obvious errors
                {
                    int tempVendorID;
                    int tempItemID;
                    int tempQuantityReceived;
                    string tempDateRequested;
                    string tempDateReceived;
                    for(int i = 1; i < vendorShipLines.Length - 1; i++)
                    {
                        tempVendorID = int.Parse(vendorShipLines[i].Substring(0, 2));
                        tempItemID = int.Parse(vendorShipLines[i].Substring(2, 5));
                        tempQuantityReceived = int.Parse(vendorShipLines[i].Substring(7, 6));
                        tempDateRequested = vendorShipLines[i].Substring(13, 10);
                        tempDateReceived = vendorShipLines[i].Substring(23, 10);

                        //verify item exists, valid dates, non-zero quantity, fill backorders, deploy remaining amount of inventory to warehouses based on individual item distribution 
                    }

                    // iterate sequence value
                }
            }

        }

        private void readCustomerOrderFile()
        {
            string fileName = "orders.txt";

        }

        private void readVendorOrderFile()
        {
            string fileName = "vendororder.txt";

        }


        private void writeLineToLog(string message)
        {
            if (!File.Exists(logFileName))
            {
                using (StreamWriter writer = File.CreateText(logFileName))
                {
                    writer.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(logFileName))
                {
                    writer.WriteLine(message);
                }
            }

        }
    }
}
