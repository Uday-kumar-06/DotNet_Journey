$(document).ready(function () {
    loadPendingUsers();
});

function loadPendingUsers() {
    $.ajax({
        url: '/User/GetPendingUsers',
        type: 'GET',

        success: function (users) {
            let body =
                $('#userTable tbody');

            body.empty();

            $.each(users,
                function (index, user) {
                    body.append(`
<tr>

<td>${user.username}</td>

<td>${user.email}</td>

<td>

<select class="form-select role-select"
        data-userid="${user.userId}">

<option value="2">
Manager
</option>

<option value="3">
Client
</option>

</select>

</td>

<td>

<button
class="btn btn-success btn-approve"
data-userid="${user.userId}">

Approve

</button>

</td>

</tr>
`);
                });

            $('#userTable').DataTable();
        }
    });
}

$(document).on(
    'click',
    '.btn-approve',
    function () {
        let userId =
            $(this).data('userid');

        let roleId =
            $(this)
                .closest('tr')
                .find('.role-select')
                .val();

        $.ajax({
            url: '/User/Approve',
            type: 'POST',
            contentType:
                'application/json',

            data: JSON.stringify({
                userId: userId,
                roleId: Number(roleId)
            }),

            success: function (response) {
                if (response.success) {
                    showToast(
                        response.message,
                        true);

                    loadPendingUsers();
                }
                else {
                    showToast(
                        response.message,
                        false);
                }
            }
        });
    });