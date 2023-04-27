$(document).ready(function () {
     
    var rowValue = $('#formId').val();

    $.ajax({
        type: "POST",
        url: "/Forms/GetById",
        data: {
            Id: rowValue
        },
        dataType: "json",
        success: function (response) {
            $('#table-body-data').empty();

            var data = [];
            $.each(response, function (index, item) {
                data.push({ name: item.name, surname: item.surname, age: item.age })
            });


            // Add rows to the table
            data.forEach(function (item) {
                var row = '<tr><td class="row-value">' + item.name + '</td><td>' + item.surname + '</td><td>' + item.age + '</td></tr>';
                $('#table-body-data').append(row);
            });
             
        }
    });

});


$('#logout').click(function () {
    $.ajax({
        type: "POST",
        url: "/Authentication/Logout",
        data: "",
        dataType: "json",
        success: function (response) {
            window.location.href = '/Authentication/Login'; 
        }
    });
});

$('#back-row').click(function () {
    window.location.href = '/Forms/List';
});

$('#add-row').click(function () {
    $('#myAddDataModal').modal('show');
});

$('#saveData').click(function () {
     

    var formId = $('#formId').val();
    var name = $('#nameData').val();
    var surname = $('#surnameData').val();
    var age = $('#ageData').val();

    if (name == "" || surname == "" || age == "") {
        alert("Lütfen gerekli alanları doldurunuz");
    }
    else {

        $.ajax({
            type: "POST",
            url: "/Forms/AddData",
            data: {
                FormId: formId,
                Name: name,
                Surname: surname,
                Age: age
            },
            dataType: "json",
            success: function (response) {
                if (response) {
                    alert("Başarı ile eklendi.");
                    $('#myAddDataModal').modal('hide');


                    location.reload();

                }
                else {
                    alert("Form eklenemedi.");
                    $('#myAddDataModal').modal('hide');
                }
            }
        });

    }


});

