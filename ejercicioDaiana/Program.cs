using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ejercicioDaiana
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string fila;

            // Leo el archivo TestDaiana.txt 
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\54934\Desktop\Daiana\EjercicioFantommer\TestDaiana.txt");
            CultureInfo culture = new CultureInfo("en-US");
            char[] delimiterChars = { ',' };

            while ((fila = file.ReadLine()) != null)
            {
                Boolean estado = false;
                string[] campos = fila.Split(delimiterChars);
                //Nombre - Dni - Altura - Estado
                if (campos[3] == " ACTIVO")
                {
                    estado = true;
                }
                decimal altura = 0;
                altura= decimal.Parse(campos[2], culture);
                using (Models.DBContainer db = new Models.DBContainer())
                {
                    var oPerson = new Models.Persona();
                    oPerson.DNI = campos[1];
                    oPerson.Nombre = campos[0];
                    oPerson.Altura = altura;
                    oPerson.Estado = estado;
                    db.Personas.Add(oPerson);

                    db.SaveChanges();
                }
                System.Console.WriteLine(decimal.Parse(campos[2], culture));
                System.Console.WriteLine(estado);
            }
            file.Close();
            //System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();

        }
    }
}
