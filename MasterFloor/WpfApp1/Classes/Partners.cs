using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Data
{
    public partial class Partners
    {
        public string TypeAndTitle => TypePartners + " | " + Title;

        public string SalePartner => GetCountSale().ToString() + "%";

        private int GetCountSale()
        {
            int countSale = (int)Core.GetContext().PartnerProducts.Where(x => x.PartnerID == this.ID).Select(x => x.CountProduct).ToList().Sum();
            if (countSale < 10000)//расчет скидки по ТЗ 
            {
                return 0;
            }
            if (countSale > 10000 && countSale < 49999)
            {
                return 5;
            }
            if (countSale > 50000 && countSale < 300000)
            {
                return 10;
            }
            return 15;
        }
    }
}
