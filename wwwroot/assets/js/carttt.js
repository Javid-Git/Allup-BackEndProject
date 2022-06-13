$('.product-close').click(function (e) {
    e.preventDefault();
    let url = $(this).attr('href');
    console.log('sadasasa');


    fetch(url).then(response => response.text()).then(data => { $('.mini-cart').html(data) })
})
