$('#registerCust').on('click', function () {
    
    $('#exampleModalCenter').modal('toggle')
    
    let i = $('#myModal');
    

})

function closeElement(e) {
    console.log(e)
    $(`#${e}`).modal('toggle')
}

$('#savePhone').on('click', () => {

    let n = $('#inputPhone').val();
    let cId = $('#hidId').val();
    let failed = false;
    if (n == '') {
        showAlert('phone is undefined')
        failed = true;
    }
    if (cId == '') {
        showAlert('customId is undefined')
        failed = true;
    }
    if (failed)
        return !failed;

    let data = {
        'cId': cId,
        'Phone': n,
    }
    console.log(data)

    $.ajax({
        type: "POST",
        url: '/Customer/Add/Phone',
        data: JSON.stringify(data),
        success: function (data) {
            console.log(data)

            $('#inputPhone').val('');
            $('#hidId').val(0);
            $('#myModal').modal('toggle')
            var table = $('#productDatatable').DataTable();
            table.ajax.reload();

            return data;
        },
        error: function (returnval) {
            console.log(returnval)
            alert(returnval.responseJSON.validation)
        },
        contentType: 'application/json'
    });

})

function clearpModal() {
    $('#phoneContainer').empty();
    $('#pModal').modal('toggle')
}

function ShowPhoneList(id) {

    
    let uri = `/Customer/Get/PhoneList/${id}`;
    let placeHolder = {};
    $('#phoneContainer').empty();
    $.ajax({
        type: 'Get',
        url: uri,
        //contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        success: function (result) {
            $('#pModal').modal('toggle')
            var list = $('<ul/>').appendTo('#phoneContainer');
            result.data.forEach(element =>

                list.append(`<li>${element.cpPhone}</li>`));
            
            //for (let i = 0; i < 10; i++) {
            //    // New <li> elements are created here and added to the <ul> element.
            //    list.append('<li>something</li>');
            //}
            alert("Test Crud Desarrollado por https://github.com/PontiacGTX")
        
        },
        error: function () {
            console.log('Failed ');
        }
    })

   
    
}

$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})

function showAlert(message) {
    alert(message);
}
function AddPhoneNumbers(id) {
    $('#myModal').modal('toggle')
    $('#hidId').val(id);
   
}
function DeleteCustomer(id) {

    let uri = `/Customer/Delete/${id}`;
    let placeHolder = {};
    $.ajax({
        type: 'Delete',
        url: uri,
        //contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
        data: placeHolder,
        success: function (result) {

            alert("Test Crud Desarrollado por https://github.com/PontiacGTX")
            var table = $('#productDatatable').DataTable();
            table.ajax.reload();
        },
        error: function () {
            console.log('Failed ');
        }
    })

  
}

$('editBtn').on('click', (e) => {
    e.preventDefault();
    return false;

})

$('#addCustBtn').on('click', () => {
    
    let n = $('#inputName1').val();
    let n2 = $('#inputName2').val();
    let ln1 = $('#inputLastName1').val();
    let ln2 = $('#inputLastName2').val();
    let failed = false;
    if (n == '') {
        showAlert('name1 is undefined')
        failed = true;
    }
    if (n2 == '') {
        showAlert('name2 is undefined')
        failed = true;
    }
    if (ln1 == '') {
        showAlert('lastname1 is undefined')
        failed = true;
    }
    if (ln2 == '') {
        showAlert('lastname2 is undefined')
        failed = true;
        
    }
    if (failed)
        return !failed;

    let data = {
        'cId': 0,
        'Name1': n,
        'Name2':n2,
        'LastName1': ln1,
        'LastName2': ln2,
        'CustomerPhones':[]
    }
    console.log(data)

    $.ajax({
        type: "POST",
        url: '/Customer/Add',
        data: JSON.stringify(data),
        success: function (data) {
            console.log(data)
            $('#inputName1').val('');
            $('#inputName2').val('');
            $('#inputLastName1').val('');
            $('#inputLastName2').val('');
            $('#exampleModalCenter').modal('toggle')
            var table = $('#productDatatable').DataTable();
            table.ajax.reload();

            return data;
        },
        error: function (returnval) {
            console.log(returnval)
            alert(returnval.responseJSON.validation)
        },
        contentType: 'application/json'
    });
})