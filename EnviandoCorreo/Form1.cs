using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace EnviandoCorreo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool correo(string cuerpo, string asunto)
        {
            bool r= false;


            MailMessage msj = new MailMessage();
            msj.To.Add("roymartinez94@gmail.com");
            msj.Subject = asunto;
            msj.SubjectEncoding = Encoding.UTF8;
            msj.Body = cuerpo;
            msj.BodyEncoding = Encoding.UTF8;
            msj.IsBodyHtml = false;
            msj.From = new MailAddress("pruebarmartinez@gmail.com");


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("pruebarmartinez@gmail.com", "pruebatda");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Timeout = 300000;
            
            ServicePointManager.ServerCertificateValidationCallback =
                  (s, certificate, chai, sslPolicyErrors) => true;
            //ServicePointManager.ServerCertificateValidationCallback =
            //delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            try
            {
                smtp.Send(msj);
                r = true;
            }
            catch (Exception ex)
            {
                r = false;
                MessageBox.Show(ex.Message);
                throw;
            }
            return r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmail();

        }

        //////////////////////////////
        public static string SendEmail()
        {
            // CONSTRUCCIÓN DEL CUERPO DEL MENSAJE
            //var msg = new MailMessage
            //{
            //    From = new MailAddress("pruebarmartinez@gmail.com"),
            //    Subject = "Prueba",
            //    IsBodyHtml = false,
            //    Body = "Este es el primer correo de prueba en the data age"
            //};

            //msg.To.Add(new MailAddress("roymartinez94@gmail.com"));

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress("roymartinez94@gmail.com"));
            msg.From = new MailAddress("pruebarmartinez@gmail.com");
            msg.Subject = "Asunto(Correo Prueba)";
            msg.Body = "Contenido Prueba";
            msg.IsBodyHtml = false;
            msg.Priority = MailPriority.Normal;



            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 465;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("pruebarmartinez@gmail.com", "pruebatda");



            // CONSTRUCCIÓN DEL CONEXION AL SERVIDOR SMTP
            //var smtpClient = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 465,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential("pruebarmartinez@gmail.com", "pruebatda"),
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    EnableSsl = false,
            //    Timeout = 300000
            //};

            ServicePointManager.ServerCertificateValidationCallback =
                      (s, certificate, chai, sslPolicyErrors) => true;

            //Envio del correo
            try
            {
                //Envio del correo
                smtpClient.Send(msg);
                return "OK";
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            finally
            {
                msg.Dispose();
                smtpClient.Dispose();
                
            }
             return "SCFE";
            
        }



    }
}
