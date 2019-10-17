$('#btnDownloadFile').on('click', function () {
    var i = 1;
    var items="";
    $("#tbody_table > tr").each(function () {
        if ($("#cboData_" + (i - 1)).is(':checked')) {
            if (items.length == 0)
                items = items + i.toString();
            else {
                items = items + ",";
                items = items + i.toString();
            }
        }
        i++;
    });
    if (items.length == 0) {
        alert("選択されていません");
    } else {
        alert(items);
    }
    
});
$('#btnBack').on('click', function () {
    if (document.getElementById('pruebatabla').style.display == 'none') {
        window.location.href = ("/Order/Index");
    }
    else {
        document.getElementById('pruebatabla').style.display = 'none';
    }
});
function TestClip(img) {
    alert(img.closest('tr').rowIndex);
};
