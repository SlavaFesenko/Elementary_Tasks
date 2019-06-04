using System;

public interface IExeptionForFirstDemo
{
    Exception getLastException { get; }
    Exception GetException(Exception exceptionFromTask);
}
