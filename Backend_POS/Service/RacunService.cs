using Backend_POS.Data;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Stavke_Racuna;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Backend_POS.Service
{
    public class RacunService
    {
        private readonly DataContext _context;

        public RacunService(DataContext context)
        {
            _context = context;
        }

        // Metoda za dohvaæanje e-raèuna prema Id-u
        public ZaglavljeRacuna GetERacunById(int zaglavljeId)
        {
            return _context.ZaglavljeRacuna
                .FirstOrDefault(z => z.ZaglavljeId == zaglavljeId);
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool SendERacunEmail(string email, string xmlRacun)
        {
            try
            {
                Console.WriteLine("Poèetak slanja emaila...");

                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential("vilipavo12@gmail.com", "busmjtilsscnduqg");
                    client.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("vilipavo12@gmail.com"),
                        Subject = "E-Raèun",
                        Body = "U privitku se nalazi vaš e-raèun."
                    };
                    mailMessage.To.Add(email);

                    // Dodavanje XML datoteke kao privitka
                    mailMessage.Attachments.Add(new Attachment(new MemoryStream(Encoding.UTF8.GetBytes(xmlRacun)), "eRacun.xml"));

                    Console.WriteLine("Slanje emaila...");
                    client.Send(mailMessage);
                }

                Console.WriteLine("Email uspješno poslan.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška prilikom slanja emaila: {ex.Message}");
                return false;
            }
        }


        /*public bool SendERacunEmail(string email, string xmlRacun)
        {
            try
            {
                // Configure email client
                SmtpClient client = new SmtpClient("smtp.gmail.com", 465); 
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("vilipavo12@gmail.com", "busmjtilsscnduqg");
                client.EnableSsl = true;  // Omoguæi SSL/TLS

                // Email message setup
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("vilipavo12@gmail.com");
                mailMessage.To.Add(email);
                mailMessage.Subject = "E-Raèun";
                mailMessage.Body = "U privitku se nalazi vaš e-raèun.";

                // Attach the generated XML as an attachment
                mailMessage.Attachments.Add(new Attachment(
                    new MemoryStream(Encoding.UTF8.GetBytes(xmlRacun)), "eRacun.xml"));

                // Send the email
                client.Send(mailMessage);

                Console.WriteLine("Email poslan uspješno."); // Log za provjeru

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška prilikom slanja emaila: {ex.Message}"); // Dodaj ispis greške
                return false;
            }
        }*/




        // Metoda za generiranje XML-a za e-raèun
        public string GenerateERacunXml(int zaglavljeId)
        {
            var zaglavlje = _context.ZaglavljeRacuna
                .Include(z => z.StavkeRacunas)
                .ThenInclude(s => s.Proizvod)
                .Include(z => z.Kupac)
                .FirstOrDefault(z => z.ZaglavljeId == zaglavljeId);

            if (zaglavlje == null)
            {
                throw new Exception("Zaglavlje raèuna nije pronaðeno.");
            }

            // Kreiranje XML strukture
            var xmlDoc = new XDocument(
                new XElement("Racun",
                    new XElement("BrojRacuna", zaglavlje.Broj),
                    new XElement("Datum", zaglavlje.Datum.ToString("yyyy-MM-dd")),
                    new XElement("Kupac",
                        new XElement("Naziv", zaglavlje.Kupac.NazivKupac),
                        new XElement("Adresa", zaglavlje.Kupac.Adresa),
                        new XElement("Mjesto", zaglavlje.Kupac.Mjesto)
                    ),
                    new XElement("Stavke",
                        from stavka in zaglavlje.StavkeRacunas
                        select new XElement("Stavka",
                            new XElement("Kolicina", stavka.Kolicina),
                            new XElement("CijenaStavka", stavka.CijenaStavka),
                            new XElement("Popust", stavka.Popust),
                            new XElement("IznosPopusta", stavka.IznosPopusta),
                            new XElement("Vrijednost", stavka.Vrijednost)
                        )
                    ),
                    new XElement("Ukupno", zaglavlje.StavkeRacunas.Sum(s => s.Vrijednost - s.IznosPopusta))
                )
            );

            // Potpisivanje XML-a
            string signedXml = SignERacunXml(xmlDoc.ToString());

            // Povrat potpisanog XML-a
            return signedXml;
        }

        // Metoda za spremanje e-raèuna u bazu podataka
        public void SaveERacunToDatabase(int zaglavljeId)
        {
            var zaglavlje = _context.ZaglavljeRacuna
                .Include(z => z.StavkeRacunas)
                .FirstOrDefault(z => z.ZaglavljeId == zaglavljeId);

            if (zaglavlje != null)
            {
                // Generiranje XML-a
                string xmlRacun = GenerateERacunXml(zaglavljeId);

                // Spremanje XML-a u bazu
                zaglavlje.XmlRacun = xmlRacun;
                _context.SaveChanges();
            }
        }

        // Metoda za potpisivanje XML-a
        public string SignERacunXml(string xmlRacun)
        {
            // Dohvati certifikat iz Windows Certificate Store-a pomoæu Thumbprint-a
            X509Certificate2 cert = GetCertificateFromStore("a7d47a4ee1d500001abdd7582bc52d9f68b2f3b6");

            // Uèitaj XML dokument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlRacun);

            // Kreiraj objekt za potpisivanje
            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = cert.GetRSAPrivateKey();

            // Referenca na korijenski element
            Reference reference = new Reference();
            reference.Uri = "";

            // Dodaj referencu u potpis
            signedXml.AddReference(reference);

            // Dodaj certifikat
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(cert));
            signedXml.KeyInfo = keyInfo;

            // Kreiraj potpis
            signedXml.ComputeSignature();

            // Dodaj potpis u XML dokument
            XmlElement xmlSignature = signedXml.GetXml();
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlSignature, true));

            return xmlDoc.OuterXml;
        }

        // Metoda za dohvaæanje certifikata iz Windows Certificate Store-a pomoæu Thumbprint-a
        public X509Certificate2 GetCertificateFromStore(string thumbprint)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certCollection = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

            if (certCollection.Count > 0)
            {
                X509Certificate2 cert = certCollection[0];
                store.Close();
                return cert;
            }
            else
            {
                store.Close();
                throw new Exception("Certifikat nije pronaðen.");
            }
        }
    }
}
