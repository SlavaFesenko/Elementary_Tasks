using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextParser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run(args);
            }
            catch (FormatException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
            catch (ArgumentNullException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
            catch (ArgumentException e)
            {
                UserInterface.ShowErrorMessage(e);
            }
            catch(IOException e)
            {
                UserInterface.ShowErrorMessage(e);
            }

        }

        #region Methods

        public static void Run(string[] args)
        {
            Mode parserMode = Validator.Validate(args);
            Parser parser = new Parser(parserMode);
            parser.DoAlgorithm(args);
            UserInterface.Display(parser.Mode);
        }


       

        //public static void SaveToFile(string path, List<string> text)
        //{
        //    using (StreamWriter sw = new StreamWriter(path))
        //    {
        //        foreach (string line in text)
        //        {
        //            sw.WriteLine(line);
        //        }
        //    }

        //    Console.WriteLine("File was successfully saved!");
        //}

        #endregion
    }
}
