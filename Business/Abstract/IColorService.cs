
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Entities.Concrete.Color;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetColors();
        IDataResult<Color> GetColorID(int colorID);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult UpDate(Color color);

    }
}
