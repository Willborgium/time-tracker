﻿using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using TimeTracker.Core.Model;
using TimeTracker.Service.Core.Model;

namespace TimeTracker.Service.Core.Service
{
    [ServiceContract(Namespace = "company")]
    public interface ICompanyController
    {
        [WebGet(UriTemplate = "beep/{message}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<string> Heartbeat(string message);

        [WebGet(UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<Company> GetCompany(string id);

        [WebGet(UriTemplate = "", ResponseFormat = WebMessageFormat.Json)]
        WebResponse<List<Company>> GetCompanies();

        [WebInvoke(UriTemplate = "", ResponseFormat = WebMessageFormat.Json, Method = "PUT")]
        WebResponse AddCompany(Company company);

        [WebInvoke(UriTemplate = "", ResponseFormat = WebMessageFormat.Json, Method = "OPTIONS")]
        void PreflightValidation();

        [WebInvoke(UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, Method = "OPTIONS")]
        void PreflightValidation2(string id);

        [WebInvoke(UriTemplate = "{id}", ResponseFormat = WebMessageFormat.Json, Method = "DELETE")]
        WebResponse DeleteCompany(string id);

        [WebInvoke(UriTemplate = "", ResponseFormat = WebMessageFormat.Json, Method = "PATCH")]
        WebResponse UpdateCompany(Company company);
    }
}