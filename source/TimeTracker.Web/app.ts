class TimeTrackerModule {
    element: HTMLElement;
    span: HTMLElement;
    timerToken: number;

    constructor(element: HTMLElement) {
        this.element = element;
    }

    loadCompanies() {
        $.ajax({
            url: 'http://localhost:81/company/',
            success: function (data) {
                console.dir(data);
            },
            error: function (err) {
                console.dir(err);
            }
        });
    }
}

class TimeTrackerService {
    _urlBase: string;
    _errorHandler: Function;

    constructor(urlBase: string, errorHandler: Function) {
        this._urlBase = urlBase;
        this._errorHandler = errorHandler;
    }

    getCompanies(onLoad: Function) {
        $.ajax({
            url: this._urlBase + 'company/',
            success: onLoad,
            error: this._errorHandler
        });
    }
}

window.onload = () => {
    var tts = new TimeTrackerService('http://localhost:81/', function (err) {
        $('#error').text('An error has occurred.');
    });

    tts.getCompanies(function (data) {
        if (data.HasError) {
            $('#error').text(data.ErrorDetails);
        } else {
            for (var index: number = 0; index < data.Data.length; index++) {
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