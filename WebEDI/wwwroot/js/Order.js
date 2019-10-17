const order = function () {


    function search() {
        var dateorder = $('#dateorder').val();
        var dateend = $('#dateend').val();
        var id = $('#idorder').val();
        var check = document.getElementById('dropdownSearch').value;
        $.ajax({
            url: "/Order/SearchOrder",
            type: "POST",
            data: { _dateorder: dateorder, _dateend: dateend, _id: id,_check:check },
            success: function (response) {
                var tableBody = $('#table_orders');
                if (response.status == 0) {
                    tableBody.html(response.html);
                    $('#SuplierName').val(response.supliername);
                    if (document.getElementById('table_orders').style.display == 'none') {
                        document.getElementById('table_orders').style.display = ''
                    }
                }
                else {
                    $('#dialog_infor_content').text(response.message);
                    $('#dialog_infor').modal();
                }
            }
        });
    }

    function showpopup() {
        var check = true;
        var have = false;
        $('input[type=checkbox]').each(function () {
            if (this.checked == true) {
                var supliermail = $('#' + this.id + 'mailsuplier').text();
                var confirm = $('#' + this.id + 'confirm').text();
                if (supliermail == "" || supliermail == null) {
                    var suplier = supliermail = $('#' + this.id + 'suplier').val();
                    $('#dialog_infor_content').text("仕入先" + suplier + "には、メールアドレスが設定されていません。ユーザー設定を確認してください");
                    $('#dialog_infor').modal();
                    check = false;
                    return false; 
                }
                if (confirm == "" || confirm == null || confirm == "00") {
                    $('#dialog_infor_content').text("" + username + "はメール送信対象ではありません。");
                    $('#dialog_infor').modal();
                    check = false;
                    return false; 
                }
                have = true;
            }

        });
        if (have == false) {
            $('#dialog_infor_content').text("選択されていません");
            $('#dialog_infor').modal();
        }
        if (check == true && have==true) {
            $("#dialog_confirm_sendmail").modal();
        }
    }
    function sendmail() {
        var idordermail = "";

        $('input[type=checkbox]').each(function () {
            if (this.checked == true) {
                idordermail += this.id + ",";
            }
        });
        $.ajax({
            url: "/Order/SendMail",
            type: "POST",
            data: { _id: idordermail },
            success: function (response) {
                var tablebody = $('#table_orders');
                tablebody.find('input[type=checkbox]').prop("checked", false);
                if (response.status === 0) {
                    $('#dialog_infor_content').text(response.message);
                    $('#dialog_infor').modal();
                    console.log('Save successfully');
                } else {
                    $('#dialog_infor_content').text(response.message);
                    $('#dialog_infor').modal();
                    console.log('Saving fail');
                }
            }
        });
    }


    return {
        search: search,
        sendmail: sendmail,
        showpopup: showpopup,
    }
}();
$("#btn_back").click(function () {
    if (document.getElementById('table_orders').style.display == 'none') {
        window.location.href = ("/Home/Index");
    }
    else {
        document.getElementById('table_orders').style.display = 'none';
    }
});
$(function () {
    $('#datetimepicker1').datetimepicker();
});