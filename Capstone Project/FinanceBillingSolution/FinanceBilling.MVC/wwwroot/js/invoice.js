$(document).ready(function () {
    $('#invoiceTable').DataTable();

    loadClients();
});

function loadClients() {
    $.ajax({
        url: '/Invoice/GetClients',
        type: 'GET',

        success: function (clients) {
            let dropdown = $('#clientUserId');

            dropdown.empty();

            dropdown.append(
                '<option value="">Select Client</option>'
            );

            $.each(clients, function (index, client) {
                dropdown.append(
                    `<option value="${client.userId}">
                        ${client.username} (${client.email})
                    </option>`
                );
            });
        }
    });
}

$('#btnSaveInvoice').click(function () {

    if (!$('#clientUserId').val()) {
        showToast(
            'Please select a client.',
            false);

        return;
    }

    let invoice = {
        clientUserId:
            Number(
                $('#clientUserId').val()),

        totalAmount:
            parseFloat(
                $('#totalAmount').val()),

        dueDate:
            $('#dueDate').val()
    };

    $.ajax({
        url: '/Invoice/Create',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(invoice),

        success: function (response) {
            if (response.success) {
                showToast(
                    response.message,
                    true);

                location.reload();
            }
            else {
                showToast(
                    response.message,
                    false);
            }
        },

        error: function () {
            showToast(
                'Unexpected error occurred.',
                false);
        }
    });
});