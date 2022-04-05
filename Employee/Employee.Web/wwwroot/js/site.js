// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function editEmployee(id) {
    $.ajax({
        url: '/Employee/Edit/' + id,
        success: function (data) {
            $('#editForm').html(data);
            $('#editEmployeeModal').modal();
        }
    });
}

function deleteEmployee(id,name) {

    var result = confirm("Are you sure you want to delete the employee " + name + " ?.");
    if (result) {
        $.ajax({
            url: '/Employee/Delete/' + id,
            method:'Delete',
            success: function (data) {
                location.href = "/Employee";
            }
        });
    }
}

$(document).delegate('#StateId','change', function () {
    var cityDropdown = $('#CityId');
    
    cityDropdown.empty();
    cityDropdown.append($(`<option  value="0" >Please select City.</option>`));
    var state = $(this).val();
    if (state.length > 0) {
        $.getJSON('/Employee/Cities/' + state)
            .done(function (data) {
             
                $.each(data, function (i, city) {
                    var option = $(`<option  value="${city.id}" />`).html(city.name);
                    cityDropdown.append(option);
                });
            })
            .fail(function (jqxhr, textStatus, error) {
                var err = textStatus + ", " + error;
                console.log("Request Failed: " + err);
            });
    }
});  