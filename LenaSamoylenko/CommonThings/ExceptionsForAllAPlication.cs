using Microsoft.Extensions.Logging;
using System;


namespace CommonThings
{
    public class ExceptionsForAllAplication : IExeptionForFirstDemo
    {
        #region Fields

        private int aplicationNumber;
        private Exception _exception;
        private ILogger _logger;

        #endregion

        #region Constructors

        public ExceptionsForAllAplication(int aplicationNumber, ILogger logger)
        {
            this.aplicationNumber = aplicationNumber;
            _logger = logger;
        }

        #endregion

        #region Methods

        public void GetException(Exception exceptionFromTask)
        {
            _exception = exceptionFromTask;

            switch (aplicationNumber)
            {
                case 1:
                    _exception = Task1Exception(exceptionFromTask);
                    break;
                case 2:
                    _exception = Task2Exception(exceptionFromTask);
                    break;
                case 3:
                    _exception = Task3Exception(exceptionFromTask);
                    break;
                case 4:
                    _exception = Task4Exception(exceptionFromTask);
                    break;
                case 5:
                    _exception = Task5Exception(exceptionFromTask);
                    break;
                case 6:
                    _exception = Task6Exception(exceptionFromTask);
                    break;
                case 7:
                    _exception = Task7Exception(exceptionFromTask);
                    break;
                case 8:
                    _exception = Task8Exception(exceptionFromTask);
                    break;
                default:
                    break;
            }
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
            Exception finalException = null;

            if (exception is System.ArgumentOutOfRangeException)
            {
                _logger.LogError(exception, "throw System.ArgumentOutOfRangeException");
            }
            else if (exception is System.InvalidOperationException)
            {
                _logger.LogError(exception, "throw System.InvalidOperationException");
            }
            else if (exception is System.ArgumentNullException)
            {
                _logger.LogError(exception, "throw System.ArgumentNullException");
            }
            else if (exception is System.Security.SecurityException)
            {
                _logger.LogError(exception, "throw System.Security.SecurityException");
            }
            else if (exception is System.IO.FileNotFoundException)
            {
                _logger.LogError(exception, "throw System.IO.FileNotFoundException");
            }
            else if (exception is System.ArgumentException)
            {
                _logger.LogError(exception, "throw System.ArgumentException");
            }
            else if (exception is System.ObjectDisposedException)
            {
                _logger.LogError(exception, "throw System.ObjectDisposedException");
            }
            else if (exception is System.InvalidOperationException)
            {
                _logger.LogError(exception, "throw System.InvalidOperationException");
            }
            else
            {
                _logger.LogError(exception, "Just exception");
            }
            return finalException;
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

            if (exception is System.ArgumentOutOfRangeException)
            {
                _logger.LogError(exception, "throw System.ArgumentOutOfRangeException");
            }
            else if (exception is System.InvalidOperationException)
            {
                _logger.LogError(exception, "throw System.InvalidOperationException");
            }

            return task1Exception;
        }
        #endregion

        #endregion

    }
}
