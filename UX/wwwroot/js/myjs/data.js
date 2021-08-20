
$(document).ready(function () {

    let url = "https://localhost:44347";


        $("#login_button").click(function () {

            let email = $("#typeEmailX").val();
            let password = $("#typePasswordX").val();

            $.ajax({
                method: "POST",
                url: url + "/Auth/Giris",
                headers: {
                    "content-type": "application/json"
                },
                data: JSON.stringify({
                    KullaniciAdi: email,
                    Sifre: password,
                }),
                async: true,
                success: function (response) {
                    swal({
                        title: "Giriş Başarılı!",
                        text: "Bilgileriniz Doğru",
                        icon: "success",
                    });
                },
                error: function (response) {
                    swal({
                        title: "Giriş Başarısız!",
                        text: "Lütfen Kullanici Adinizi ve şifrenizi tekrar kontrol edin.",
                        icon: "error",
                    });
                }
            });

        });
    $("#register_button").click(function () {

        let name = $("#register_name").val();
        let surname = $("#register_surname").val();
        let username = $("#register_username").val();
        let password = $("#register_password").val();
        if (name != "" && surname != "" && username != "" && password != "") {
            $.ajax({
                method: "POST",
                url: url + "/Auth/Kaydol",
                headers: {
                    "content-type": "application/json"
                },
                data: JSON.stringify({
                    KullaniciAdi: username,
                    Ad: name,
                    Soyad: surname,
                    KullaniciAdi: username,
                    Sifre: password,
                }),
                async: true,
                success: function (response) {
                    swal({
                        title: "Hoşgeldiniz!",
                        text: "Kaydoldunuz",
                        icon: "success",
                    });
                },
                error: function (response) {

                        swal({
                            title: "Giriş Başarısız!",
                            text: "Böyle Bir Kullanici Mevcut",
                            icon: "error",
                        });
                }
            });
        }
        else
        {
            swal({
                title: "!!",
                text: "Eksik bir yer olmadığına emin olun",
                icon: "error",
            });
        }
       

    });

        

});

