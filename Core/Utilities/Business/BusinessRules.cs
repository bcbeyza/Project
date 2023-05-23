using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params verildiginde IResultın içerisine istedigimzi kadar IResult parametresi verebiliyoruz
        //logic is kurali demek
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;//ErrorResult donucek
                }
            }

            return null;//dogruysa bir sey dondormemize gerek yok
        }
    }
}
