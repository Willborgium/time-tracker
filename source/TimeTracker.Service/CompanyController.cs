using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using TimeTracker.Core.Model;
using TimeTracker.Core.Repository;
using TimeTracker.Core.Service;
using TimeTracker.Data.Repository;
using TimeTracker.Service.Core.Model;
using TimeTracker.Service.Core.Service;

namespace TimeTracker.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CompanyController : ICompanyController
    {
        public WebResponse<string> Heartbeat(string message)
        {
            var output = new WebResponse<string>();

            try
            {
                output.Data = $"Okay! ({message})";
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse<Company> GetCompany(string id)
        {
            var output = new WebResponse<Company>();

            try
            {
                output.Data = CompanySvc.GetCompany(int.Parse(id));
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse<List<Company>> GetCompanies()
        {
            var output = new WebResponse<List<Company>>();

            try
            {
                output.Data = CompanySvc.GetCompanies().ToList();
            }
            catch (Exception err)
            {
                output.Data = null;

                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public void PreflightValidation()
        {
            HttpContext.Current.Response.StatusCode = 200;
        }

        public WebResponse AddCompany(Company company)
        {
            var output = new WebResponse();

            try
            {
                CompanySvc.AddCompany(company);
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public void PreflightValidation2(string id)
        {
            HttpContext.Current.Response.StatusCode = 200;
        }

        public WebResponse DeleteCompany(string id)
        {
            var output = new WebResponse();

            try
            {
                CompanySvc.DeleteCompany(int.Parse(id));
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }

        public WebResponse UpdateCompany(Company company)
        {
            var output = new WebResponse();

            try
            {
                CompanySvc.UpdateCompany(company);
            }
            catch (Exception err)
            {
                output.HasError = true;

                output.ErrorDetails = err.Message;
            }

            return output;
        }
        
        private ICompanyRepository CompanyRepo
        {
            get
            {
                if (_companyRepo == null)
                {
                    _companyRepo = new EntityCompanyRepository();
                }

                return _companyRepo;
            }
        }

        private ICompanyService CompanySvc
        {
            get
            {
                if (_companySvc == null)
                {
                    _companySvc = new CompanyService(CompanyRepo);
                }

                return _companySvc;
            }
        }

        private static ICompanyRepository _companyRepo;

        private static ICompanyService _companySvc;
    }
}