using Backend_POS.Data;
using Backend_POS.Models.DbSet;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
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

        public ZaglavljeRacuna GetERacunById(int zaglavljeId)
        {
            // Dohvati zaglavlje raèuna s generiranim XML-om
            return _context.ZaglavljeRacuna
                .FirstOrDefault(z => z.ZaglavljeId == zaglavljeId);
        }

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

            // Kreiraj XML strukturu
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
                            new XElement("Proizvod", stavka.NazivProizvod),
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

            // Potpiši XML
            string signedXml = SignERacunXml(xmlDoc.ToString());

            // Vrati potpisani XML
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
                // Generiraj XML
                string xmlRacun = GenerateERacunXml(zaglavljeId);

                // Spremi XML u bazu
                zaglavlje.XmlRacun = xmlRacun;
                _context.SaveChanges();
            }
        }

        // Metoda za potpisivanje XML-a
        public string SignERacunXml(string xmlRacun)
        {
            // Uèitaj X.509 certifikat (ovdje se koristi lokalni certifikat za potpisivanje)
            X509Certificate2 cert = new X509Certificate2("path_to_your_certificate.pfx", "your_password");

            // Uèitaj XML dokument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlRacun);

            // Kreiraj objekt za potpisivanje
            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = cert.GetRSAPrivateKey();  // Koristi GetRSAPrivateKey za zastarjelu metodu

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
    }
}
