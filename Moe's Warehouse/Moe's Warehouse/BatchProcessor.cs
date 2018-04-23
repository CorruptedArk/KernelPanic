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

        public bool run()
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
            return continueBatch;
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
                writeLineToLog("Error: " + fileName + " failed to open");
                continueBatch = false;
            }

            if (continueBatch)
            {
                if(vendorShipLines.Length < 2)
                {
                    continueBatch = false;
                    writeLineToLog("Error: Header or Trailer missing in " + fileName);
                }
                else if(vendorShipLines[0].Substring(0,2) != "HD")
                {
                    continueBatch = false;
                    writeLineToLog("Error: Header is missing in " + fileName);
                }
                else if(vendorShipLines.Last().Substring(0,1) != "T")
                {
                    continueBatch = false;
                    writeLineToLog("Error: Trailer is missing in " + fileName);
                }
                else if(int.Parse(vendorShipLines[0].Substring(3,4)) != lastVendorShipSeq + 1)
                {
                    continueBatch = false;
                    writeLineToLog("Error: Invalid Sequence in " + fileName);
                }
                else if(int.Parse(vendorShipLines.Last().Substring(2,4)) != vendorShipLines.Length - 2)
                {
                    writeLineToLog("Error: Row count mismatch in " + fileName);
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
            string[] customerOrderLines = { };

            try
            {
                customerOrderLines = File.ReadAllLines(fileName);
            }
            catch (Exception e)
            {
                writeLineToLog("Error: " + fileName + " failed to open");
                continueBatch = false;
            }

            if(continueBatch)
            {
                if (customerOrderLines.Length < 2)
                {
                    continueBatch = false;
                    writeLineToLog("Error: Header or Trailer missing in " + fileName);
                }
                else if (customerOrderLines[0].Substring(0, 2) != "HD")
                {
                    continueBatch = false;
                    writeLineToLog("Error: Header is missing in " + fileName);
                }
                else if (customerOrderLines.Last().Substring(0, 1) != "T")
                {
                    continueBatch = false;
                    writeLineToLog("Error: Trailer is missing in " + fileName);
                }
                else if (int.Parse(customerOrderLines[0].Substring(3, 4)) != lastVendorShipSeq + 1)
                {
                    continueBatch = false;
                    writeLineToLog("Error: Invalid Sequence in " + fileName);
                }
                else if (int.Parse(customerOrderLines.Last().Substring(2, 4)) != customerOrderLines.Length - 2)
                {
                    writeLineToLog("Error: Row count mismatch in " + fileName);
                }
                else
                {
                    List<int> customerInfoLineIds = new List<int>();
                    List<int> itemCountLineIds = new List<int>();

                    for(int i = 0; i < customerOrderLines.Length; i++)
                    {
                        if(customerOrderLines[i][0] == 'C')
                        {
                            customerInfoLineIds.Add(i);
                        }
                        else if(customerOrderLines[i][0] == 'L')
                        {
                            itemCountLineIds.Add(i);
                        }
                    }

                    if(customerInfoLineIds.Count != int.Parse(customerOrderLines[customerOrderLines.Length - 2].Substring(1,3)))
                    {
                        writeLineToLog("Error: Order count mismatch in " + fileName);
                    }
                    else
                    {
                        string orderDate = customerOrderLines[0].Substring(13, 10);

                        for (int i = 0; i < customerInfoLineIds.Count; i++)
                        {
                            int tempItemLineCount = int.Parse(customerOrderLines[itemCountLineIds[i]].Substring(1, 3));
                            if (itemCountLineIds[i] - customerInfoLineIds[i] - 1 != tempItemLineCount)
                            {
                                writeLineToLog("Error: Item count mismatch in " + fileName);
                            }
                            else
                            {
                                string tempOrderNum = customerOrderLines[customerInfoLineIds[i]].Substring(1, 6);
                                int tempCustId = int.Parse(customerOrderLines[customerInfoLineIds[i]].Substring(7, 5));
                                string tempCustName = customerOrderLines[customerInfoLineIds[i]].Substring(12, 30);
                                string tempShipAddr = customerOrderLines[customerInfoLineIds[i]].Substring(42, 20);
                                string tempShipCity = customerOrderLines[customerInfoLineIds[i]].Substring(62, 20);
                                string tempShipState = customerOrderLines[customerInfoLineIds[i]].Substring(82, 2);
                                int tempZipCode = int.Parse(customerOrderLines[customerInfoLineIds[i]].Substring(84, 9));

                                // process above information in order table

                                for(int j = customerInfoLineIds[i] + 1; j < itemCountLineIds[i]; j++)
                                {
                                    // use a above variables in processing order-item relation
                                    int tempItemId = int.Parse(customerOrderLines[j].Substring(1, 5));
                                    int tempQuantity = int.Parse(customerOrderLines[j].Substring(6, 5));
                                    // use these variables in item-order relation, verify item exists, non-zero quantity
                                    // check if fulfillable, if not, add to backorder, make sure it's not a repeat
                                }
                            }
                        }

                        // iterate order sequence

                    }
                    
                }
            }

        }

        private void readVendorOrderFile()
        {
            string fileName = "vendororder.txt";
            string[] vendorOrderLines = { };

            try
            {
                vendorOrderLines = File.ReadAllLines(fileName);
            }
            catch (Exception e)
            {
                writeLineToLog("Error: " + fileName + " failed to open");
                continueBatch = false;
            }

            if (continueBatch)
            {
                if (vendorOrderLines.Length < 2)
                {
                    continueBatch = false;
                    writeLineToLog("Error: Header or Trailer missing in " + fileName);
                }
                else if (vendorOrderLines[0].Substring(0, 2) != "HD")
                {
                    continueBatch = false;
                    writeLineToLog("Error: Header is missing in " + fileName);
                }
                else if (vendorOrderLines.Last().Substring(0, 1) != "T")
                {
                    continueBatch = false;
                    writeLineToLog("Error: Trailer is missing in " + fileName);
                }
                else if (int.Parse(vendorOrderLines[0].Substring(3, 4)) != lastVendorShipSeq + 1)
                {
                    continueBatch = false;
                    writeLineToLog("Error: Invalid Sequence in " + fileName);
                }
                else if (int.Parse(vendorOrderLines.Last().Substring(2, 4)) != vendorOrderLines.Length - 2)
                {
                    writeLineToLog("Error: Row count mismatch in " + fileName);
                }
                else
                {
                    string vendorOrderDate = vendorOrderLines[0].Substring(13, 10);

                    for(int i = 1; i < vendorOrderLines.Length - 2; i++)
                    {
                        int tempVendorId = int.Parse(vendorOrderLines[i].Substring(0, 2));
                        int tempItemId = int.Parse(vendorOrderLines[i].Substring(2, 5));
                        int tempReorderQuantity = int.Parse(vendorOrderLines[i].Substring(7, 5));

                        //verify vendor, item, that vendor sells item, that quantity is nonzero, that reorder point was actually reached
                    }

                    // iterate sequence
                }

            }

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
