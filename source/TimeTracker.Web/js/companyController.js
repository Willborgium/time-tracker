var companyController = (function () {
    function companyController(urlBase, errorHandler) {
        this._urlBase = urlBase;
        this._errorHandler = errorHandler;
    }

    function handleSuccess(data, onSuccess){
        if (data.HasError) {
            $('#error').text(data.ErrorDetails);
        } else {
            onSuccess(data.Data);
        }
    }

    companyController.prototype.loadCompanies = function (onLoad) {
        $.ajax({
            url: this._urlBase + 'company/',
            success: function(data){
                handleSuccess(data, onLoad);
            },
            error: this._errorHandler
        });
    }

    companyController.prototype.addCompany = function (company, onSuccess) {
        $.ajax({
            url: this._urlBase + 'company/',
            data: JSON.stringify(company),
            dataType: 'JSON',
            contentType: 'application/json',
            method: 'PUT',
            success: function (data) {
                handleSuccess(data, onSuccess);
            },
            error: this._errorHandler
        });
    }
    
    companyController.prototype.deleteCompany = function (companyId, onSuccess) {
        $.ajax({
            url: this._urlBase + 'company/' + companyId,
            contentType: 'application/json',
            method: 'DELETE',
            success: function (data) {
                handleSuccess(data, onSuccess);
            },
            error: this._errorHandler
        });
    }

    return companyController;
})();

_companyController = new companyController(_timeTrackerController.urlBase, _timeTrackerController.errorHandler);