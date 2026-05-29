$("#bookForm").submit(function (e) {

    e.preventDefault();

    $.ajax({

        url: "/Books/Create",

        type: "POST",

        data: $(this).serialize(),

        success: function () {

            alert("Book Added Successfully");

            location.reload();
        },

        error: function (xhr) {

            alert(xhr.responseText);
        }
    });
});