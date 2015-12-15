var TimeTrackerModule = (function () {
    function TimeTrackerModule(element) {
        this.element = element;
    }
    TimeTrackerModule.prototype.loadCompanies = function () {
        $.ajax({
            url: 'http://localhost:81/company/',
            success: function (data) {
                console.dir(data);
            },
            error: function (err) {
                console.dir(err);
            }
        });
    };
    return TimeTrackerModule;
})();
var TimeTrackerService = (function () {
    function TimeTrackerService(urlBase, errorHandler) {
        this._urlBase = urlBase;
        this._errorHandler = errorHandler;
    }
    TimeTrackerService.prototype.getCompanies = function (onLoad) {
        $.ajax({
            url: this._urlBase + 'company/',
            success: onLoad,
            error: this._errorHandler
        });
    };
    return TimeTrackerService;
})();
window.onload = function () {
    var tts = new TimeTrackerService('http://localhost:81/', function (err) {
        $('#error').text('An error has occurred.');
    });
    tts.getCompanies(function (data) {
        if (data.HasError) {
            $('#error').text(data.ErrorDetails);
        }
        else {
            for (var index = 0; index < data.Data.length; index++) {
                var company = data.Data[index];
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
                $('#companies').append(companyDiv);
            }
        }
    });
};
//# sourceMappingURL=app.js.map