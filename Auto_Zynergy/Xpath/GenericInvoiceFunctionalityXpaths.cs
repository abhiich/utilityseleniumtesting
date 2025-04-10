using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Zynergy.Xpath
{
    class GenericInvoiceFunctionalityXpaths
    {
        //Dashboard Page Xpaths
        public string SearchMenuIcon = "//a[@title='Search Menu']";
        public string SearchInput = "//input[@id='search-menu-input-SearchText']";
        public string CustomersPage = "//span[text()='Customer Service > Customers']";
        public string BatchProcessPage = "//span[text()='System > Batch > Processes']";


        //Batch Process Page Xpaths
        public string DemodataSearch = "//input[@placeholder='Search processes']";
        public string DemoData = "//span[@title='Generate Demo Data']";
        public string ExecuteOption = "//a[@href='#batchprocessexecute']";

    }
}
