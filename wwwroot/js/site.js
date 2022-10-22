// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Request() {
    var _data =
    {
        'fromdate': $("#fromdate").val(),
        'todate': $("#todate").val(),
        'tagged': $("#tagged").val()

    };
    $.ajax({
        url: 'http://localhost:53706/api/values/post',
        method: 'post',
        data: {
            
           _data

        },
        success: function (data) {
            alert(data);
        }
    });
}