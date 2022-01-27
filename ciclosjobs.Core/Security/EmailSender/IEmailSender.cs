using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.Security.EmailSender
{
    public interface IEmailSender
    {
        void Send(string emailDestino,string code);
        void SendEmail(string emailalumno, string nombreEmpresa, string tituloOferta, string mensaje);
    }
}
