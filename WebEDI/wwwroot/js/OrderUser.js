function selectedIds() {
    var strId = "";
    var count = document.getElementById("pruebatabla").rows.length
    var tableObj = $("#tbody_table > tr");
    $("#tbody_table > tr").each(function (index) {
        var obj = $("#cboData_" + index);
        var objId = $("#id_" + index);
        if (obj.is(':checked')) {
            strId += objId.val() + ",";
        }
    });

    if (strId != "") {
        strId = strId.substring(0, strId.length - 1);
    } else {
        alert('Select records, please!');
        return "";
    }
    return strId;
}

$('#butExportCSV').on('click', function () {
    var strId = selectedIds();
    if (strId=="") {        
        return;
    }

    if (confirm("確認日時をセットします。よろしいですか？")) {
        var jsonData = "{ \"str\": \"" + strId + "\" }";
        $.ajax({
            type: "POST",
            url: '/OrderUser/ExportCSV',
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: jsonData,
            success: function (data) {
                var blob = new Blob([data], { type: "application/csv;charset=UTF-8" });
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(blob);
                link.download = "注文明細_受信日時.csv";
                link.click();
            },
            error: function () {
                alert('Something went wrong, contact IT for more information');
            }
        });
    }
});

$('#butZipAndDownload').on('click', function () {
    var strId = selectedIds();
    if (strId=="") {        
        return;
    }

    //if (confirm("確認日時をセットします。よろしいですか？")) {
    var jsonData = "{ \"str\": \"" + strId + "\" }";
    var ajax = new XMLHttpRequest();
    ajax.open("Post", "/OrderUser/ZipAndDownload", true);
    ajax.setRequestHeader("Content-Type", "application/json");    
    ajax.responseType = "blob";
    ajax.onreadystatechange = function () {
        if (this.readyState == 4) {        
            var blob = new Blob([this.response], { type: "application/octet-stream" });
            var fileName = "temp.zip";
            saveAs(blob, fileName);
        }
    };
    ajax.send(jsonData);      
});

$('#butOrderOutput').on('click', function () {
    var strId = selectedIds();
    if (strId == "") {
        return;
    }

    if (confirm("確認日時をセットします。よろしいですか？")) {
        var jsonData = "{ \"str\": \"" + strId + "\" }";
        var ajax = new XMLHttpRequest();
        ajax.open("Post", "/OrderUser/ZipAndDownload", true);
        ajax.setRequestHeader("Content-Type", "application/json");
        ajax.responseType = "blob";
        ajax.onreadystatechange = function () {
            if (this.readyState == 4) {
                debugger;
                var blob = new Blob([this.response], { type: "application/octet-stream" });
                var fileName = "cyumon.zip";
                saveAs(blob, fileName);
            }
        };
        ajax.send(jsonData);
    }
});

$('#btnConfirm').on('click', function () {
    var strId = selectedIds();
    if (strId == "") {
        return;
    }

    if (confirm("確認日時をセットします。よろしいですか？")) {
        var jsonData = "{ \"str\": \"" + strId + "\" }";
        $.ajax({
            type: "POST",
            url: '/OrderUser/ConfirmUpdate',
            cache: false,
            contentType: "application/json; charset=utf-8",
            data: jsonData,
            success: function (data) {
                window.location ='/OrderUser/'
            },
            error: function () {
                alert('Something went wrong, contact IT for more information');
            }
        });
    }
});


$('#butBack').on('click', function () {
    window.location = '/Home'
});


$(document).on('click', 'input[type="checkbox"]', function () {
    var radio = $(this).attr('id');
    var typeRadio = radio.substring(0, 10);
    var id = radio.substring(10, radio.length);
    var numberChecked = 0;
    if (typeRadio == 'cboData_') {
        var radioId = '#cboData_' + id;
        $(radioId).prop('checked', true);
    }
    $('#tbody_table' + ' input[type="checkbox"]').each(function () {
        if ($(this).is(":checked")) {
            numberChecked++;
        }
    });
});
