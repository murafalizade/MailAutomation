using Mailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.GoogleSheetService
{
    class GoogleSheetAPIMapper
    {
        public static List<MailModel> MapperFromService()
        {
            var items = new List<MailModel>();
            IList<IList<Object>> obj = GoogleSheetAPIHelper.GetData();
            obj.RemoveAt(0);
            foreach(var item in obj)
            {
                Console.WriteLine(item[2]);
                MailModel mailModel = new MailModel() { FullName=item[0].ToString(),
                Email=item[2].ToString()};
                items.Add(mailModel);
            }
            return items;
        }
    }
}
