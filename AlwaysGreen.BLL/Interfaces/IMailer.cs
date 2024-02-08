using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.BLL.Interfaces
{
    public interface IMailer
    {
        void Send(string to, string subject, string html, params Attachment[] attachments);
    }
}
