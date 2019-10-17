var Account = function () {
    return {
        Init: function () {
            $("#btnSubmit").off("click").on("click", function (e) {
                if ($('#formlogin').valid()) {
                     Account.Login();
                    //$("#formlogin").validate({
                    //    // Specify validation rules
                    //    rules: {
                    //        UserName: {
                    //            required: true,
                    //        },

                    //        PassWord: {
                    //            required: true,
                    //            minlength: 6
                    //        }
                    //    },
                    //    // Specify validation error messages
                    //    messages: {
                    //        UserName: {
                    //            required: "Please enter username",
                    //        },
                    //        PassWord: {
                    //            required: "Please provide a password",
                    //            minlength: "Your password must be at least 6 characters long"
                    //        },
                    //    },
                    //    // Make sure the form is submitted to the destination defined
                    //    // in the "action" attribute of the form when valid
                    //    submitHandler: function (form) {
                    //        Account.Login();
                    //    }
                    //});

                }
              
  
            });
        },
        Login: function () {
            var token = $("input[name='__RequestVerificationToken']").val();
            $.ajax({
                type: "POST",
                url: "/Account/Login",
                headers:
                {
                    "RequestVerificationToken": token
                },
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                data: $("#formlogin").serialize(),
                datatype: "json",
                success: function (response) {
                    if (!response.status) {
                        // modal error
                        //$.confirm({
                        //    title: 'Error!',
                        //    content: response.message,
                        //    icon: 'fa fa-warning',
                        //    type: 'red',
                        //    typeAnimated: true,
                        //    buttons: {
                        //        close: function () {
                        //        }
                        //    }
                        //});
                        $("#model-error").text(response.message);
                        $("#model-error").css("display", "block").css("padding-top","45px")
                    } else {
                        window.location.href = response.url;
                    }
                },
                error: function () {
                    $.confirm({
                        title: 'Error!',
                        icon: 'fa fa-warning',
                        content: "Có lỗi sảy ra !",
                        type: 'red',
                        typeAnimated: true,
                        buttons: {
                            close: function () {
                            }
                        }
                    });
                }
            });
        },
    }

}();