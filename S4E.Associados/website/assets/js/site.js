var baseaurl = 'https://localhost:7050/'; // LOCAL

$(document).ready(() => {

    loadSelects();
 
});

/******************** UTIL ************************/

function padLeft(str, length, char) {
    while (str.length < length) {
        str = char + str;
    }
    return str;
}

function formatarData(data) {
    let partesData = data.split('-');
    if (partesData.length === 3) {
        let ano = partesData[0];
        let mes = partesData[1];
        let dia = partesData[2].split('T')[0];
        return `${dia}/${mes}/${ano} `;
    }
    return data;
}

function formatarBRData(data) {
    let partesData = data.split('-');
    if (partesData.length === 3) {
        let ano = partesData[0];
        let mes = partesData[1];
        let dia = partesData[2].split('T')[0];
        return `${ano}/${mes}/${dia} `;
    }
    return data;
}

function toDateFormat(date) {
    let day = padLeft(date.getDate().toString(), 2, '0');
    let month = padLeft((date.getMonth()).toString(), 2, '0');
    let year = date.getFullYear();

    return `${year}-${month}-${day} 00:00:00`;
}

function toBrDateFormat(date) {
    let day = padLeft(date.getDate().toString(), 2, '0');
    let month = padLeft((date.getMonth()).toString(), 2, '0');
    let year = date.getFullYear();

    return `${year}-${month}-${day}`;
}

function getAlert(type, message) {

    let alertClass = 'primary';
    switch (type) {
        case 'error': {
            alertClass = 'danger';
            break;
        }
        case 'success': {
            alertClass = 'success';
            break;
        }
        case 'warning': {
            alertClass = 'warning';
            break;
        }
        default: {
            alertClass = 'primary';
            break;
        }
    }

    let alert = `    
                <div class="alert alert-${alertClass} text-white font-weight-bold" role="alert">
                    ${message}
                </div>
                `;

    return alert;
}

function showAlert(type, message) {
    let alertClass = 'primary';
    switch (type) {
        case 'error': {
            alertClass = 'danger';
            break;
        }
        case 'success': {
            alertClass = 'success';
            break;
        }
        case 'warning': {
            alertClass = 'warning';
            break;
        }
        default: {
            alertClass = 'primary';
            break;
        }
    }

    $('[name=alert]').removeClass(`alert-danger`);
    $('[name=alert]').removeClass(`alert-success`);
    $('[name=alert]').removeClass(`alert-warning`);
    $('[name=alert]').removeClass(`alert-primary`);

    $('[name=alert]').addClass(`alert-${alertClass}`);
    $('[name=alert]').text(message)
    $('[name=alert]').fadeIn(500);
    setTimeout(function () {
        $('[name=alert]').fadeOut(500);
    }, 3000);
}

function cleanFields(arrayFields) {
    $(arrayFields).each((index, value) => {
        $(`#${value}`).val('');
    });
}

function callServerWithNoBody(verb, uri, needsSuccessAnswer = true) {
    $.ajax({
        type: verb,
        async: false,
        url: `${baseaurl}${uri}`,
        contentType: 'application/json',
        success: function (response) {
            if(needsSuccessAnswer)
                showAlert('success', response['message']);
        },
        error: function (error) {
            showAlert('error', error['message']);
        }
    });
}

function callServerWithBody(verb, uri, body, needsSuccessAnswer = true){
    $.ajax({
        type: 'POST',
        async: false,
        url: `${baseaurl}${uri}`,
        data: JSON.stringify(body),
        contentType: 'application/json',
        success: function (response) {
            if(needsSuccessAnswer)
                showAlert('success', response['message']);
        },
        error: function (error) {
            showAlert('error', error['message']);
        }
    });
}

/******************** UTIL ************************/

function loadSelects() {
    alert("teste");
    let empresas = callServerWithNoBody("GET", "Associado?skip=1&take=100", true);
    // let associados = callServerWithNoBody("GET", "Empresa?skip=1&take=100", true);

    createSelect(empresas, `#associados`);
    // createSelect(associados);
}

function createSelect(response, component) {
    $(response).each((index, value) => {
        $(component).append(`<option value="${value.id}">${value.nome}</option>`);
    });
}

