
$(document).ready(function () {
    $('.modaldetail').click(function (e) {
        e.preventDefault();
        let url = $(this).attr('href');

        console.log(url);

        fetch(url).then(response => {
            return response.text();
        }).then(data => {
            $('.modal-content').html(data);
        })
    })
    $('.searchinput').keyup(function () {
        let value = $(this).val();
        console.log(value);

        let url = $(this).data("url");
        url = url + '?search=' + value.trim();
        console.log(url);

        if (value) {
            fetch(url)
                .then(response => response.text())

                .then(data => {
                    $('.search-body .list-group').html(data)

                })
        }
        else {
            $('.search-body .list-group').html('')
        }

    })

    $('.addtobasket').click(function (e) {
        e.preventDefault();
        let url = $(this).attr('href');

        fetch(url)
            .then(response => response.text())
            .then(data => {
                $('.mini-cart').html(data)
            })
    })

    $('.deletefrombasket').click(function (e) {
        e.preventDefault();
        let url = $(this).attr('href');
        console.log('aaaaaaaaa');

        fetch(url)
            .then(response => response.text())
            .then(data => {
                $('.mini-cart').html(data)
            })
    })
})

