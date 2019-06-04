using System;
using System.Collections.Generic;
using System.Text;

namespace CommonThings
{
    public class ExceptionsForAllAplication : IExeptionForFirstDemo
    {
        #region Fields

        private int aplicationNumber;
        private Exception exception;

        #endregion

        #region Constructors

        public ExceptionsForAllAplication(int aplicationNumber)
        {
            this.aplicationNumber = aplicationNumber;
        }

        #endregion

        #region Enums

        public enum Tasks
        {
            Task1_ChessBoard = 1,
            Task2_EnvelopesAnalizer = 2,
            Task3_TriangleSorting = 3,
            Task4_ParserForFiles = 4,
            Task5_NumberIntoString = 5,
            Task6_ = 6,
            Task7_NumbersOrder = 7,
            Task8_FibonacciOrder = 8
        }

        #endregion

        #region Properties

        public Exception getLastException { get { return this.exception; } }

        #endregion


        #region PublicMethods

        public Exception GetException(Exception exceptionFromTask)
        {

            switch (aplicationNumber)
            {
                case 1:
                    exception = Task1Exception(exceptionFromTask);
                    break;
                case 2:
                    exception = Task2Exception(exceptionFromTask);
                    break;
                default:
                    break;
            }

            return exception;
        }

        #endregion

        #region PrivateMethods

        private Exception Task1Exception(Exception exception)
        {
            Exception task1Exception = null;

            return task1Exception;
        }

        private Exception Task2Exception(Exception exception)
        {
            Exception task1Exception = null;

            return task1Exception;
        }

        #endregion


    }
}
