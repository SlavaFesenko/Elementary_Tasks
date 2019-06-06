using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonThings
{
    public sealed class InstructionReader
    {
        private static Logger _logger = null;

        public static string GiveInstruction(string filePath, Logger logger)
        {
            string instruction = null;
            _logger = logger;

            InstructionReader.ReadFromFile(filePath, out instruction);

            return instruction;
        }

        public static bool ReadFromFile(string filePath, out string instruction)
        {
            instruction = null;
            bool operationIsSucces = false;
         
            try
            {
                StreamReader reader = new StreamReader(filePath);
                instruction = reader.ReadToEnd();
                operationIsSucces = true;
            }
            catch (Exception exeption)
            {
                _logger.Error(exeption);
            }

            return operationIsSucces;
        }

        public static bool IsCouldGetText(string link, out string text)
        {
            text = null;
            bool operationIsSucces = false;

            try
            {
                StreamReader reader = new StreamReader(link);
                text = reader.ReadToEnd();
                operationIsSucces = true;
                reader.Close();
            }
            catch (Exception exeption)
            {
                _logger.Error(exeption);

            }

            return operationIsSucces;
        }

        public static bool IsCouldGetText(string link, out string text, out Encoding encoding)
        {
            text = null;
            encoding = null;
            bool operationIsSucces = false;

            try
            {
                using (StreamReader reader = new StreamReader(link))
                {
                    text = reader.ReadToEnd();
                    operationIsSucces = true;
                    encoding = reader.CurrentEncoding;
                    reader.Close();
                }
            }
            catch (Exception exeption)
            {
                _logger.Error(exeption);

            }

            return operationIsSucces;
        }

        public static string GetFilePath()
        {
            string _path = null;
            var _info = new DirectoryInfo(Directory.GetCurrentDirectory());

            for (int i = 0; i <= 2; i++)
            {
                _info = _info.Parent;
            }

            _path = _info.FullName;
            _path = String.Concat(_path, Path.DirectorySeparatorChar, "Instruction.txt");

            return _path;
        }
    }
}
