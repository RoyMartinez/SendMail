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
        private void button1_Click(object sender, EventArgs e)
        {
            //correo("prueba de correo de envio", "Asunto de Prueba");
            //SendEmail();
            EnviarCorreo("ijimenez@thedataage.com", "Alerta de Error en LLenado", "Ha ocurrido un error de llenado favor enviar su pin  y numero de tarjeta de debito");
            //EnviarCorreo("evaldivia@thedataage.com", "aniting", "body de aniting");

        }





        //////////////////////////////
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
            smtp.Port = 465;
            smtp.EnableSsl = true;
            smtp.Timeout = 300000;
            
            //ServicePointManager.ServerCertificateValidationCallback =
            //      (s, certificate, chai, sslPolicyErrors) => true;
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





        //////////////////////////////
        public static string SendEmail()
        {
            // CONSTRUCCIÓN DEL CUERPO DEL MENSAJE
            var msg = new MailMessage
            {
                From = new MailAddress("pruebarmartinez@gmail.com"),
                Subject = "Prueba",
                IsBodyHtml = false,
                Body = "Este es el primer correo de prueba en the data age"
            };

            msg.To.Add(new MailAddress("roymartinez94@gmail.com"));

            //CONSTRUCCIÓN DEL CONEXION AL SERVIDOR SMTP
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 465,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("pruebarmartinez@gmail.com", "pruebatda"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = false,
                Timeout = 300000
            };

            //ServicePointManager.ServerCertificateValidationCallback =
            //          (s, certificate, chai, sslPolicyErrors) => true;

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






        //////////////////////////////
        public static string EnviarCorreo(string destinatario, string asunto, string cuerpo,
               List<AlternateView> vistas = null)
        {
            try
            {

                var m = new MailMessage(new MailAddress("pruebarmartinez@gmail.com", "pruebatda"),
                    new MailAddress(destinatario))
                {
                    Subject = asunto,
                    Body = cuerpo,
                    IsBodyHtml = true
                };
                if (vistas != null)
                {
                    foreach (var item in vistas)
                    {
                        m.AlternateViews.Add(item);
                    }
                }
                var smtp = new SmtpClient("smtp.gmail.com")
                {
                    Credentials = new NetworkCredential("pruebarmartinez@gmail.com", "pruebatda"),
                    EnableSsl = true,
                    Port = 587
                };
                smtp.Send(m);
                return string.Empty;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

    }
}
