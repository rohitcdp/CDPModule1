using CDPModule1.Shared;
using Org.BouncyCastle.Ocsp;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace CDPModule1.Client.dynamicInvoice
{
    public class GenerateDynamicInvoice
    {
        private List<List<string>> data { get; set; }

        private DynamicProps dynamicProps;
        public GenerateDynamicInvoice(List<List<string>> _data)
        {
            data = _data;
            dynamicProps = new DynamicProps();
            props();
            string x = "test";
        }
        public async void props()
        {
            //expression for gst
            var regGST = new Regex(@"^([0][1-9]|[1-2][0-9]|[3][0-7])([a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1})+$");
            var regPAN = new Regex(@"[A-Z]{5}[0-9]{4}[A-Z]{1}");

            bool breakLoopForAddress = false;
            bool breakLoopForGST = false;
            bool breakLoopForPAN = false;
            bool breakLoopForName = false;
            bool breakLoopForInvoice = false;
            bool InvoiceContinue = false;

            try
            {
                bool isHeading = false;
                List<string>? tableHeading = null;
                List<Dictionary<string, string>> dataTable = new List<Dictionary<string, string>>();


                foreach (List<string> collection in data)
                {
                    #region Table data
                    Dictionary<string, string> keyValue = new Dictionary<string, string>();

                    //if (collection.Count == 7 && !isHeading)
                    //{
                    //    isHeading = true;
                    //    tableHeading = collection;
                    //}


                    //if (collection.Count == 7 && isHeading)
                    if (isHeading)
                    {
                        for (int i = 0; i < tableHeading.Count; i++)
                        {
                            if (tableHeading.Count <= collection.Count)
                            {
                                if (tableHeading[i] != collection[i])
                                {
                                    //if (tableHeading[i].Trim()==string.Empty)
                                    //{
                                    //    tableHeading[i] = i.ToString();
                                    //}


                                    keyValue.Add(tableHeading[i], collection[i]);

                                }
                                else
                                {
                                    isHeading = false;
                                    break;
                                }
                            }


                        }
                        dataTable.Add(keyValue);
                    }
                    #endregion

                    foreach (string item in collection)
                    {

                        #region Purifying Data
                        string theData = item.ToLower();

                        theData = theData.Trim();
                        theData = theData.Replace("\"", "");
                        theData = theData.Replace("'", "");

                        //continuing if no data available
                        if (theData.Trim() == string.Empty)
                        {
                            continue;
                        }

                        #endregion



                        #region Address
                        if (!breakLoopForAddress && theData.Contains(","))
                        {
                            string addr = theData;

                            if (theData.Contains(":") || theData.ToLower().Contains("address"))
                            {
                                addr = theData.Split(":")[1].ToString().Trim();
                            }

                            dynamicProps.Address = addr;
                            breakLoopForAddress = true;
                            break;

                        }
                        #endregion

                        #region CompanyName
                        if (!breakLoopForName && (theData.Contains("ltd") || theData.Contains("limited")))
                        {
                            dynamicProps.CompanyName = theData;
                            breakLoopForName = true;
                            break;
                        }


                        #endregion


                        #region GST
                        if (!breakLoopForGST)
                        {
                            string gstin = theData.Trim();

                            if (gstin.ToLower().Contains("gst"))
                            {
                                string[] splits = gstin.Split(":");

                                if (splits.Length > 1)
                                {
                                    gstin = splits[1];

                                }

                                //gstin = gstin.Split(":")[1].ToString().Trim();
                            }

                            if (regGST.IsMatch(gstin))
                            {
                                dynamicProps.GST = gstin;
                                breakLoopForGST = true;
                                break;
                            }


                        }
                        #endregion

                        #region PAN
                        if (!breakLoopForPAN)
                        {
                            string pan = theData.Trim();

                            if (pan.ToLower().Contains("pan") || pan.ToLower().Contains(":"))
                            {
                                string[] splits = pan.Split(":");

                                if (splits.Length > 1)
                                {
                                    pan = splits[1];

                                }
                            }

                            if (regPAN.IsMatch(pan))
                            {
                                dynamicProps.PAN = pan;
                                breakLoopForPAN = true;
                                break;
                            }


                        }
                        #endregion


                        #region Invoice number

                        //if (InvoiceContinue)
                        //{
                        //    dynamicProps.InvoiceNumber = theData.Trim();
                        //    breakLoopForInvoice = true;
                        //    InvoiceContinue = false;
                        //    break;
                        //}


                        //if (!breakLoopForInvoice)
                        //{
                        //    string invoice = theData.Trim();

                        //    if (invoice.ToLower().Contains("invoice"))
                        //    {
                        //        if (invoice.ToLower().Contains(":"))
                        //        {
                        //            invoice = invoice.Split(":")[1].ToString().Trim();
                        //        }


                        //        if (invoice.Trim() == "")
                        //        {
                        //            InvoiceContinue = true;
                        //            continue;

                        //        }
                        //        else
                        //        {
                        //            dynamicProps.InvoiceNumber = invoice;
                        //            breakLoopForInvoice = true;
                        //            break;
                        //        }
                        //    }




                        //}


                        #endregion


                        #region table data
                        if (!isHeading && (item.ToLower().Contains("program") || item.ToLower().Contains("amount") || item.ToLower().Contains("programme")))
                        {
                            isHeading = true;
                            tableHeading = collection;
                            //checking if headings are the same
                            try
                            {
                                for (int i = 0; i < tableHeading.Count; i++)
                                {
                                    for (int j = 0; j < tableHeading.Count; j++)
                                    {
                                        if (tableHeading[i] == tableHeading[j])
                                        {
                                            tableHeading[i] = tableHeading[i] + i.ToString();
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {

                                throw;
                            }

                            break;

                        }
                        #endregion
                    }

                    if (breakLoopForAddress && breakLoopForGST && breakLoopForPAN)
                    {
                        break;
                    }

                }
                Console.WriteLine(dataTable.Count);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public DynamicProps GetGeneratedProps()
        {
            return dynamicProps;
        }
    }
}
