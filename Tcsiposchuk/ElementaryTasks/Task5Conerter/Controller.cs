using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Conerter
{
    public class Controller : BaseController
    {

        public void Run(InputModel model)
        {
            Converter converter = new Converter(model.Number);
            string result = converter.String;
            UI.ShowConvert(converter.Number, result);
        }


    }
}
