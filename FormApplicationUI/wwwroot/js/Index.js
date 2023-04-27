$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "/Forms/GetAll",
        data: "",
        dataType: "json",
        success: function (response) {
            var data = [];
            $.each(response, function (index, item) {
                data.push({ id: item.id, name: item.name, description: item.description, createdAt: item.createdAt, createdBy: item.createdBy })
            });


            // Add rows to the table
            data.forEach(function (item) {
                var row = '<tr><td class="row-value">' + item.id + '</td><td>' + item.name + '</td><td>' + item.description + '</td><td>' + getDateAsDDMMYYYY(item.createdAt) + '</td><td>' + item.createdBy + '</td><td>' + `<button type="button" class="btn btn-primary btn-add" id="add-data">
  <i class="bi bi-pencil"></i> Veri Gir
</button> <button type="button" class="btn btn-success btn-edit" id="add-data">
  <i class="bi bi-pencil"></i> Dataları Görüntüle
</button> ` + '</td></tr>';
                $('#table-body').append(row);
            });
        }
    });



});


$('#add-row').click(function () {
    $('#myModal').modal('show');
});


$('#table-body').on('click', '.btn-add', function () {
    var rowValue = $(this).closest('tr').find('td.row-value').text();
    $('#formId').val(rowValue);


    $('#myAddDataModal').modal('show');
});

$('#table-body').on('click', '.btn-edit', function () { 
    var rowValue = $(this).closest('tr').find('td.row-value').text(); 

    window.location.href = '/Forms/Detail?id=' + rowValue;
     
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


$('#saveForm').click(function () {
    var name = $('#name').val();
    var description = $('#description').val();

    if (name == "" || description == "") {
        alert("Lütfen gerekli alanları doldurunuz");
    }
    else {

        $.ajax({
            type: "POST",
            url: "/Forms/Add",
            data: {
                Name: name,
                Description: description
            },
            dataType: "json",
            success: function (response) {
                if (response) {
                    alert("Başarı ile eklendi.");
                    $('#myModal').modal('hide');


                    location.reload();

                }
                else {
                    alert("Form eklenemedi.");
                    $('#myModal').modal('hide');
                }
            }
        });

    }


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
                    $('#myModal').modal('hide');


                    location.reload();

                }
                else {
                    alert("Form eklenemedi.");
                    $('#myModal').modal('hide');
                }
            }
        });

    }


});


function getDateFromAspNetFormat(date) {
    if (date && typeof date === "string") {
        var re = /-?\d+/;
        var m = re.exec(date);
        var returndate = new Date(parseInt(m[0], 10));
        return returndate;
    }
    else {
        return date;
    }
}

function getDateAsDDMMYYYYjustTime(date) {
    if (date instanceof Date) {
        var dd = date.getDate();
        var mm = date.getMonth() + 1;
        var min = date.getMinutes();
        var hour = date.getHours();


        var yyyy = date.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        if (min < 10) {
            min = '0' + min;
        }
        if (hour < 10) {
            hour = '0' + hour;
        }
        var result = `${hour}:${min}`;
        return result;
    }
    else {
        return date;
    }
}

function getDateAsDDMMYYYY(date) {
    if (date instanceof Date) {
        var dd = date.getDate();
        var mm = date.getMonth() + 1;
        var min = date.getMinutes();
        var hour = date.getHours();


        var yyyy = date.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        if (min < 10) {
            min = '0' + min;
        }
        if (hour < 10) {
            hour = '0' + hour;
        }
        var result = `${dd}-${mm}-${yyyy} ${hour}:${min}`;
        return result;
    }
    else {
        return date;
    }
}

function getDateAsDDMMYYYYjustDate(date) {
    if (date instanceof Date) {
        var dd = date.getDate();
        var mm = date.getMonth() + 1;
        var min = date.getMinutes();
        var hour = date.getHours();


        var yyyy = date.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        if (min < 10) {
            min = '0' + min;
        }
        if (hour < 10) {
            hour = '0' + hour;
        }
        var result = `${dd}-${mm}-${yyyy}`;
        return result;
    }
    else {
        return date;
    }
}