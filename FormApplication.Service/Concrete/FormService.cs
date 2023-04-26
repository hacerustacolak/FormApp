using FormApplication.Core;
using FormApplication.Data.Contexts;
using FormApplication.Data.DomainClass;
using FormApplication.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormApplication.Service.Concrete
{
    public class FormService : IFormService
    {
        private readonly FormApplicationContext _db;

        public FormService(FormApplicationContext db)
        {
            _db = db;
        }

        public List<FormDto> GetAll()
        {
            List<FormDto> response = new List<FormDto>();

            var forms = _db.Forms.ToList();
            if (forms.Count > 0)
            {
                foreach (var form in forms)
                {
                    FormDto formDto = new FormDto();
                    formDto.Id = form.Id;
                    formDto.Name = form.Name;
                    formDto.Description = form.Description;
                    formDto.CreatedBy = form.CreatedBy;
                    formDto.CreatedAt = form.CreatedAt;

                    List<FormDetails> details = _db.FormDetails.Where(t => t.FormId == form.Id).ToList();
                    formDto.Fields = details;

                    response.Add(formDto);
                } 
            }

            return response;

        }
    }
}
