// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    LoadProData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/Service/signalrServer").build();
    connection.start();

    connection.on("LoadProducts", function () {
        LoadProData();
    })
    LoadProData();

    function LoadProData() {
        var tr = '';
        $.ajax({
            url: '/Order/OnGetAsync',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                        <td> ${v.Quantity} </td>
                        <td> ${v.Order} </td>
                        <td> ${v.Product} </td>
                        </tr>`
                })

                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }
})