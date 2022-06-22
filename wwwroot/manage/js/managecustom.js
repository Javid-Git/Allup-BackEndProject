const { data } = require("jquery");

$(document).ready(function () {
    $(document).on('click', '.deleteBtn', function (e) {
        e.preventDefault();
        let url = $(this).attr("href");

        fetch(url)
            .then(res => res.text())
            .then(data => { $('.tblContent').html(data) })
    })
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    if ($('#successInput').val().length) {
        toastr["success"]($('#successInput').val(), $('#successInput').val().split(' ')[0])
    }
})