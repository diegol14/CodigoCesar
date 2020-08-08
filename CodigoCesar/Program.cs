using System;

namespace CodigoCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto;
            uint num_desplazamiento;

            // Pedimos al usuario el texto a codificar y el num_desplazamiento 
            Console.WriteLine("Introduzca texto a codificar y pulsa enter");
            texto = Console.ReadLine();
            bool notOk;
            do
            {
                notOk = true;
                Console.WriteLine("Introduce número de desplazamiento entre 1 y 1000 y pulsa enter");
                string predesplazamiento = Console.ReadLine();

                try
                {
                    num_desplazamiento = Convert.ToUInt32(predesplazamiento);
                }
                                
                catch (Exception e)
                {
                    Console.WriteLine("No has introducido un número correcto,por ahora es cero");
                    num_desplazamiento = 0; //Esto es simplemente para que el parámetro num_desplazamiento del método tenga siempre un valor, se puede resolver de otras maneras
                    notOk = false;
                }

                if (num_desplazamiento > 1000)
                {
                    reinicia();
                }
            }
            while (notOk == false);


            string textoCodificado = Program.CodigoCesar(texto, num_desplazamiento);//Program no es necesario ya que estamos dentro de la clase
           
            Console.WriteLine("El texto codificado es :" + textoCodificado);
            Console.WriteLine("Pulsa cualquier tecla para terminar");
            Console.ReadKey();
        }

        // Creamos método para codificar palabras,creando un array de char para convertir cada letra y volvemos a reconstruir el string
        static string CodigoCesar(string str, uint num)
        {

            char[] textoChar = str.ToCharArray();
            //Console.WriteLine(textoChar); Esta es una impresión de prueba de programa , no es necesaria 
          
            for (int i = 0; i < str.Length; i++)
            {
                uint ascii_charOriginal = Convert.ToUInt32(textoChar[i]);
                // Console.WriteLine(ascii_charOriginal);  Esta es una impresión de prueba de programa , no es necesaria
                if (ascii_charOriginal < 32 || ascii_charOriginal > 122)
                {
                    Console.WriteLine($"No has ingresado un caracter correcto en el lugar {(i) + 1}, ");
                    reinicia();
                }
                if (num > 91) num %= 91;
                uint ascii_charFinal = ascii_charOriginal + num;
                if (ascii_charFinal > 122) ascii_charFinal = (ascii_charFinal - 122 + 31);

                textoChar[i] = Convert.ToChar(ascii_charFinal);
            }
            string textoFinal = new string(textoChar);
            return
                 textoFinal;
        }

         static void reinicia()
        {
            Console.WriteLine("Reinicia el codificador \nPulsa cualquier tecla para terminar");
            Console.ReadKey();
            Environment.Exit(-1);      
        }
    }
}
