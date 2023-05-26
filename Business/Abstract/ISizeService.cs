using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISizeService
    {
        IDataResult<List<Size>> GetSize();
        IDataResult<Size> GetSizeID(int sizeId);
        IResult Add(Size size);
        IResult Delete(Size size);
        IResult Update(Size size);
        IResult AddSizesToProduct(int productId, ICollection<SizeDTO> sizeDTOs);
    }
}
