$(document).ready(function () {

    $('form').submit(function (e) {
        e.preventDefault();
        var username = $('#username').val();
        var password = $('#password').val();

        if (username == "" || password == "") {
            alert("Lütfen gerekli alanları doldurunuz");
        }
        else {


            $.ajax({
                type: "POST",
                url: "/authentication/login",
                data: {
                    UserName: username,
                    Password: password
                },
                dataType: "json",
                success: function (response) {
                    if (response) {
                        window.location.href = '/forms/list'; 
                    }
                    else {
                        alert("Bu bilgilere ait kullanıcı bulunamadı.");
                    }
                }
            });

        }

    });
});
