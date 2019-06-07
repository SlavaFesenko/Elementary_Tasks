using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static interface IValidator
{
    static T Validate<T>(string[] args);
}
