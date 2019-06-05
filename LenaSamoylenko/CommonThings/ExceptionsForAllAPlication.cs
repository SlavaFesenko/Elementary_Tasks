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


        #region Methods

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
                case 3:
                    exception = Task3Exception(exceptionFromTask);
                    break;
                case 4:
                    exception = Task4Exception(exceptionFromTask);
                    break;
                case 5:
                    exception = Task5Exception(exceptionFromTask);
                    break;
                case 6:
                    exception = Task6Exception(exceptionFromTask);
                    break;
                case 7:
                    exception = Task7Exception(exceptionFromTask);
                    break;
                case 8:
                    exception = Task8Exception(exceptionFromTask);
                    break;
                default:
                    break;
            }

            return exception;
        }

        #region Task1
        private Exception Task1Exception(Exception exceptionFromTask)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Task2
        private Exception Task2Exception(Exception exceptionFromTask)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Task3
        private Exception Task3Exception(Exception exceptionFromTask)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Task4
        private Exception Task4Exception(Exception exception)
        {
            Exception task1Exception = null;

            if (exception is System.ArgumentOutOfRangeException)
            {

            }
            else if (exception is Exception)
            {

            }
            else
            {

            }
            return task1Exception;
        }
        #endregion

        #region Task5
        private Exception Task5Exception(Exception exceptionFromTask)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Task6
        private Exception Task6Exception(Exception exceptionFromTask)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Task7
        private Exception Task7Exception(Exception exceptionFromTask)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Task8
private Exception Task8Exception(Exception exception)
        {
            Exception task1Exception = null;


            return task1Exception;
        }
        #endregion

        #endregion


        

        


    }
}
