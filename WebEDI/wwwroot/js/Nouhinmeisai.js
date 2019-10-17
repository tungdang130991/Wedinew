$('#ExportCSV').on('click', function () {
    $.ajax({
        type: "POST",
        url: "/Nouhinmeisais/CsvExportP",
        cache: false,
        success: function (data) {
            var FG = data.fileGuid;
            var FN = data.fileName;
            window.location = '/Nouhinmeisais/Download?fileGuid=' + FG + '&filename=' + FN;
        },
        error: function (data) {
            alert('Something went wrong, contact IT for more information')
        }
    });
});

$('#ExportPDF').on('click', function () {
        alert('FDF download')
});

$('#butBack').on('click', function () {
    window.location = '/Home'
});