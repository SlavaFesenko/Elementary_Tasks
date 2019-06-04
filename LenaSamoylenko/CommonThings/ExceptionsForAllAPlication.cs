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
