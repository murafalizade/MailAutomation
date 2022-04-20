using Mailer.GoogleSheetService;
using Mailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Controllers
{
    class GoogleSheetController
    {
        public static async Task AddEmailFromAPI()
        {
            List<MailModel> obj = GoogleSheetAPIMapper.MapperFromService();
            await DatabaseController.AddAllEmails(obj);
        }
    }
}
