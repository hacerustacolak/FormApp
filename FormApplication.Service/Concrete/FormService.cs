using FormApplication.Core;
using FormApplication.Data.Contexts;
using FormApplication.Data.DomainClass;
using FormApplication.Service.Abstract;
using Microsoft.Data.SqlClient.Server;
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

        public bool Add(Forms forms)
        {
            try
            {
                _db.Forms.Add(forms);

                var result = _db.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

               
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool AddData(FormDetails formDetails)
        {
            try
            {
                _db.FormDetails.Add(formDetails);

                var result = _db.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<FormDto> GetAll()
        {
            List<FormDto> response = new List<FormDto>();
            try
            {
                var forms = _db.Forms.ToList();
                if (forms.Count > 0)
                {
                    foreach (var form in forms)
                    {
                        FormDto formDto = new FormDto();
                        formDto.Id = form.Id;
                        formDto.Name = form.Name;
                        formDto.Description = form.Description;
                        formDto.CreatedBy = _db.Users.Where(t => t.Id == form.CreatedBy).FirstOrDefault().Username;
                        formDto.CreatedAt = form.CreatedAt;

                        List<FormDetails> details = _db.FormDetails.Where(t => t.FormId == form.Id).ToList();
                        formDto.Fields = details;

                        response.Add(formDto);
                    }
                }

            }
            catch (Exception)
            {
                return response;
            }
            

            

            return response;

        }

        public List<FormDetails> GetById(int Id)
        {
            List<FormDetails> response = new List<FormDetails>();
            try
            {
                var formDetails = _db.FormDetails.Where(t=>t.FormId==Id).ToList();
                if (formDetails.Count > 0)
                {
                    foreach (var formDetail in formDetails)
                    { 
                        response.Add(formDetail);
                    }
                }

            }
            catch (Exception)
            {
                return response;
            }
             

            return response;
        }
    }
}
