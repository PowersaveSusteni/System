using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Susteni.Models.Mail
{
    public class MailModel
    {

        public MailItem Mail { get; set; }
        public EpostFoldersItem Folder { get; set; }
        public SendMailItems SendMail { get; set; }
        public MailAttatchmentItem MailAttatchment { get; set; }
        public MailModel()
        {
            Mail = new MailItem();
            Folder = new EpostFoldersItem();
            MailAttatchment = new MailAttatchmentItem();
            SendMail = new SendMailItems();
        }

    }
}
