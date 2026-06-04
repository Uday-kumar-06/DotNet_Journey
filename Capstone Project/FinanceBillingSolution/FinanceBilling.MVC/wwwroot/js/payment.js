$(document).ready(function () {
    $('#paymentTable').DataTable();

    loadInvoices();
});

function loadInvoices() {
    $.ajax({
        url: '/Invoice/GetAllInvoices',
        type: 'GET',

        success: function (invoices) {
            let dropdown =
                $('#invoiceId');

            dropdown.empty();

            dropdown.append(
                '<option value="">Select Invoice</option>'
            );

            $.each(invoices,
                function (index, invoice) {
                    dropdown.append(
                        `<option value="${invoice.invoiceId}">
                            INV-${invoice.invoiceId}
                            (${invoice.clientName})
                        </option>`
                    );
                });
        }
    });
}

$('#btnSavePayment').click(function () {
    if (!$('#invoiceId').val()) {
        showToast(
            'Please select an invoice.',
            false);

        return;
    }

    let payment =
    {
        invoiceId:
            Number($('#invoiceId').val()),

        amountPaid:
            parseFloat($('#amountPaid').val()),

        paymentMethod:
            $('#paymentMethod').val()
    };

    $.ajax({
        url: '/Payment/Create',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(payment),

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