using FormApplication.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormApplication.Service.Abstract
{
    public interface IFormService
    {
        List<FormDto> GetAll();
    }
}
