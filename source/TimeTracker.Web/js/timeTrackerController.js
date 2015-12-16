var timeTrackerController = (function () {
    function timeTrackerController() {
        this.urlBase = 'http://localhost:81/';
    }

    function refreshCompaniesInternal() {
        $('#companies').empty();
        _companyController.loadCompanies(_timeTrackerController.displayCompanies);
    }

    function onAddCompany() {
        var companyNameElement = $('#newCompanyName');
        var companyName = companyNameElement.val();

        if (companyName.length > 0) {
            companyNameElement.val('');
            _companyController.addCompany({
                Name: companyName
            }, refreshCompaniesInternal);
        }
    }

    function onDeleteCompany(companyId) {
        _companyController.deleteCompany(companyId, refreshCompaniesInternal);
    }

    timeTrackerController.prototype.refreshCompanies = function () {
        refreshCompaniesInternal();
    }

    timeTrackerController.prototype.errorHandler = function () {
        $('#error').text('An error has occurred.');
    }

    timeTrackerController.prototype.displayCompanies = function (companies) {
        var newCompanyContainer = $('<div>', {
            id: 'newCompany',
            class: 'companyContainer'
        });
        newCompanyContainer.append($('<input>', {
            id: 'newCompanyName',
            class: 'companyName'
        }));
        var addNewCompanyButton = $('<input>', {
            class: 'addNewCompany',
            type: 'button',
            value: 'Add'
        });
        addNewCompanyButton.click(onAddCompany);

        newCompanyContainer.append(addNewCompanyButton);
        var companiesContainer = $('#companies');
        companiesContainer.append(newCompanyContainer);

        for (var index = 0; index < companies.length; index++) {
            var company = companies[index];
            var companyDiv = $('<div>', {
                id: 'company_' + company.Id,
                class: 'companyContainer'
            });
            companyDiv.append($('<div>', {
                text: company.Id,
                class: 'companyId'
            }));
            companyDiv.append($('<div>', {
                text: company.Name,
                class: 'companyName'
            }));
            var deleteCompany = $('<input>', {
                type: 'button',
                value: 'Delete',
                class: 'companyDelete'
            });

            deleteCompany.click((function (companyId) {
                return function () {
                    onDeleteCompany(companyId);
                }
            })(company.Id));
            companyDiv.append(deleteCompany);

            companiesContainer.append(companyDiv);
        }
    }

    return timeTrackerController;
})();

_timeTrackerController = new timeTrackerController();