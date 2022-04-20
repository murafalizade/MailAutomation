using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.GoogleSheetService
{
    class GoogleSheetAPIHelper
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "MailBot2";
        static public IList<IList<Object>> GetData()
        {
            GoogleCredential credential;
            using (var stream =new FileStream("credentials.json",
                FileMode.Open, FileAccess.Read)){
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            String spreadsheetId = "1Z_f1UNhNrOhYddiVehyMa_mHiROHXvHn5ebwXlHGSmI";
            String range = "My typeform";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                return values;
            }
            else
            {
                return null;
            }
        }
    }
}
