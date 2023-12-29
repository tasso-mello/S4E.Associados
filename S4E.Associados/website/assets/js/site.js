var baseaurl = 'https://localhost:7050/'; // LOCAL
var result;
var hasParameter;

$(document).ready(() => {
    let page = window.location.href.split('website/')[1];
    let param = window.location.search;
    hasParameter = param != '' && param != undefined;

    if (hasParameter) {
        page = page.split("?")[0];
    }

    switch (page) {
        case "index.html": {
            loadTables();
            break;
        }
        case "Associados.html": {
            loadSelects("associado");
            if (hasParameter) {
                loadById(window.location.search.split("=")[1], "associado");
            }
            break;
        }
        case "Empresas.html": {
            loadSelects("empresa");

            if (hasParameter) {
                loadById(window.location.search.split("=")[1], "empresa");
            }

            break;
        }
    }
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
    let month = padLeft((date.getMonth() + 1).toString(), 2, '0');
    let year = date.getFullYear();

    return `${year}-${month}-${day}`;
}

function toUSDateFormat(date) {
    let day = padLeft(date.getDate().toString(), 2, '0');
    let month = padLeft((date.getMonth() + 1).toString(), 2, '0');
    let year = date.getFullYear();

    return `${month}-${day}-${year}`;
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

function callServerWithNoBody(verb, uri, needsSuccessAnswer = true, redirectAnotherPage = false, page = "index.html") {
    $.ajax({
        type: verb,
        async: false,
        url: `${baseaurl}${uri}`,
        contentType: 'application/json',
        success: function (response) {
            result = response;

            if (needsSuccessAnswer)
                showAlert('success', response['message']);

            if (redirectAnotherPage)
                window.location.href = page;
        },
        error: function (error) {
            showAlert('error', error['message']);
        }
    });
}

function callServerWithBody(verb, uri, body, needsSuccessAnswer = true, redirectAnotherPage = false, page = "index.html") {
    $.ajax({
        type: verb,
        async: false,
        url: `${baseaurl}${uri}`,
        data: JSON.stringify(body),
        contentType: 'application/json',
        success: function (response) {
            result = response;

            if (needsSuccessAnswer)
                showAlert('success', response['message']);

            if (redirectAnotherPage)
                window.location.href = page;
        },
        error: function (error) {
            showAlert('error', error['message']);
        }
    });
}

/******************** UTIL ************************/

function loadById(id, model) {

    switch (model) {
        case "empresa": {
            callServerWithNoBody("GET", `Empresa/${id}`, false);
            let empresa = JSON.parse(result);
            loadEmpresaFields(empresa.empresa);
            createDeleteButton(id, "Empresa");
            break;
        }
        case "associado": {
            callServerWithNoBody("GET", `Associado/${id}`, false);
            let associado = JSON.parse(result);
            loadAssociadoFields(associado.associado);
            createDeleteButton(id, "Associado");
            break;
        }
    }
}

function createDeleteButton(id, name) {
    $(`#${name}-action`).append(
        `
            <div class="col-sm-4">
                <div class="single-contact-btn">
                    <button class="contact-btn" onclick="delete${name}(event, ${id})">Remover</button>
                </div>
            </div>
        `
    );
}

function loadEmpresaFields(empresa) {
    $("#name").val(empresa.Nome);
    $("#cnpj").val(empresa.CNPJ);
    let associados = document.getElementById('associados-drop');

    Array.from(associados.options).forEach(function (option) {
        option.selected = empresa.Associados.some(e => e.Id == option.value);
    });
}

function loadAssociadoFields(associado) {
    $("#name").val(associado.Nome);
    $("#cpf").val(associado.CPF);
    $("#nascimento").val(toBrDateFormat(new Date(associado.Nascimento)));
    let empresas = document.getElementById('empresas-drop');

    Array.from(empresas.options).forEach(function (option) {
        option.selected = associado.Empresas.some(e => e.Id == option.value);
    });
}

function loadTables() {
    callServerWithNoBody("GET", "Associado?skip=1&take=100", true);
    let associados = JSON.parse(result);
    createAssociadosTable(associados.associado);

    callServerWithNoBody("GET", "Empresa?skip=1&take=100", false);
    let empresas = JSON.parse(result);
    createEmpresasTable(empresas.empresa);
}

function loadSelects(page) {

    switch (page) {
        case "associado":
            {
                callServerWithNoBody("GET", `empresa?skip=1&take=100`, false);
                let empresas = JSON.parse(result);
                createSelect(empresas.empresa, `#empresas-drop`);
                break;
            }
        case "empresa": {
            callServerWithNoBody("GET", `associado?skip=1&take=100`, false);
            let associados = JSON.parse(result);
            createSelect(associados.associado, `#associados-drop`);
            break;
        }
    }
}

function createSelect(response, component) {
    $(response).each((index, value) => {
        $(component).append(`<option value="${value.Id}">${value.Nome}</option>`);
    });
}

function createAssociadosTable(response) {
    $(response).each((index, value) => {
        $('#associados-body').append(
            `
                <tr ondblclick="window.location.href='Associados.html?id=${value.Id}'">
                    <td class="py-3">
                        <span class="text-xs">${value.Nome}</span>
                    </td>
                    <td class="text-center py-3">
                        <span class="text-xs">${value.CPF}</span>
                    </td>
                    <td class="text-center py-3">
                        <span class="text-xs">${formatarData(value.Nascimento)}</span>
                    </td>
                    <td class="text-center py-3">
                        <span class="text-xs">${writeEmpresas(value.Empresas)}</span>
                    </td>
                </tr>
            `
        );
    });
}

function writeEmpresas(empresas) {
    let strEmpresas = '';
    $(empresas).each((index, value) => {
        strEmpresas += `${value.Nome}; `
    });
    return strEmpresas;
}

function createEmpresasTable(response) {
    $(response).each((index, value) => {
        $('#empresas-body').append(
            `
                <tr ondblclick="window.location.href='Empresas.html?id=${value.Id}'"">
                    <td class="py-3">
                        <span class="text-xs">${value.Nome}</span>
                    </td>
                    <td class="text-center py-3">
                        <span class="text-xs">${value.CNPJ}</span>
                    </td>
                    <td class="text-center py-3">
                        <span class="text-xs">${writeAssociados(value.Associados)}</span>
                    </td>
                </tr>
            `
        );
    });
}

function writeAssociados(associados) {
    let strAssociados = '';
    $(associados).each((index, value) => {
        strAssociados += `${value.Nome}; `
    });
    return strAssociados;
}

function saveAssociado(event) {
    let canSave = $('#name').val() != '' &&
        $('#cpf').val() != '' &&
        $('#nascimento').val() != '';

    if (canSave) {
        event.preventDefault();

        var selectElement = document.getElementById("empresas-drop");
        var selectedOptions = Array.from(selectElement.selectedOptions);
        var empresasSelecionadas = selectedOptions.map(function (option) {
            return {
                id: option.value,
                nome: option.innerText,
                cnpj: ""
            };
        });

        const jsonData = {
            id: hasParameter ? window.location.search.split("=")[1] : 0,
            nome: $('#name').val(),
            cpf: $('#cpf').val(),
            nascimento: $('#nascimento').val(),
            empresas: empresasSelecionadas
        };
        if (hasParameter)
            callServerWithBody("PUT", "Associado", jsonData, false, true);
        else
            callServerWithBody("POST", "Associado", jsonData, false, true);
    }
}

function saveEmpresa(event) {
    let canSave = $('#name').val() != '' &&
        $('#cnpj').val() != '';

    if (canSave) {
        event.preventDefault();

        var selectElement = document.getElementById("associados-drop");
        var selectedOptions = Array.from(selectElement.selectedOptions);
        var associadosSelecionados = selectedOptions.map(function (option) {
            return {
                id: option.value,
                nome: option.innerText,
                cpf: ""
            };
        });

        const jsonData = {
            id: hasParameter ? window.location.search.split("=")[1] : 0,
            nome: $('#name').val(),
            cnpj: $('#cnpj').val(),
            associados: associadosSelecionados
        };

        if (hasParameter)
            callServerWithBody("PUT", "Empresa", jsonData, false, true);
        else
            callServerWithBody("POST", "Empresa", jsonData, false, true);
    }
}

function deleteAssociado(event, id) {
    if (hasParameter) {
        event.preventDefault();
        callServerWithNoBody("DELETE", `Associado/${id}`, false, true);        
    }
}

function deleteEmpresa(event, id) {
    if (hasParameter) {
        event.preventDefault();
        callServerWithNoBody("DELETE", `Empresa/${id}`, false, true);
    }
}