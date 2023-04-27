using FormApplication.Core;
using FormApplication.Data.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormApplication.Service.Abstract
{
    public interface IFormService
    {
        List<FormDto> GetAll();
        List<FormDetails> GetById(int Id);
        bool Add(Forms forms);
        bool AddData(FormDetails formDetails);
    }
}
