using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public interface IEmailSenderService
    {
        public Task SendEmailAsync(Message message);
    }
}
