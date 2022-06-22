
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
                $('.header-cart').html(data)
            })
    })


    $(document).on('click', '.deletefrombasket', function (e) {
        e.preventDefault();
        let url = $(this).attr('href');
        console.log('aaaaaaaaa');

        fetch(url)
            .then(response => response.text())
            .then(data => {
                $('.header-cart').html(data)
            })
    })
    let path = window.location.pathname
    path = path.split('/')
    console.log(path);
    let links = $('.header-horizontal-menu .menu-content li')

    console.log(links)

    for (var i = 0; i < links.length; i++) {
        let hrefpath = links[i].children[0].getAttribute('href').split('/')
        console.log(hrefpath)
        if (hrefpath[1].toLowerCase() == path[1].toLowerCase()) {
            links[i].classList.add('active')
        } else {
            links[i].classList.remove('active')
        }
    }
})

